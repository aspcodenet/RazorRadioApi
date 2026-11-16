namespace RazorRadioApi.Radio.Podfiles
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Pagination
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public int Totalhits { get; set; }
        public int Totalpages { get; set; }
        public string Nextpage { get; set; }
    }

    public class Podfile
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Filesizeinbytes { get; set; }
        public Program Program { get; set; }
        public DateTime Availablefromutc { get; set; }
        public int Duration { get; set; }
        public DateTime Publishdateutc { get; set; }
        public int Id { get; set; }
        public string Url { get; set; }
        public string Statkey { get; set; }
    }

    public class Program
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ListPodfiles
    {
        public string Copyright { get; set; }
        public List<Podfile> Podfiles { get; set; }
        public Pagination Pagination { get; set; }
    }


}
