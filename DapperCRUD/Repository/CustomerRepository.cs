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

        public async Task Create(Customer _Customer)
        {
            var query = "INSERT INTO " + typeof(Customer).Name + " (Name, Family,Phone,NationalCode,Mobile) VALUES (@Name, @Family,@Phone,@NationalCode,@Mobile)";
            var parameters = new DynamicParameters();
            parameters.Add("Name", _Customer.Name, DbType.String);
            parameters.Add("Family", _Customer.Family, DbType.String);
            parameters.Add("Phone", _Customer.Phone, DbType.Int64);
            parameters.Add("NationalCode", _Customer.NationalCode, DbType.Int64);
            parameters.Add("Mobile", _Customer.Mobile, DbType.Int64);

            using var connection = _context.CreateConnection();

            await connection.ExecuteAsync(query, parameters);
        }

        public async Task Delete(int id)
        {
            var query = "DELETE FROM " + typeof(Customer).Name + " WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        public async Task<List<Address>> GetAddressesAsync(int id)
        {
            var query = "select * from Address as a inner join Customer on a.CustomerId = Customer.Id";
            using var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<Address>(query);
            return result.ToList();
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
            var query = "select * from Customer WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<CustomerDto>(query, new { id });
                return result;
            }
        }

        public async Task Update(Customer _Customer)
        {
            var query = "UPDATE Customer SET Name = @Name, Family =@Family ,Phone = @Phone,NationalCode = @NationalCode,Mobile=@Mobile    WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", _Customer.Id, DbType.Int64);
            parameters.Add("Name", _Customer.Name, DbType.String);
            parameters.Add("Family", _Customer.Family, DbType.String);
            parameters.Add("Phone", _Customer.Phone, DbType.Int64);
            parameters.Add("NationalCode", _Customer.NationalCode, DbType.Int64);
            parameters.Add("Mobile", _Customer.Mobile, DbType.Int64);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
