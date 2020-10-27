using System;
using System.Threading.Tasks;
using SafeCity.Core.Entities;

namespace SafeCity.Core.Repositories
{
    public class DonationRepository: IDonationRepository
    {
        private readonly SafeCityContext _context;

        public DonationRepository(SafeCityContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }
        public void CreateDonation(Donation project)
        {
            _context.Donations.AddAsync(project);
        }
        //TODO: extract to base abstract Repository
        public async Task<bool> SaveAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result >= 0;
        }
    }
}
