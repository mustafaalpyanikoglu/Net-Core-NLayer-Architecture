using EntitiesLayer.Concrete;

namespace BusinessLayer.Services.CustomerWarehouseCostService;

public interface ICustomerWarehouseCostService
{
    Task<List<CustomerWarehouseCost>> GetWarehouseCustomerCosts();
    Task<List<CustomerWarehouseCost>> GetListCustomerWarehouseCosts();
}
