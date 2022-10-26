using API.Entity;

namespace API.Interface
{
    public interface IMachine
    {
        IEnumerable<Machine> GetAll();
        Machine GetById(int id);
        void Create(Machine time);
        void Update(int id, Machine time);
        void Delete(int id);
    }
}
