using DataAccessLayer.Repositories.Abstract;
using AutoMapper;
using BusinessLayer.Features.OperationClaims.Rules;
using BusinessLayer.Features.UserOperationClaims.Dtos;
using BusinessLayer.Features.UserOperationClaims.Rules;
using BusinessLayer.Features.Users.Rules;
using Core.Application.Pipelines.Authorization;
using EntitiesLayer.Concrete;
using MediatR;
using static BusinessLayer.Features.UserOperationClaims.Constants.OperationClaims;
using static EntitiesLayer.Constants.OperationClaims;

namespace BusinessLayer.Features.UserOperationClaims.Commands.CreateUserOperationClaim;

public class CreateUserOperationClaimCommand : IRequest<CreateUserOperationClaimDto>//, ISecuredRequest
{
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }

    public string[] Roles => new[] { ADMIN, UserOperationClaimAdd };
    public class CreateUserOperationClaimCommandHanlder : IRequestHandler<CreateUserOperationClaimCommand, CreateUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimDal;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

        public CreateUserOperationClaimCommandHanlder(IUserOperationClaimRepository userOperationClaimDal, IMapper mapper, UserBusinessRules userBusinessRules, OperationClaimBusinessRules operationClaimBusinessRules, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
        {
            _userOperationClaimDal = userOperationClaimDal;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
            _operationClaimBusinessRules = operationClaimBusinessRules;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        }

        public async Task<CreateUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            await _userOperationClaimBusinessRules.TheUserAlreadyHasARole(request.UserId);

            UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);
            UserOperationClaim createdUserOperationClaim = await _userOperationClaimDal.AddAsync(mappedUserOperationClaim);
            CreateUserOperationClaimDto createUserOperationClaimDto = _mapper.Map<CreateUserOperationClaimDto>(createdUserOperationClaim);

            return createUserOperationClaimDto;

        }
    }
}
