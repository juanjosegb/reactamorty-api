namespace reactamorty_api.Domains
{
    public class CharacterInfo
    {
        public int Count { get; set; }
        public int Pages { get; set; }
        public string Next { get; set; }
        public string Prev { get; set; }

        public CharacterInfo(int count, int pages, string next, string prev)
        {
            Count = count;
            Pages = pages;
            Next = next;
            Prev = prev;
        }
    }
}