using API.Entity;
using API.Interface;

namespace API.Repository
{
    public class TimeRepository : ITime
    {
        private DataContext _dbContext;

        public TimeRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Time> GetAll(int machineId)
        {
            return _dbContext.Times.Where(t => t.MachineId == machineId);
        }

        public Time GetById(int machineId,int id)
        {
            return _dbContext.Times.Where(t => t.MachineId == machineId && t.Id == id).FirstOrDefault();
        }

        public void Create(int machineId,Time time)
        {
            time.MachineId = machineId;
            _dbContext.Times.Add(time);
            _dbContext.SaveChanges();
        }

        public void Update(int machineId,int id, Time time)
        {
            var timeDb = _dbContext.Times.Where(t => t.MachineId == machineId && t.Id == id).FirstOrDefault();

            timeDb.StartTime = time.StartTime != null ? time.StartTime : timeDb.StartTime;
            timeDb.EndTime = time.EndTime != null? time.EndTime:timeDb.EndTime;
            timeDb.Status = time.Status != null ? time.Status : timeDb.Status;
            timeDb.MachineId = machineId;

            _dbContext.Times.Update(timeDb);
            _dbContext.SaveChanges();
        }

        public void Delete(int machineId,int id)
        {
            var time = _dbContext.Times.Where(t => t.MachineId == machineId && t.Id == id).FirstOrDefault();
            _dbContext.Times.Remove(time);
            _dbContext.SaveChanges();
        }
    }
}