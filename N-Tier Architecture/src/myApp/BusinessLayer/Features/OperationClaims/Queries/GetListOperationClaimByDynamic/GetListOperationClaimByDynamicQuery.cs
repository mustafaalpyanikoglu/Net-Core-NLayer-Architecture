using DataAccessLayer.Repositories.Abstract;
using AutoMapper;
using BusinessLayer.Features.OperationClaims.Models;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using EntitiesLayer.Concrete;
using MediatR;
using static BusinessLayer.Features.OperationClaims.Constants.OperationClaims;
using static EntitiesLayer.Constants.OperationClaims;

namespace BusinessLayer.Features.OperationClaims.Queries.GetListOperationClaimByDynamic;

public class GetListOperationClaimByDynamicQuery : IRequest<OperationClaimListModel>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery Dynamic { get; set; }
    public string[] Roles => new[] { ADMIN, OperationClaimGet };

    public class GetListOperationClaimByDynamicQueryHandler : IRequestHandler<GetListOperationClaimByDynamicQuery, OperationClaimListModel>
    {
        private readonly IOperationClaimRepository _operationClaimDal;
        private readonly IMapper _mapper;

        public GetListOperationClaimByDynamicQueryHandler(IOperationClaimRepository operationClaimDal, IMapper mapper)
        {
            _operationClaimDal = operationClaimDal;
            _mapper = mapper;
        }

        public async Task<OperationClaimListModel> Handle(GetListOperationClaimByDynamicQuery request, CancellationToken cancellationToken)
        {
            IPaginate<OperationClaim> operationClaims = await _operationClaimDal.GetListByDynamicAsync(
                                  request.Dynamic,
                                  null,
                                  request.PageRequest.Page,
                                  request.PageRequest.PageSize);

            // Maps the operation claims to an OperationClaimListModel object
            OperationClaimListModel mappedOperationClaimListModel = _mapper.Map<OperationClaimListModel>(operationClaims);

            return mappedOperationClaimListModel;

        }
    }
}
