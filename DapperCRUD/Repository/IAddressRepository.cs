using DapperCRUD.Models;

namespace DapperCRUD.Repository
{
    public interface IAddressRepository
    {
        Task<AddressDto> GetByAddres(int id);
        Task Create(Customer _Customer);
        Task Update(Customer _Customer);
        Task Delete(int id);
    }
}
