public interface IPetRepository
{
    Task<IEnumerable<Pet>> GetAllAsync();
    Task<Pet?> GetByIdAsync(int id);
    Task<Pet> AddAsync(Pet pet);
    Task UpdateAsync(int id, Pet pet);
    Task DeleteAsync(int id);
    Task<Pet?> PutAsync(int id, Pet pet);
}