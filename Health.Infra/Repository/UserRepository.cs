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

    public async Task<List<User?>> Select()
    {
        var user = await _dataContext.Users.ToListAsync();
        return user;
    }

    public async Task<User?> Select(int id)
    {
        var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        return user;
    }

    public async Task<User> Update(int id, User obj)
    {
        var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        user!.Email = obj.Email;
        user.Name = obj.Name;
        user.Password = obj.Password;
        await _dataContext.SaveChangesAsync();
        return user;
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