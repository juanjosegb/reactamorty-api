namespace reactamorty_api.Domains
{
    public class OriginResult
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public OriginResult(string name, string url)
        {
            Name = name;
            Url = url;
        }
    }
}