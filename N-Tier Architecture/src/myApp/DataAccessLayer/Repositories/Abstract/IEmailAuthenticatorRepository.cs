using Core.Persistence.Repositories;
using EntitiesLayer.Concrete;

namespace DataAccessLayer.Repositories.Abstract;

public interface IEmailAuthenticatorRepository : IAsyncRepository<EmailAuthenticator>, IRepository<EmailAuthenticator> { }
