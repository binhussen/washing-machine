using API.Entity;

namespace API.Interface
{
    public interface ITime
    {
        IEnumerable<Time> GetAll(int machineId);
        Time GetById(int machineId,int id);
        void Create(int machineId,Time time);
        void Update(int machineId,int id, Time time);
        void Delete(int machineId,int id);
    }
}
