using DapperCRUD.Models;

namespace DapperCRUD.Repository
{
    public interface IAddressRepository
    {
        Task<AddressDto> GetByAddres(int id);
        Task Create(Address _address);
        Task Update(Address _address);
        Task Delete(int id);
    }
}
