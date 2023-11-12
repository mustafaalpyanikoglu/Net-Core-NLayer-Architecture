using DataAccessLayer.Repositories.Abstract;
using AutoMapper;
using BusinessLayer.Features.Users.Models;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using EntitiesLayer.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static BusinessLayer.Features.Users.Constants.OperationClaims;
using static EntitiesLayer.Constants.OperationClaims;

namespace BusinessLayer.Features.Users.Queries.GetListUser;

public class GetListUserQuery : IRequest<UserListModel>/*, ISecuredRequest*/
{
    public PageRequest PageRequest { get; set; }
    //public string[] Roles => new[] { Admin, UserGet };

    public class GetListUserQueryHandler : IRequestHandler<GetListUserQuery, UserListModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetListUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserListModel> Handle(GetListUserQuery request, CancellationToken cancellationToken)
        {
            IPaginate<User> users = await _userRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize,
                include: u => u.Include(u => u.UserOperationClaims).ThenInclude(t => t.OperationClaim)
            );


            UserListModel mappedUserListModel = _mapper.Map<UserListModel>(users);
            return mappedUserListModel;

        }
    }
}
