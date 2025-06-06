namespace LuftbornTask.Models
{
    public class CreateVikingDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public VikingGender Gender { get; set; }
        public VikingRank Rank { get; set; }
    }

    public class UpdateVikingDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public VikingGender Gender { get; set; }
        public VikingRank Rank { get; set; }
    }
} 