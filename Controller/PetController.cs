using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PetController : ControllerBase
{
    private readonly IPetRepository _repo;
    public PetController(IPetRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pet>>> Get() => Ok(await _repo.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Pet>> GetById(int id)
    {
        var pet = _repo.GetByIdAsync(id);
        return pet is null ? NotFound() : Ok(pet);
    }

    [HttpPost]
    public async Task<ActionResult<Pet>> Post(Pet pet)
    {
        var novoPet = await _repo.AddAsync(pet);
        return CreatedAtAction(nameof(GetById), new { id = novoPet.Id }, novoPet);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, Pet pet)
    {
        var petAtualizado = await _repo.PutAsync(id, pet);
        return petAtualizado is null ? NotFound() : Ok(petAtualizado);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var petDeletado = await _repo.DeleteAsync(id);
        return petDeletado ? NoContent() : NotFound();
    }
}