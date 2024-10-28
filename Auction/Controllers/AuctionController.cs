using Auction.DAL;
using Auction.Model;
using Auction.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Security.Claims;

namespace Auction.Web.Controllers
{
    public class AuctionController : Controller
    {
		
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly AuctionDbContext _context;
		public AuctionController(AuctionDbContext context, UserManager<ApplicationUser> userManager) {
            _context = context;
            _userManager = userManager;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var auctionQuery = _context.Aukcijas.Include(a => a.Article).AsQueryable();
            var model = auctionQuery.ToList();
            return View(model);
        }

		[AllowAnonymous]
		public IActionResult IndexAjax(AuctionFilterModel filter = null)
		{
			filter ??= new AuctionFilterModel();

			var clientQuery = _context.Aukcijas.Include(p => p.Article).AsQueryable();

			if (!string.IsNullOrWhiteSpace(filter.article.Name))
				clientQuery = clientQuery.Where(p => (p.Article.Name).ToLower().Contains(filter.article.Name.ToLower()));

			if (!string.IsNullOrWhiteSpace(filter.article.Description))
				clientQuery = clientQuery.Where(p => p.Article.Description.ToLower().Contains(filter.article.Description.ToLower()));

			if (filter.startDate != DateTime.MinValue)
				clientQuery = clientQuery.Where(p => p.StartTime > filter.startDate);

			if (filter.endDate != DateTime.MinValue)
				clientQuery = clientQuery.Where(p => p.EndTime < filter.endDate);


			var model = clientQuery.ToList();
			return PartialView("_IndexTable", model);
		}
		[Authorize]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Create(AuctionArticleViewModel model)
		{
            if (ModelState.IsValid)
                
            {
                var user = await _userManager.GetUserAsync(User);
                var article = new Article
                {
                    Name = model.Name,
                    Description = model.Description,
                    StartingPrice = model.StartingPrice,
                    SellerId = user.Id
                };

                var auction = new Aukcija
                {
                    Article = article,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
					Status = "Preparing"
                };
                article.AuctionId = auction.Id;
                _context.Articles.Add(article);
                _context.Aukcijas.Add(auction);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Details(int? id = null)
		{
			var auction = await _context.Aukcijas
			.Include(a => a.Article)
			.ThenInclude(c => c.Seller).Include(a => a.Bids).ThenInclude(b => b.AuctionUser)
			.FirstOrDefaultAsync(a => a.Id == id);
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			bool isOwner = auction.Article.SellerId == userId ? true : false;
			if (auction == null)
			{
				return NotFound();
			}

			var viewModel = new AuctionDetailsViewModel
			{
				Auction = auction,
				MaxBidAmount = auction.Bids.Any() ? auction.Bids.Max(b => b.BidAmount) : (decimal?)null,
				isUserOwner = isOwner
			};

			return View(viewModel);
		}
		[Authorize]
		public async Task<IActionResult> Bid(int id)
        {
            var auction = _context.Aukcijas.Include(a => a.Article).ThenInclude(c => c.Seller).Include(a => a.Bids).ThenInclude(b => b.AuctionUser).Where(a => a.Id == id).First();
			var user = await _userManager.GetUserAsync(User);
			if (auction == null)
            {
                return NotFound();
            }
			var existingBid = await _context.Bids.FirstOrDefaultAsync(b => b.Id == id && b.BidderId == user.Id);
            var viewModel = new BidViewModel
            {
                AuctionId = id,
                Aukcija = auction,
                MaxBidAmount = auction.Bids.Any() ? auction.Bids.Max(b => b.BidAmount) : (decimal?)null,
                HasExistingBid = existingBid != null

            };
            if (existingBid != null)
			{
				viewModel.Amount = existingBid.BidAmount;
			}
			


			this.FillDropDownValues();
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult CheckAuctionStatus(int id)
        {
            var auction = _context.Aukcijas
                .Include(a => a.Bids)
                .FirstOrDefault(a => a.Id == id);

            if (auction.Status == "Completed")
            {
                return Json(new { isOver = true }); // Auction not found, consider it as over
            }
			if(auction.Status == "Preparing")
			{
				return Json(new { isPreparing = true });
			}

            bool isOver = auction.EndTime <= DateTime.Now;

            return Json(new { isOver });
        }
        [HttpPost]
		[Authorize]
		public async Task<IActionResult> PlaceBid(BidViewModel model)
		{
			if (ModelState.IsValid)
			{
				var auction = _context.Aukcijas.Include(a => a.Article).Include(a => a.Bids).FirstOrDefault(a => a.Id == model.AuctionId);
				if (auction == null)
				{
					return NotFound();
				}

				var user = await _userManager.GetUserAsync(User);
				if (user == null)
				{
					return Unauthorized();
				}

				var highestBid = auction.Bids.OrderByDescending(b => b.BidAmount).FirstOrDefault();
				var highestBidAmount = highestBid?.BidAmount ?? auction.Article.StartingPrice;

				if (model.Amount < auction.Article.StartingPrice || model.Amount <= highestBidAmount)
				{
					TempData["ErrorMessage"] = "Your bid must be higher than the starting bid and the current highest bid.";
					return RedirectToAction("Bid", new { id = model.AuctionId });
				}

				var existingBid = await _context.Bids.Include(b => b.AuctionUser).FirstOrDefaultAsync(b => b.AuctionId == model.AuctionId && b.AuctionUser.Id == user.Id);
				if(existingBid != null)
				{
					existingBid.BidAmount = model.Amount;
					_context.Update(existingBid);
				}
				else
				{
					
					var bid = new Bid
					{
						BidAmount = model.Amount,
						AuctionId = model.AuctionId,
						BidderId = user.Id,
						PaymentMethodId = model.PaymentId
					};
					_context.Add(bid);
				}
				
				await _context.SaveChangesAsync();

				return RedirectToAction("Details", new { id = model.AuctionId });
			}

			return View("Bid");
		}
		[Authorize]
		public IActionResult Edit(int id)
		{
			var model = _context.Aukcijas.Include(c => c.Article).ThenInclude(a => a.Images).FirstOrDefault(c => c.Id == id);
			var viewModel = new AuctionEditViewModel
			{
				AuctionId = model.Id,
				StartTime = model.StartTime,
				EndTime = model.EndTime,
				ArticleId = model.ArticleId,
				Name = model.Article.Name,
				Description = model.Article.Description,
				StartingPrice = model.Article.StartingPrice,
				Images = model.Article.Images
				
			};
			return View(viewModel);
		}
		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Edit(AuctionEditViewModel viewModel)
		{
			if(!ModelState.IsValid)
			{
				return View(viewModel);
			}
			var auction = _context.Aukcijas.Include(a => a.Article).First(a => a.Id == viewModel.AuctionId);
			if(auction == null)
			{
				return NotFound();
			}

			auction.StartTime = viewModel.StartTime;
			auction.EndTime = viewModel.EndTime;
			auction.Article.Name = viewModel.Name;
			auction.Article.Description = viewModel.Description;
			auction.Article.StartingPrice = viewModel.StartingPrice;

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		[Authorize]
		public async Task<IActionResult> Delete(int id)
		{
			var auction = await _context.Aukcijas
				.Include(a => a.Article)
				.Include(a => a.Bids)
				.FirstOrDefaultAsync(a => a.Id == id);

			if (auction == null)
			{
				return NotFound();
			}
			auction.Status = "Cancelled";
			// Remove related bids
			_context.Bids.RemoveRange(auction.Bids);



			// Remove the auction
			_context.Aukcijas.Remove(auction);

			await _context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public async Task<ActionResult> UploadImage(int auctionId, IFormFile file)
		{
            if (file == null)
            {
                return Content("Files not selected");

            }
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var filePath = Path.Combine(folder, uniqueFileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
			
			var article = await _context.Articles.Include(c => c.Images).Include(c => c.Aukcija).FirstOrDefaultAsync(c => c.Aukcija.Id == auctionId);
			article.Images.Add(new Pic { FilePath = "/uploads/" + uniqueFileName, ArticleId = article.Id });


            await _context.SaveChangesAsync();

            return Ok(new { filePath });
        }
		public async Task<IActionResult> GetAttachments(int articleId)
		{
			var attachments = _context.Images.Where(a => a.ArticleId == articleId).ToList();
			ViewBag.articleId = articleId;

			if (attachments == null)
			{
				return NotFound();
			}

			return PartialView("_ImageList", attachments);
		}

		public async Task<IActionResult> GetAttachmentsNoDelete(int articleId)
		{
			var attachments = _context.Images.Where(a => a.ArticleId == articleId).ToList();
			ViewBag.articleId = articleId;

			if (attachments == null)
			{
				return NotFound();
			}

			return PartialView("_ImageListNoDelete", attachments);
		}

		public async Task<IActionResult> DeleteAttachment(int id)
		{
			var attachment = await _context.Images.FindAsync(id);
			if (attachment == null)
			{
				return Json(new { success = false, mmessage = "Image not found" });

			}
			_context.Images.Remove(attachment);
			await _context.SaveChangesAsync();

			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", Path.GetFileName(attachment.FilePath));
			if (System.IO.File.Exists(filePath))
			{
				System.IO.File.Delete(filePath);
			}

			return Json(new { success = true });
		}
		[Authorize]
		public IActionResult EndAuctionEarly(int id)
		{
			var auction = _context.Aukcijas.Include(a => a.Bids).Include(a => a.Article).FirstOrDefault(a => a.Id == id);
			if(auction == null)
			{
				return NotFound();

			}
			var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
			if(auction.Article.SellerId != userId) {
				return Forbid();
			}

			var highestBid = auction.Bids.OrderByDescending(b => b.BidAmount).FirstOrDefault();
			if(highestBid != null) { 
				auction.WinnerId = highestBid.BidderId;
			}
			auction.Status = "Completed";
			auction.EndTime = DateTime.Now;

			_context.SaveChanges();

			return RedirectToAction("Details", new { id = auction.Id });

		}

		[Authorize]
		public IActionResult WonAuctions()
		{
			var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
			var wonAuctions = _context.Aukcijas.Include(a => a.Winner).Where(a => a.WinnerId == userId && a.Status == "Completed").Include(a => a.Article).ToList();
			var model = new WonAuctionsViewModel
			{
				WonAuctions = wonAuctions
			};
			return View(model);

		}
		private void FillDropDownValues()
		{
			var selectItems = new List<SelectListItem>();

			var listItem = new SelectListItem();
			listItem.Text = "--odaberite--";
			listItem.Value = "";

			foreach (var category in _context.PaymentMethods)
			{
				listItem = new SelectListItem(category.Name, category.Id.ToString());
				selectItems.Add(listItem);
			}

			ViewBag.PaymentMethods = selectItems;
		}


    }
	}

