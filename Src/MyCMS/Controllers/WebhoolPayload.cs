namespace MyCMS.Controllers
{

    public class WebhookPayload
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Route Route { get; set; }
        public string Id { get; set; }
        public string ContentType { get; set; }
        public Properties Properties { get; set; }
    }

    public class Route
    {
        public string Path { get; set; }
        public Startitem StartItem { get; set; }
    }

    public class Startitem
    {
        public string Id { get; set; }
        public string Path { get; set; }
    }

    public class Properties
    {
        public DateTime articleDate { get; set; }
        public Author[] author { get; set; }
        public Category[] categories { get; set; }
        public Contentrows contentRows { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public Mainimage[] mainImage { get; set; }
        public string metaName { get; set; }
        public string metaDescription { get; set; }
        public string metaKeywords { get; set; }
        public bool hideFromTopNavigation { get; set; }
        public bool umbracoNaviHide { get; set; }
        public bool hideFromXMLSitemap { get; set; }
    }

    public class Contentrows
    {
        public Item[] Items { get; set; }
    }

    public class Item
    {
        public Content Content { get; set; }
        public Settings Settings { get; set; }
    }

    public class Content
    {
        public string Id { get; set; }
        public string ContentType { get; set; }
        public ContentProperties Properties { get; set; }
    }

    public class ContentProperties
    {
        public ChildContent content { get; set; }
    }

    public class ChildContent
    {
        public string Markup { get; set; }
        public object[] Blocks { get; set; }
    }

    public class Settings
    {
        public string Id { get; set; }
        public string ContentType { get; set; }
        public SettingProperties Properties { get; set; }
    }

    public class SettingProperties
    {
        public bool hide { get; set; }
        public object paddingTop { get; set; }
        public object paddingBottom { get; set; }
        public object paddingLeft { get; set; }
        public object paddingRight { get; set; }
        public object marginTop { get; set; }
        public object marginBottom { get; set; }
        public object marginLeft { get; set; }
        public object marginRight { get; set; }
    }

    public class Author
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public AuthorRoute Route { get; set; }
        public string Id { get; set; }
        public string ContentType { get; set; }
        public Properties3 Properties { get; set; }
    }

    public class AuthorRoute
    {
        public string Path { get; set; }
        public AuthorStart StartItem { get; set; }
    }

    public class AuthorStart
    {
        public string Id { get; set; }
        public string Path { get; set; }
    }

    public class Properties3
    {
    }

    public class Category
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Route2 Route { get; set; }
        public string Id { get; set; }
        public string ContentType { get; set; }
        public Properties4 Properties { get; set; }
    }

    public class Route2
    {
        public string Path { get; set; }
        public Startitem2 StartItem { get; set; }
    }

    public class Startitem2
    {
        public string Id { get; set; }
        public string Path { get; set; }
    }

    public class Properties4
    {
    }

    public class Mainimage
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string MediaType { get; set; }
        public string Url { get; set; }
        public string Extension { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Bytes { get; set; }
        public Properties5 Properties { get; set; }
        public object[] Crops { get; set; }
    }

    public class Properties5
    {
    }
}
