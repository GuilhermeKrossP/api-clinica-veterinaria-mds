using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/tutor")]
public class TutorController : ControllerBase
{
    private readonly ITutorRepository _repo;
    public TutorController(ITutorRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Tutor>> Get() => Ok(_repo.GetAllAsync());

    [HttpGet("{id}")]
    public ActionResult<Tutor> GetById(int id)
    {
        var tutor = _repo.GetByIdAsync(id);
        return tutor is null ? NotFound() : Ok(tutor);
    }

    [HttpPost]
    public async Task<ActionResult<Tutor>> Post(Tutor tutor)
    {
        return Ok( await _repo.AddAsync(tutor));
        
    }

    [HttpPut("{id}")]
    public ActionResult<Tutor> Put(int id, Tutor tutor)
    {
        if (id != tutor.Id)
            return BadRequest();

        var tutorAtualizado = _repo.UpdateAsync(id, tutor);
        return tutorAtualizado is null ? NotFound() : Ok(tutorAtualizado);
    }

    [HttpDelete("{id}")]
    public ActionResult<Tutor> Delete(int id)
    {
        var tutorDeletado = _repo.DeleteAsync(id);
        return tutorDeletado is null ? NotFound() : Ok(tutorDeletado);
    }
}