using DataAccessLayer.Repositories.Abstract;
using AutoMapper;
using BusinessLayer.Features.Customers.Models;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using EntitiesLayer.Concrete;
using MediatR;
using static BusinessLayer.Features.Customers.Constants.OperationClaims;
using static EntitiesLayer.Constants.OperationClaims;

namespace BusinessLayer.Features.Customers.Queries.GetListCustomer;

public class GetListCustomerQuery : IRequest<CustomerListModel>//, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public string[] Roles => new[] { ADMIN, CustomerGet };

    public class GetListCustomerQueryHanlder : IRequestHandler<GetListCustomerQuery, CustomerListModel>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetListCustomerQueryHanlder(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerListModel> Handle(GetListCustomerQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Customer> customers = await _customerRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);

            CustomerListModel mappedCustomerListModel = _mapper.Map<CustomerListModel>(customers);
            return mappedCustomerListModel;
        }
    }
}
