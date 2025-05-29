public interface IPetService
{
    IEnumerable<Pet> GetAll();
    Pet? GetById(int id);
    Pet Add(Pet pet);
    Pet Update(int id, Pet pet);
    Pet Delete(int id);
}