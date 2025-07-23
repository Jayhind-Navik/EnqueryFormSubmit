using EnqueryFormSubmit.Models;
using EnqueryFormSubmit.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnqueryFormSubmit.Controllers
{
    public class EnquiryController : Controller
    {
        private readonly IEnquiryRepository _repository;

        public EnquiryController(IEnquiryRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Enquiry model)
        {
           ModelState.Remove(nameof(model.EnquiryNo));
            if (!ModelState.IsValid)
                return View(model);
            if (ModelState.IsValid)
            {
                // Validation for dates
                if (model.EnquiryDate < DateTime.Today)
                {
                    ModelState.AddModelError("EnquiryDate", "Enquiry date cannot be in the past.");
                    return View(model);
                }

                if (model.SurveyDateTime < DateTime.Today || model.SurveyDateTime < model.EnquiryDate || model.SurveyDateTime > DateTime.Today.AddDays(30))
                {
                    ModelState.AddModelError("SurveyDateTime", "Survey date must be between enquiry date and 30 days from today.");
                    return View(model);
                }
            }
                // Generate EnquiryNo
                model.EnquiryNo = GenerateEnquiryNo(model);

            await _repository.AddAsync(model);
            return RedirectToAction("Success");
        }

        private string GenerateEnquiryNo(Enquiry enquiry)
        {
            //string namePart = enquiry.ContactPerson.Substring(0, 4).ToUpper();
            //string countryPart = enquiry.FromCountry.Substring(0, 2).ToUpper();
            //string datePart = DateTime.Now.ToString("yyyyMMdd");
            //return $"{namePart}{countryPart}{datePart}";

            // EnquiryNo Generation
            string namePart = enquiry.ContactPerson.Length >= 4 ? enquiry.ContactPerson.Substring(0, 4).ToUpper() : enquiry.ContactPerson.ToUpper();
            string fromCountryPart = enquiry.FromCountry.Length >= 2 ? enquiry.FromCountry.Substring(0, 2).ToUpper() : enquiry.FromCountry.ToUpper();
            string toCountryPart = enquiry.ToCountry.Length >= 2 ? enquiry.ToCountry.Substring(0, 2).ToUpper() : enquiry.ToCountry.ToUpper();
            string datePart = DateTime.Now.ToString("yyyyMMdd");
            return $"{namePart}/{fromCountryPart}/{toCountryPart}/{datePart}";
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
