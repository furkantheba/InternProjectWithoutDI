using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.DTO;

namespace WebApplication1.Controllers;
[ApiController]
[Route("api/[controller]")]
public class InternController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;
    private readonly ILogger<InternController> _logger;


    private readonly IValidator<CreateInternDto> _createValidator;
    private readonly IValidator<UpdateInternDto> _updateValidator;
    private readonly IValidator<GetDto> _getDtoValidator;
    
    
    public InternController(ApplicationDbContext db, IMapper mapper,ILogger<InternController> logger,IValidator<CreateInternDto> createValidator, IValidator<UpdateInternDto> updateValidator, IValidator<GetDto> getDtoValidator) 
    
    {
        _createValidator=createValidator;
        _updateValidator=updateValidator;
        _getDtoValidator=getDtoValidator;
        _mapper=mapper;
        _db = db;
        _logger=logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<InternDTO>>> GetInterns([FromQuery] GetDto filter)
    {
        var isValid = await _getDtoValidator.ValidateAsync(filter);
        if (!isValid.IsValid)
        {
            return BadRequest(isValid.ToDictionary());
        }
        var query = _db.Interns.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(filter.name))
        {
            query = query.Where(o => o.Name.Contains(filter.name));
        }
        if (!string.IsNullOrWhiteSpace(filter.surname))
        {
            query = query.Where(o => o.Surname.Contains(filter.surname));
        }


        var interns = await query.OrderBy(o=>o.Id).Skip((filter.page - 1) * filter.pageSize).Take(filter.pageSize).ToListAsync();
        var InternListDto=_mapper.Map<IEnumerable<InternDTO>>(interns);
        return  Ok(InternListDto);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<InternDTO>> GetIntern(int id)
    {
        var intern = await _db.Interns.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id);
        if(intern == null){return NotFound();}
        return Ok(_mapper.Map<InternDTO>(intern));
    }

    [HttpPost]
    public async Task<ActionResult<InternDTO>> CreateIntern(CreateInternDto createInternDto)
    {
        var isValid = await _createValidator.ValidateAsync(createInternDto);
        if (!isValid.IsValid)
        {
            return BadRequest();
        }
        var intern = _mapper.Map<Intern>(createInternDto);
        await _db.AddAsync(intern);
        await _db.SaveChangesAsync();
        var internDto=_mapper.Map<InternDTO>(intern);
        return CreatedAtAction(nameof(GetIntern), new { id = intern.Id }, internDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<InternDTO>> UpdateIntern(UpdateInternDto updateInternDto,int id)
    {
        var isValid=await _updateValidator.ValidateAsync(updateInternDto);
        if (!isValid.IsValid)
        {
            return BadRequest(isValid.ToDictionary());
        }
        var intern = await _db.Interns.FirstOrDefaultAsync(o => o.Id == id);
        if(intern == null){return NotFound();}
        
        _mapper.Map(updateInternDto,intern);
        await _db.SaveChangesAsync();
        return  Ok(_mapper.Map<InternDTO>(intern));
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteIntern(int id)
    {
        var intern = await _db.Interns.FirstOrDefaultAsync(o => o.Id == id);
        if(intern == null){return NotFound();}
        _db.Interns.Remove(intern);
        await _db.SaveChangesAsync();
        return NoContent();

    }
}