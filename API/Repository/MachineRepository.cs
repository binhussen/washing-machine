using API.Entity;
using API.Interface;
using Machine = API.Entity.Machine;

namespace API.Repository
{
    public class MachineRepository : IMachine
    {
        private DataContext _dbContext;

        public MachineRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Machine> GetAll()
        {
            return _dbContext.Machines;
        }

        public Machine GetById(int id)
        {
            var machine = _dbContext.Machines.Find(id);
            return machine;
        }

        public void Create(Machine machine)
        {
            _dbContext.Machines.Add(machine);
            _dbContext.SaveChanges();
        }

        public void Update(int id, Machine machine)
        {
            var machineDb = _dbContext.Machines.Where(t => t.Id == id).FirstOrDefault();

            machineDb.Name = machine.Name != null ? machine.Name : machineDb.Name;
            machineDb.Description = machine.Description != null ? machine.Description : machineDb.Description;
            ;

            _dbContext.Machines.Update(machineDb);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var machine = _dbContext.Machines.Find(id);
            _dbContext.Machines.Remove(machine);
            _dbContext.SaveChanges();
        }
    }
}