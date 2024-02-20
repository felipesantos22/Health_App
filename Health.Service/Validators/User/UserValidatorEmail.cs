using Health.Infra.Context;

namespace Health.Service.Validators.User;

public class UserValidatorEmail
{
    private readonly DataContext _dataContext;

    public UserValidatorEmail(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public bool UserNameExists(string? email)
    {
        return _dataContext.Users.Any(n => n.Email == email);
    }
}