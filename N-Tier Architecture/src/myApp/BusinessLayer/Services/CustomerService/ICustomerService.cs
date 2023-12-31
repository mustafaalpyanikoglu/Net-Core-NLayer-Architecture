﻿using Core.Persistence.Paging;
using DataAccessLayer.Repositories.Abstract;
using EntitiesLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Services.CustomerService;

public interface ICustomerService
{
    Task<List<Customer>> GetListCustomer();
    Task<List<Customer>> GetListCustomerWarehouseCosts();
}

public class CustomerManager : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerManager(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<List<Customer>> GetListCustomer()
    {
        IPaginate<Customer> customers = await _customerRepository.GetListAsync();
        return customers.Items.ToList();
    }

    public async Task<List<Customer>> GetListCustomerWarehouseCosts()
    {
        IPaginate<Customer> customers = await _customerRepository.GetListAsync(include: t => t.Include(t => t.CustomerWarehouseCosts));
        return customers.Items.ToList();
    }
}