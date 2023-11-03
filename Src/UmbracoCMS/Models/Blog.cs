namespace UmbracoCMS.Models
{
    public class Blog : Content
    {
        public string Excerpt { get; set; }
        public DateTime PublisDateTime { get; set; }
        public string[] Category { get; set; }

        // Doesn't actually exist in the site content model but I'm faking it for the demo
        public Person Author { get; set; }

    }
}
