using Health.Domain.Entities;
using Health.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Health.Infra.Repository;

public class AuthRepository
{
    private readonly DataContext _dataContext;

    public AuthRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task<User?> AuthUser(string? email, string? password)
    {
        var existingLogin = await _dataContext.Users
            .FirstOrDefaultAsync(e => e.Email == email && e.Password == password);
        return existingLogin;
    }
}