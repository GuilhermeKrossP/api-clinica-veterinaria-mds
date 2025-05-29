public interface ITutorService
{
    IEnumerable<Tutor> GetAll();
    Tutor? GetById(int id);
    Task<Tutor> Add(Tutor tutor);
    Tutor Update(int id, Tutor tutor);
    Tutor Delete(int id);
}