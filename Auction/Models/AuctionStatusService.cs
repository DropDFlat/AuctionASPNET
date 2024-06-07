using Auction.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Auction.Web.Models
{
	public class AuctionStatusService : IHostedService, IDisposable
	{
		private Timer _timer;
		private readonly IServiceScopeFactory _scopeFactory;

		public AuctionStatusService(IServiceScopeFactory scopeFactory)
		{
			_scopeFactory = scopeFactory;
		}

		public Task StartAsync(CancellationToken cancellationToken)
		{
			_timer = new Timer(UpdateAuctionStatuses, null, TimeSpan.Zero, TimeSpan.FromMinutes(1)); // Run every minute
			return Task.CompletedTask;
		}

		private void UpdateAuctionStatuses(object state)
		{
			using (var scope = _scopeFactory.CreateScope())
			{
				var context = scope.ServiceProvider.GetRequiredService<AuctionDbContext>(); // Replace with your DbContext

				var currentDate = DateTime.UtcNow;
				var auctionsToComplete = context.Aukcijas.Include(a => a.Bids)
					.Where(a => a.EndTime <= currentDate && a.Status != "Completed" && a.Status != "Cancelled")
					.ToList();
	
				foreach (var auction in auctionsToComplete)
				{
					var highestBid = auction.Bids.OrderByDescending(b => b.BidAmount).FirstOrDefault();
					if (highestBid != null)
					{
						auction.WinnerId = highestBid.BidderId;
					}
					auction.Status = "Completed";
				}
				var auctionsToStart = context.Aukcijas
					.Where(a => a.StartTime <= currentDate && (a.Status != "Completed" && a.Status != "Active"))
					.ToList();
				foreach(var auction in auctionsToStart)
				{
					auction.Status = "Active";
				}

				context.SaveChanges();
			}
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			_timer?.Change(Timeout.Infinite, 0);
			return Task.CompletedTask;
		}

		public void Dispose()
		{
			_timer?.Dispose();
		}
	}
}
