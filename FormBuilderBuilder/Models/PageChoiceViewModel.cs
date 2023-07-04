using System.ComponentModel.DataAnnotations;

namespace FormBuilderBuilder.Models
{
	public class PageChoiceViewModel
	{
		[Required]
		public string PageChoice { get; set; }
		public bool ShowOptions { get; set; } = true;
		public string TheJSON {  get; set; }
		public string NextSlug { get; set; }
	}
}