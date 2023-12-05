using Core.Persistence.Paging;
using DataAccessLayer.Repositories.Abstract;
using EntitiesLayer.Concrete;

namespace BusinessLayer.Services.WarehouseService;

public interface IWarehouseService
{
    Task<List<Warehouse>> GetListWarehouse();
}

public class WarehouseManager : IWarehouseService
{
    private readonly IWarehouseRepository _warehouseRepository;

    public WarehouseManager(IWarehouseRepository warehouseRepository)
    {
        _warehouseRepository = warehouseRepository;
    }

    public async Task<List<Warehouse>> GetListWarehouse()
    {
        IPaginate<Warehouse> warehouses = await _warehouseRepository.GetListAsync();
        return warehouses.Items.ToList();
    }
}