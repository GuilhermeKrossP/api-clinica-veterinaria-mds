using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TutorController : ControllerBase
{
    private readonly ITutorRepository _repo;
    public TutorController(ITutorRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tutor>>> Get() => Ok(await _repo.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Tutor>> GetById(int id)
    {
        var tutor = await _repo.GetByIdAsync(id);
        return tutor is null ? NotFound() : Ok(tutor);
    }

    [HttpPost]
    public async Task<ActionResult<Tutor>> Post(Tutor tutor)
    {
        return Ok( await _repo.AddAsync(tutor));
        
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Tutor>> Put(int id, Tutor tutor)
    {
        var tutorAtualizado = await _repo.PutAsync(id, tutor);
        return tutorAtualizado is null ? NotFound() : Ok(tutorAtualizado);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var tutorDeletado = await _repo.DeleteAsync(id);
        return tutorDeletado  ? NoContent() : NotFound();
    }
}