﻿using DataAccessLayer.Repositories.Abstract;
using AutoMapper;
using BusinessLayer.Features.Users.Models;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using EntitiesLayer.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static BusinessLayer.Features.Users.Constants.OperationClaims;
using static EntitiesLayer.Constants.OperationClaims;

namespace BusinessLayer.Features.Users.Queries.GetListUserByDynamic;

public class GetListUserByDynamicQuery : IRequest<UserListModel>/*, ISecuredRequest*/
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery Dynamic { get; set; }
    //public string[] Roles => new[] { Admin, UserGet };

    public class GetListUserByDynamicQueryHandler : IRequestHandler<GetListUserByDynamicQuery, UserListModel>
    {
        private readonly IUserRepository _userDal;
        private readonly IMapper _mapper;

        public GetListUserByDynamicQueryHandler(IUserRepository userDal, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
        }

        public async Task<UserListModel> Handle(GetListUserByDynamicQuery request, CancellationToken cancellationToken)
        {
            IPaginate<User> userOperationClaims = await _userDal.GetListByDynamicAsync(
                request.Dynamic,
                include: u => u.Include(u => u.UserOperationClaims).ThenInclude(t => t.OperationClaim),
                request.PageRequest.Page,
                request.PageRequest.PageSize);

            // Mapping the paginated user list to a UserListModel object
            UserListModel mappedUserListModel = _mapper.Map<UserListModel>(userOperationClaims);

            // Returning the mapped user list model
            return mappedUserListModel;

        }
    }
}
