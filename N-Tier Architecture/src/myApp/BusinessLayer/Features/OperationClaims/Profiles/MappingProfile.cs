using AutoMapper;
using BusinessLayer.Features.OperationClaims.Commands.CreateOperationClaim;
using BusinessLayer.Features.OperationClaims.Commands.DeleteOperationClaim;
using BusinessLayer.Features.OperationClaims.Commands.UpdateOperationClaim;
using BusinessLayer.Features.OperationClaims.Dtos;
using BusinessLayer.Features.OperationClaims.Models;
using Core.Persistence.Paging;
using EntitiesLayer.Concrete;

namespace BusinessLayer.Features.OperationClaims.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();
        CreateMap<OperationClaim, DeleteOperationClaimCommand>().ReverseMap();
        CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();
        CreateMap<OperationClaim, CreatedOperationClaimDto>().ReverseMap();
        CreateMap<OperationClaim, DeletedOperationClaimDto>().ReverseMap();
        CreateMap<OperationClaim, UpdatedOperationClaimDto>().ReverseMap();
        CreateMap<OperationClaim, OperationClaimDto>().ReverseMap();
        CreateMap<OperationClaim, OperationClaimListDto>().ReverseMap();
        CreateMap<IPaginate<OperationClaim>, OperationClaimListModel>().ReverseMap();
    }
}
