﻿using DapperCRUD.Models;

namespace DapperCRUD.Repository
{
    public interface ICustomerRepository
    {
        Task<List<CustomerDto>> GetAllAsync();
     
  
    }
}
