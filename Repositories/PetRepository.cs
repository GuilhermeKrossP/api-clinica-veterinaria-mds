using Microsoft.EntityFrameworkCore;

public class PetRepository : IPetRepository
{
    private readonly AppDbContext _context;

    public PetRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Pet>> GetAllAsync() => await _context.Pets.ToListAsync();

    public async Task<Pet?> GetByIdAsync(int id) => await _context.Pets
            .FirstOrDefaultAsync(l => l.Id == id);

    public async Task<Pet> AddAsync(Pet pet)
    {
        _context.Pets.Add(pet);
        await _context.SaveChangesAsync();
        return pet;
    }

    public async Task UpdateAsync(int id, Pet pet)
    {
        _context.Pets.Update(pet);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var pet = await GetByIdAsync(id);
        if (pet is null) return false;
        _context.Pets.Remove(pet);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Pet?> PutAsync(int id, Pet pet)
    {
        var update = await _context.Pets.FindAsync(id);
        if (update == null)
            return null;

        update.Nome = pet.Nome;
        update.Especie = pet.Especie;
        update.Raca = pet.Raca;
        update.TutorId = pet.TutorId;

        await _context.SaveChangesAsync();
        return update;
    }
}