using WebApplication1.Models;
using AutoMapper;
using WebApplication1.Models.DTO;

namespace WebApplication1.Profiles;
public class InternProfile : Profile
{
 public InternProfile()
 {
  CreateMap<Intern,InternDTO>();
  CreateMap<InternDTO,Intern>();
  CreateMap<CreateInternDto,Intern>();
  CreateMap<Intern,CreateInternDto>();
  CreateMap<Intern,UpdateInternDto>();
  CreateMap<UpdateInternDto,Intern>();
  
 }   
}