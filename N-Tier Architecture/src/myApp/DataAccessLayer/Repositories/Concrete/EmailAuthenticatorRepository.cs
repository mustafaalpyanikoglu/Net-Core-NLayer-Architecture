using Core.Persistence.Repositories;
using DataAccessLayer.Repositories.Abstract;
using EntitiesLayer.Concrete;
using Persistence.Contexts;

namespace DataAccessLayer.Repositories.Concrete;

public class EmailAuthenticatorRepository : EfRepositoryBase<EmailAuthenticator, BaseDbContext>, IEmailAuthenticatorRepository
{
    public EmailAuthenticatorRepository(BaseDbContext context)
        : base(context) { }
}

