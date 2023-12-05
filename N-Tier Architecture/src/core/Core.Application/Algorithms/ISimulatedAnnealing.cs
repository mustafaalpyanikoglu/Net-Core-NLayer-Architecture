using Core.Utilities.Abstract;
using EntitiesLayer.Concrete;

namespace Core.Application.Algorithms;

public interface ISimulatedAnnealing
{
    IDataResult<BestResult> SolveWarehouseLocationProblem(List<Customer> customers, List<Warehouse> warehouses);
}
