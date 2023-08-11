using Microsoft.AspNetCore.Mvc.Rendering;

namespace ObrasMusicaisApi.Models.ViewModels;

public class AddObrasRequest
{
    public string Heading { get; set; }
    public string PageTitle { get; set; }
    public string Content { get; set; }
    public string ShortDescription { get; set; }
    public string FeaturedImageUrl { get; set; }
    public string UrlHandle { get; set; }
    public DateTime PublishedDate { get; set; }
    public string Author { get; set; }
    public bool Visible { get; set; }

    //show all tags in db
    public IEnumerable<SelectListItem> Tags { get; set; }
    //collect tag
}
