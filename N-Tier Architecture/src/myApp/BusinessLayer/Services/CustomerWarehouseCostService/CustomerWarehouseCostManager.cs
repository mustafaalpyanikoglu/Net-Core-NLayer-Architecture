using Core.Persistence.Paging;
using DataAccessLayer.Repositories.Abstract;
using EntitiesLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Services.CustomerWarehouseCostService;

public class CustomerWarehouseCostManager : ICustomerWarehouseCostService
{
    private readonly ICustomerWarehouseCostRepository _customerWarehouseCostRepository;

    public CustomerWarehouseCostManager(ICustomerWarehouseCostRepository customerWarehouseCostRepository)
    {
        _customerWarehouseCostRepository = customerWarehouseCostRepository;
    }

    public async Task<List<CustomerWarehouseCost>> GetWarehouseCustomerCosts()
    {
        IPaginate<CustomerWarehouseCost> warehouses = await _customerWarehouseCostRepository.GetListAsync(
                index: 0,
                size: 999,
                include: p => p.Include(t => t.Customer).Include(t => t.Warehouse));

        return warehouses.Items.ToList();

    }

    public async Task<List<CustomerWarehouseCost>> GetListCustomerWarehouseCosts()
    {
        IPaginate<CustomerWarehouseCost> warehouses = await _customerWarehouseCostRepository.GetListAsync();

        return warehouses.Items.ToList();

    }
}
