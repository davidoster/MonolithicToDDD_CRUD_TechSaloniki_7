namespace Monolithic_MVC_Demo.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Trainer>? Trainers { get; set; }
    }
}
