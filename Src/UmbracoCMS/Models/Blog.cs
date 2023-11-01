namespace UmbracoCMS.Models
{
    public class Blog : Content
    {
        public string Excerpt { get; set; }
        public DateTime PublisDateTime { get; set; }
        public string[] Category { get; set; }

    }
}
