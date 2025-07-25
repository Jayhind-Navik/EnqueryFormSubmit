﻿using EnqueryFormSubmit.CustomValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace EnqueryFormSubmit.Models
{

    public class Enquiry
    {
        public int EnquiryId { get; set; }

        [Required(ErrorMessage = "Contact Person is required")]
        public string ContactPerson { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Format")]
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

        public string FromAddress { get; set; } 

        public string ToAddress { get; set; } 

        [Required]
        [DataType(DataType.Date)]
        public DateTime EnquiryDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime SurveyDateTime { get; set; }

        public string EnquiryNo { get; set; } 
    }
}
