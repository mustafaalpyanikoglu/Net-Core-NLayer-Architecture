using BusinessLayer.Services.CustomerService;
using BusinessLayer.Services.WarehouseService;
using Core.Application.Algorithms;
using Core.Utilities.Abstract;
using EntitiesLayer.Concrete;

namespace BusinessLayer.Services.LocationSolverService;

public class LocationSolverManager : ILocationSolverService
{
    private readonly ISimulatedAnnealing _simulatedAnnealing;
    private readonly ICustomerService _customerService;
    private readonly IWarehouseService _warehouseService;

    public LocationSolverManager(
        ISimulatedAnnealing simulatedAnnealing,
        ICustomerService customerService,
        IWarehouseService warehouseService)
    {
        _simulatedAnnealing = simulatedAnnealing;
        _customerService = customerService;
        _warehouseService = warehouseService;
    }

    public async Task<BestResult> SimaulatedAnnealingQuickSortSolver()
    {
        List<Customer> customers = await _customerService.GetListCustomerWarehouseCosts();
        List<Warehouse> warehouses = await _warehouseService.GetListWarehouse();

        IDataResult<BestResult> bestResult = _simulatedAnnealing.SolveWarehouseLocationProblem(
            customers,
            warehouses
            );
        return bestResult.Data;
    }
}