public class PetService : IPetService
{
    private readonly AppDbContext _context;
    public PetService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Pet> GetAll() => _context.Pets.ToList();

    public Pet? GetById(int id) => _context.Pets.Find(id);

    public async Task<Pet> Add(Pet pet)
    {
       await _context.Pets.AddAsync(pet);
        await _context.SaveChangesAsync();
        return pet;
    }

    public Pet Update(int id, Pet pet)
    {
        var novoPet = _context.Pets.Find(id);
        if (novoPet == null) return null;
        novoPet.Nome = pet.Nome;
        _context.SaveChanges();
        return novoPet;
    }

    public Pet Delete(int id)
    {
        var pet = _context.Pets.Find(id);
        if (pet == null) return null;

        _context.Pets.Remove(pet);
        _context.SaveChanges();
        return pet;
    }

    Pet IPetService.Add(Pet pet)
    {
        throw new NotImplementedException();
    }
}