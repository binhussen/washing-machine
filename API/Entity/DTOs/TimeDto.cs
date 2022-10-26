using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entity.DTOs
{
    public class TimeDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Status { get; set; }
        public int MachineId { get; set; }
    }
}
