using EnqueryFormSubmit.Models;

namespace EnqueryFormSubmit.Services
{
    public interface IEnquiryRepository
    {
        Task<IEnumerable<Enquiry>> GetAllAsync();
        Task<Enquiry> GetByIdAsync(int id);
        Task AddAsync(Enquiry enquiry);
    }
}
