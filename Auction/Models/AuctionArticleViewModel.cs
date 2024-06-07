using Auction.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace Auction.Web.Models
{
	public class AuctionArticleViewModel
	{
		

		[Required]
		public string Name { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		[DataType(DataType.Currency)]
		public decimal StartingPrice { get; set; }
        [Required(ErrorMessage = "Set a start date")]
        [AuctionDateValidation]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Set an end date")]
        [AuctionDateValidation]
        public DateTime EndTime { get; set; }



    }
    public class AuctionDateValidationAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var auction = (AuctionArticleViewModel)validationContext.ObjectInstance;

            if (auction.StartTime <= DateTime.Now)
            {
                return new ValidationResult("Start date cannot be before the current date.");
            }

            if (auction.EndTime <= auction.StartTime)
            {
                return new ValidationResult("End date cannot be before the start date.");
            }

            return ValidationResult.Success;
        }
    }
}
