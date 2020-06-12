namespace reactamorty_api.Domains
{
    public class LocationResult
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public LocationResult(string name, string url)
        {
            Name = name;
            Url = url;
        }
    }
}