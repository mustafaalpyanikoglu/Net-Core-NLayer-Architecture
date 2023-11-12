using DataAccessLayer.Repositories.Abstract;
using BusinessLayer.Features.OperationClaims.Constants;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using EntitiesLayer.Concrete;

namespace BusinessLayer.Features.Customers.Rules;

public class CustomerBusinessRules : BaseBusinessRules
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerBusinessRules(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task CustomerIdShouldExistWhenSelected(int? id)
    {
        Customer? result = await _customerRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException(OperationClaimMessages.OperationClaimNotFound);
    }

}
