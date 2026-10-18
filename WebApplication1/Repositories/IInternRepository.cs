using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public interface IInternRepository
{
    Intern GetWithId(int id);
    List<Intern> GetAll([FromQuery]GetQuery getQuery);
    Intern Post(Intern intern);
    Intern Put(Intern intern);
    Intern Delete(Intern intern);
}