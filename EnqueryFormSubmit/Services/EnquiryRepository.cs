using EnqueryFormSubmit.Context;
using EnqueryFormSubmit.Models;
using Microsoft.EntityFrameworkCore;

namespace EnqueryFormSubmit.Services
{
    public class EnquiryRepository : IEnquiryRepository
    {
        private readonly AppDbContext _context;

        public EnquiryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Enquiry>> GetAllAsync()
        {
            return await _context.Enquiries.ToListAsync();
        }

        public async Task<Enquiry> GetByIdAsync(int id)
        {
            return await _context.Enquiries.FindAsync(id);
        }

        public async Task AddAsync(Enquiry enquiry)
        {
            _context.Enquiries.Add(enquiry);
            await _context.SaveChangesAsync();
        }
    }
}
