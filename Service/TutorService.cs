public class TutorService : ITutorService
{
    private readonly AppDbContext _context;

    public TutorService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Tutor> GetAll() => _context.Tutores.ToList();

    public Tutor? GetById(int id) => _context.Tutores.Find(id);

    public async Task<Tutor> Add(Tutor tutor)
    {
       await _context.Tutores.AddAsync(tutor);
       await _context.SaveChangesAsync();
        return tutor;
    }

    public Tutor Update(int id, Tutor tutor)
    {
        var novoTutor = _context.Tutores.Find(id);
        if (novoTutor == null) return null;
        novoTutor.Nome = tutor.Nome;
        _context.SaveChanges();
        return novoTutor;
    }

    public Tutor Delete(int id)
    {
        var tutor = _context.Tutores.Find(id);
        if (tutor == null) return null;

        _context.Tutores.Remove(tutor);
        _context.SaveChanges();
        return tutor;
    }
}