using BusinessLayer.Constants.CustomerWarehouseCosts;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccessLayer.Repositories.Abstract;
using EntitiesLayer.Concrete;

namespace BusinessLayer.BusinessRules;

public class CustomerWarehouseCostBusinessRules : BaseBusinessRules
{
    private readonly ICustomerWarehouseCostRepository _customerWarehouseCostRepository;

    public CustomerWarehouseCostBusinessRules(ICustomerWarehouseCostRepository customerWarehouseCostRepository)
    {
        _customerWarehouseCostRepository = customerWarehouseCostRepository;
    }

    public async Task CustomerWarehouseCostIdShouldExistWhenSelected(int? id)
    {
        CustomerWarehouseCost? result = await _customerWarehouseCostRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException(CustomerWarehouseCostMessages.CustomerWarehouseCostNotFound);
    }

}
