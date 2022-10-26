using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entity
{
    public class Machine
    {
        [Column("MachineId")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Time> Times { get; set; }
    }
}
