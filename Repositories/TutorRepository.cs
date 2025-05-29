using Microsoft.EntityFrameworkCore;

public class TutorRepository : ITutorRepository
{
    private readonly AppDbContext _context;

    public TutorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tutor>> GetAllAsync() => await _context.Tutores.ToListAsync();

    public async Task<Tutor?> GetByIdAsync(int id) => await _context.Tutores.FindAsync(id);

    public async Task<Tutor> AddAsync(Tutor tutor)
    {
         await _context.Tutores.AddAsync(tutor);
        await _context.SaveChangesAsync();
        return tutor;
    }

    public async Task UpdateAsync(int id, Tutor tutor)
    {
        _context.Tutores.Update(tutor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var tutor = await GetByIdAsync(id);
        if (tutor is null) return;
        _context.Tutores.Remove(tutor);
        await _context.SaveChangesAsync();
    }
}