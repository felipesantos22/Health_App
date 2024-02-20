using Health.Domain.Entities;
using Health.Domain.Interfaces;
using Health.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Health.Infra.Repository;

public class UserRepository:IBaseRepository<User>
{
    private readonly DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<User> Insert(User obj)
    {
        await _dataContext.Users.AddAsync(obj);
        await _dataContext.SaveChangesAsync();
        return obj;
    }

    public async Task<IList<User>> Select()
    {
        var user = await _dataContext.Users.ToListAsync();
        return user;
    }

    public Task<User> Select(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User> Update(int id, User obj)
    {
        throw new NotImplementedException();
    }

    public Task<User> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User> SelectName(string name)
    {
        throw new NotImplementedException();
    }
}