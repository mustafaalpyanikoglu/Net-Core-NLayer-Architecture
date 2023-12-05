using Core.Application.Algorithms;

namespace BusinessLayer.Services.LocationSolverService;

public interface ILocationSolverService
{
    Task<BestResult> SimaulatedAnnealingQuickSortSolver();
}
