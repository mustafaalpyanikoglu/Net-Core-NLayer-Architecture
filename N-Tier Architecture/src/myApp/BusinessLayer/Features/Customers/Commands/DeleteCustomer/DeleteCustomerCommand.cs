using DataAccessLayer.Repositories.Abstract;
using AutoMapper;
using BusinessLayer.Features.Customers.Dtos;
using BusinessLayer.Features.Customers.Rules;
using Core.Application.Pipelines.Authorization;
using EntitiesLayer.Concrete;
using MediatR;
using static BusinessLayer.Features.Customers.Constants.OperationClaims;
using static EntitiesLayer.Constants.OperationClaims;

namespace BusinessLayer.Features.Customers.Commands.DeleteCustomer;

public class DeleteCustomerCommand : IRequest<DeletedCustomerDto>/*, ISecuredRequest*/
{
    public int Id { get; set; }

    public string[] Roles => new[] { ADMIN, CustomerDelete };

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeletedCustomerDto>
    {
        private readonly IMapper _mapper;
        private readonly CustomerBusinessRules _customerBusinessRules;
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerCommandHandler(IMapper mapper, CustomerBusinessRules customerBusinessRules, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerBusinessRules = customerBusinessRules;
            _customerRepository = customerRepository;
        }

        public async Task<DeletedCustomerDto> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            await _customerBusinessRules.CustomerIdShouldExistWhenSelected(request.Id);

            Customer mappedCustomer = _mapper.Map<Customer>(request);
            Customer deletedCustomer = await _customerRepository.DeleteAsync(mappedCustomer);

            DeletedCustomerDto deletedCustomerDto = _mapper.Map<DeletedCustomerDto>(deletedCustomer);

            return deletedCustomerDto;
        }
    }
}
