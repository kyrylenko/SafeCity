using System.Threading.Tasks;
using SafeCity.Core.Entities;

namespace SafeCity.Core.Repositories
{
    public interface IDonationRepository
    {
        void CreateDonation(Donation donation);

        Task<bool> SaveAsync();
    }
}
