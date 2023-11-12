using BusinessLayer.Constants.OperationClaims;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccessLayer.Repositories.Abstract;
using EntitiesLayer.Concrete;

namespace BusinessLayer.BusinessRules;

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
