namespace reactamorty_api.Domains
{
    public class CharacterResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Species { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }

        public CharacterResult(int id, string name, string status, string species, string type, string gender)
        {
            Id= id;
            Name = name;
            Status = status;
            Species = species;
            Type = type;
            Gender = gender;
        }
    }
}