public interface ITutorRepository
{
    Task<IEnumerable<Tutor>> GetAllAsync();
    Task<Tutor?> GetByIdAsync(int id);
    Task<Tutor> AddAsync(Tutor tutor);
    Task UpdateAsync(int id, Tutor tutor);
    Task<bool> DeleteAsync(int id);
    Task<Tutor?> PutAsync(int id, Tutor tutor);
}