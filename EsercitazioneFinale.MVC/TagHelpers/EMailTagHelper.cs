using Microsoft.AspNetCore.Razor.TagHelpers;

namespace EsercitazioneFinale.MVC.TagHelpers
{
    public class EMailTagHelper : TagHelper
    {
        public string ToUser { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Content.SetContent("Mandami una mail per info e prenotazioni!");
            output.Attributes.SetAttribute("class", "btn btn-outline-primary");
            output.Attributes.SetAttribute("href", $"mailto:{ToUser}");
        }
    }
}
