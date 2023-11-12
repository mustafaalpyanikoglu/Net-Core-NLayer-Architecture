using DataAccessLayer.Repositories.Abstract;
using BusinessLayer.Features.CustomerWarehouseCosts.Constants;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using EntitiesLayer.Concrete;

namespace BusinessLayer.Features.CustomerWarehouseCosts.Rules;

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
