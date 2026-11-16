namespace RazorRadioApi.Radio.ProgramsForPage
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Channel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Pagination
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public int Totalhits { get; set; }
        public int Totalpages { get; set; }
        public string Nextpage { get; set; }
    }

    public class Program
    {
        public string Description { get; set; }
        public string Broadcastinfo { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Programurl { get; set; }
        public string Programslug { get; set; }
        public string Programimage { get; set; }
        public string Programimagetemplate { get; set; }
        public string Programimagewide { get; set; }
        public string Programimagetemplatewide { get; set; }
        public string Socialimage { get; set; }
        public string Socialimagetemplate { get; set; }
        public List<Socialmediaplatform> Socialmediaplatforms { get; set; }
        public Channel Channel { get; set; }
        public bool Archived { get; set; }
        public bool Hasondemand { get; set; }
        public bool Haspod { get; set; }
        public string Responsibleeditor { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public Programcategory Programcategory { get; set; }
    }

    public class Programcategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ListPrograms
    {
        public string Copyright { get; set; }
        public List<Program> Programs { get; set; }
        public Pagination Pagination { get; set; }
    }

    public class Socialmediaplatform
    {
        public string Platform { get; set; }
        public string Platformurl { get; set; }
    }


}
