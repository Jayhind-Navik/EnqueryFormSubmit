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
        public async Task<IActionResult> Create(Enquiry enquiry)
        {
            ModelState.Remove(nameof(enquiry.EnquiryNo));
            if (!ModelState.IsValid)
                return View(enquiry);

            // Generate EnquiryNo
            enquiry.EnquiryNo = GenerateEnquiryNo(enquiry);

            await _repository.AddAsync(enquiry);
            return RedirectToAction("Success");
        }

        private string GenerateEnquiryNo(Enquiry enquiry)
        {
            string namePart = enquiry.ContactPerson.Substring(0, 4).ToUpper();
            string countryPart = enquiry.FromCountry.Substring(0, 2).ToUpper();
            string datePart = DateTime.Now.ToString("yyyyMMdd");
            return $"{namePart}{countryPart}{datePart}";
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
