using EnqueryFormSubmit.CustomValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace EnqueryFormSubmit.Models
{
    public class Enquiry
    {
        public int EnquiryId { get; set; }
        [BindNever] // Prevent model binding from touching this field
        [ScaffoldColumn(false)]
        public string EnquiryNo { get; set; }

        [Required]
        [MinLength(4,ErrorMessage = " ContactPerson must be with a minimum length of '4'.")]
        public string ContactPerson { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FromCountry { get; set; }

        [Required]
        public string FromState { get; set; }

        [Required]
        public string FromCity { get; set; }

        [Required]
        public string ToCountry { get; set; }

        [Required]
        public string ToState { get; set; }

        [Required]
        public string ToCity { get; set; }

        [Required]
        public string FromAddress { get; set; }

        [Required]
        public string ToAddress { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage = "Date must be in the future.")]
        public DateTime EnquiryDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime SurveyDateTime { get; set; }
    }
}
