using WebApplication1.Models;

namespace WebApplication1.Repositories;

public interface IInternRepository
{
    Task<Intern?> GetWithId(int id);
    Task<List<Intern>> GetAll(GetQuery getQuery);
    Task AddAsync(Intern intern);
    void Update(Intern intern);
    void Delete(Intern intern);
    Task<bool> SaveChangesAsync();
}