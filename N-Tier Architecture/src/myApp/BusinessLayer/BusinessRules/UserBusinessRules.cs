using Core.Security.Hashing;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using System.Security.Claims;
using DataAccessLayer.Repositories.Abstract;
using EntitiesLayer.Concrete;
using BusinessLayer.Constants.Users;

namespace BusinessLayer.BusinessRules;

public class UserBusinessRules : BaseBusinessRules
{
    private readonly IUserRepository _userDal;

    public UserBusinessRules(IUserRepository userDal)
    {
        _userDal = userDal;
    }

    public async Task UserIdMustBeAvailable(int id)
    {
        // Checks if a user with the provided ID exists, and throws an exception if it doesn't.
        User? result = await _userDal.GetAsync(t => t.Id == id);
        if (result == null) throw new BusinessException(UserMessages.UserNotFound);
    }

    public async Task ShouldNotHaveUserCart(int userId)
    {
        // Checks if a user with the provided ID has a user cart, and throws an exception if they do.
        User? result = await _userDal.GetAsync(t => t.Id == userId);
        if (result != null) throw new BusinessException(UserMessages.ThisUserHasAUserCart);
    }

    public Task UserMustBeLoggedIn(List<Claim>? claims)
    {
        if (claims is null || claims.Count <= 0) throw new BusinessException(UserMessages.UserIsNotLoggedIn);
        return Task.CompletedTask;
    }

    public async Task ShouldNotHavePuser(int userId)
    {
        // Checks if a user with the provided ID has a purse, and throws an exception if they do.
        User? result = await _userDal.GetAsync(t => t.Id == userId);
        if (result != null) throw new BusinessException(UserMessages.ThisUserHasAPurse);
    }

    public async Task UserEmailMustBeAvailable(string email)
    {
        // Checks if a user with the provided email exists, and throws an exception if they don't.
        User? result = await _userDal.GetAsync(t => t.Email == email);
        if (result == null) throw new BusinessException(UserMessages.UserNotFound);
    }

    public async Task UserEmailMustNotExist(string email)
    {
        // Checks if a user with the provided email doesn't exist, and throws an exception if they do.
        User? result = await _userDal.GetAsync(t => t.Email == email);
        if (result != null) throw new BusinessException(UserMessages.UserEmailAvaliable);
    }

    public async Task UserMustBeAvailable()
    {
        // Checks if there is at least one user available, and throws an exception if there are none.
        List<User>? results = _userDal.GetAll();
        if (results.Count <= 0) throw new BusinessException(UserMessages.UserNotFound);
    }

    public Task UserShouldBeExist(User? user)
    {
        // Checks if a user exists, and throws an exception if they don't.
        if (user is null) throw new BusinessException(UserMessages.UserDontExists);
        return Task.CompletedTask;
    }

    public Task UserPasswordShouldBeMatch(User user, string password)
    {
        // Checks if the provided password matches the user's password, and throws an exception if they don't match.
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException(UserMessages.PasswordDontMatch);
        return Task.CompletedTask;
    }

}