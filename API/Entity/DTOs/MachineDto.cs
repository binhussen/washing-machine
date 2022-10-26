namespace API.Entity.DTOs
{
    public class MachineDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<TimeDto>? Times { get; set; }
    }
}
