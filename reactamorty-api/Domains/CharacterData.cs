namespace reactamorty_api.Domains
{
    public class CharacterData
    {
        public int Page { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Species { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }

        public CharacterData(int page, string name, string status, string species, string type, string gender)
        {
            Page = page;
            Name = name;
            Status = status;
            Species = species;
            Type = type;
            Gender = gender;
        }
    }
}