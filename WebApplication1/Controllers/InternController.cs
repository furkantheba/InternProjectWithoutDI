using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DTO;
using WebApplication1.Services;

namespace WebApplication1.Controllers;
[ApiController]
[Route("api/[controller]")]
public class InternController : ControllerBase
{
    private readonly IInternService _internService;
    
    
    public InternController(IInternService internService) 
    
    {
        _internService = internService;
     
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<InternDTO>>> GetInterns([FromQuery] GetQuery filter)
    {
        var interns = await _internService.GetAllAsync(filter);
        return Ok(interns);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<InternDTO>> GetIntern(int id)
    {
        var intern=await _internService.GetByIdAsync(id);
        if (intern==null) return NotFound();
        return Ok(intern);
    }

    [HttpPost]
    public async Task<ActionResult<InternDTO>> CreateIntern(CreateInternDto createInternDto)
    {
        var intern=await _internService.CreateAsync(createInternDto);
        return CreatedAtAction(nameof(GetIntern),new {id = intern.Id},intern);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<InternDTO>> UpdateIntern(UpdateInternDto updateInternDto,int id)
    {
        var intern = await _internService.UpdateAsync(id,updateInternDto);
        if(intern==null)return NotFound();
        return Ok(intern);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteIntern(int id)
    { 
        if(await _internService.DeleteAsync(id)){return NoContent();}
        else{return NotFound();}
    }
}