using Dapper;
using DapperCRUD.Data;
using DapperCRUD.Models;
using System.Data;
using static Dapper.SqlMapper;

namespace DapperCRUD.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDapperContext _context;
        public CustomerRepository(IDapperContext context)
        {
            _context = context;
        }

        public Task Create(Customer _Customer)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CustomerDto>> GetAllAsync()
        {

            var query = "select * from customer";
            using var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<CustomerDto>(query);
            return result.ToList();

        }

        public async Task<CustomerDto> GetByIdAsync(int id)
        {
            var query = "select br.*,b.Name bankname from Branch as br join Bank as b on b.Id=br.BankId  WHERE br.Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<CustomerDto>(query, new { id });
                return result;
            }
        }

        public Task Update(Customer _Customer)
        {
            throw new NotImplementedException();
        }
    }
}
