using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyF.Week8.Esercitazione1.MVC.TagHelpers
{
    [HtmlTargetElement("selectPriority")]
    public class PrioritySelectionTagHelper: TagHelper
    {
        
        public List<SelectListItem> List { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var input = new TagBuilder("input");
            
            foreach (var item in List)
            {
                input.Attributes.Add($"{item.Text}", $"{item.Value}");
            }
            output.TagName = "select-to";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", "form - control");
            output.Attributes.SetAttribute("required","required");
            
            
        }
    }
}
