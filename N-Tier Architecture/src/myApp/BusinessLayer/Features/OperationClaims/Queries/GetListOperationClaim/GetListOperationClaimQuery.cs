using DataAccessLayer.Repositories.Abstract;
using AutoMapper;
using BusinessLayer.Features.OperationClaims.Models;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using EntitiesLayer.Concrete;
using MediatR;
using static BusinessLayer.Features.OperationClaims.Constants.OperationClaims;
using static EntitiesLayer.Constants.OperationClaims;

namespace BusinessLayer.Features.OperationClaims.Queries.GetListOperationClaim;

public class GetListOperationClaimQuery : IRequest<OperationClaimListModel>//, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    //public string[] Roles => new[] { Admin, OperationClaimGet };

    public class GetListOperationClaimQueryHanlder : IRequestHandler<GetListOperationClaimQuery, OperationClaimListModel>
    {
        private readonly IOperationClaimRepository _operationClaimDal;
        private readonly IMapper _mapper;

        public GetListOperationClaimQueryHanlder(IOperationClaimRepository operationClaimDal, IMapper mapper)
        {
            _operationClaimDal = operationClaimDal;
            _mapper = mapper;
        }

        public async Task<OperationClaimListModel> Handle(GetListOperationClaimQuery request, CancellationToken cancellationToken)
        {
            IPaginate<OperationClaim> operationClaims = await _operationClaimDal.GetListAsync(index: request.PageRequest.Page,
                                                                               size: request.PageRequest.PageSize);

            // Maps the operation claims to an OperationClaimListModel object
            OperationClaimListModel mappedOperationClaimListModel = _mapper.Map<OperationClaimListModel>(operationClaims);

            return mappedOperationClaimListModel;
        }
    }
}
