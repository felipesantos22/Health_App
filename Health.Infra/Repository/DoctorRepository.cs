using Health.Domain.Entities;
using Health.Domain.Interfaces;
using Health.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Health.Infra.Repository;

public class DoctorRepository: IBaseRepository<Doctor>
{
    private readonly DataContext _dataContext;

    public DoctorRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Doctor> Insert(Doctor obj)
    {
        await _dataContext.Doctors.AddAsync(obj);
        await _dataContext.SaveChangesAsync();
        return obj;
    }

    public async Task<List<Doctor?>> Select()
    {
        var doctors = await _dataContext.Doctors.ToListAsync();
        return doctors;
    }

    public Task<Doctor> Select(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Doctor> Update(int id, Doctor obj)
    {
        throw new NotImplementedException();
    }

    public Task<Doctor> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Doctor> SelectName(string name)
    {
        throw new NotImplementedException();
    }
}