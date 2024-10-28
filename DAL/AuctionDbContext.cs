using Auction.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL
{
    public class AuctionDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuctionDbContext(DbContextOptions<AuctionDbContext> options)
            : base(options)
        {

        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Aukcija> Aukcijas { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Pic> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
			/*modelBuilder.Entity<Article>()
                .HasOne(i => i.Seller)
                .WithMany(u => u.articles)
                .HasForeignKey(i => i.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Aukcija>()
                .HasOne(a => a.Article)
                .WithOne(i => i.aukcija)
                .HasForeignKey<Aukcija>(a => a.ArticleId)
                .OnDelete(DeleteBehavior.Restrict);

            // Bid -> Auction
            modelBuilder.Entity<Bid>()
                .HasOne(b => b.Auction)
                .WithMany(a => a.Bids)
                .HasForeignKey(b => b.AuctionId)
                .OnDelete(DeleteBehavior.Restrict);*/
			modelBuilder.Entity<Aukcija>()
			.HasOne(a => a.Winner)
			.WithMany()
			.HasForeignKey(a => a.WinnerId);

			modelBuilder.Entity<Article>()
        .Property(i => i.StartingPrice)
        .HasColumnType("decimal(10, 2)");


            modelBuilder.Entity<PaymentMethod>().HasData(new PaymentMethod { Id = 1, Name = "Paypal" });
            modelBuilder.Entity<PaymentMethod>().HasData(new PaymentMethod  { Id = 2, Name = "Credit Card" });
            modelBuilder.Entity<PaymentMethod>().HasData(new PaymentMethod { Id = 3, Name = "BTC" });

        }
    }
}
