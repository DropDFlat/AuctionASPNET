using Auction.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Auction.Model;
using Microsoft.Build.Experimental.ProjectCache;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Auction.Web.Controllers
{
	[Route("api/auction")]
	[ApiController]
	public class AuctionApiController(AuctionDbContext _context, UserManager<ApplicationUser> _userManager) : Controller
	{
		public IActionResult Get()
		{
			var auctionQuery = _context.Aukcijas.Include( a => a.Article).AsQueryable();
			var dtos = auctionQuery.Select(MapFromAuction).ToList();

			return Ok(dtos);
		}
		[Route("{id}")]
		public IActionResult Get(int id)
		{
			var auctionQuery = _context.Aukcijas.Include(a => a.Article).Where(a => a.Id == id).FirstOrDefault();
			var dto = MapFromAuction(auctionQuery);

			return Ok(dto);
		}
		[HttpPost]
		[Authorize]
		public async Task<ActionResult<ArticleDTO>> Post([FromBody] ArticleDTO model)
		{
			if (model == null)
			{
				return BadRequest(ModelState);
			}

			var user = await _userManager.GetUserAsync(User);
			var article = new Article
			{
				Name = model.Name,
				StartingPrice = model.StartingPrice,
				SellerId = user.Id,
				Seller = user,
				Description = model.Description

			};

			_context.Articles.Add(article);
			_context.SaveChanges();

			return CreatedAtAction(nameof(Get), new {id = article.Id}, article);
		}

		private AuctionDTO MapFromAuction(Aukcija auction)
		{
			var dto = new AuctionDTO();
			dto.Id = auction.Id;
			dto.EndDate = auction.EndTime;
			dto.StartDate = auction.StartTime;
			dto.Status = auction.Status;
			ArticleDTO articleDTO = new ArticleDTO();
			articleDTO.Id = auction.Article.Id;
			articleDTO.Name = auction.Article.Name;
			articleDTO.Description = auction.Article.Description;
			articleDTO.StartingPrice = auction.Article.StartingPrice;
			dto.Article = articleDTO;


			return dto;

		}
	}
}
