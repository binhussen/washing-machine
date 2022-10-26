using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entity
{
    public class Time
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Status { get; set; }
        [ForeignKey(nameof(Machine))]
        public int MachineId { get; set; }
    }
}
