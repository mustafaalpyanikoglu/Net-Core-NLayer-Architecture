using BusinessLayer.Constants.OperationClaims;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccessLayer.Repositories.Abstract;
using EntitiesLayer.Concrete;

namespace BusinessLayer.BusinessRules;

public class WarehouseBusinessRules : BaseBusinessRules
{
    private readonly IWarehouseRepository _warehouseRepository;

    public WarehouseBusinessRules(IWarehouseRepository warehouseRepository)
    {
        _warehouseRepository = warehouseRepository;
    }

    public async Task WarehouseIdShouldExistWhenSelected(int? id)
    {
        Warehouse? result = await _warehouseRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException(OperationClaimMessages.OperationClaimNotFound);
    }

}
