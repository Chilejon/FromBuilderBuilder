using System.ComponentModel.DataAnnotations;

namespace FormBuilderBuilder.Models
{
	public class PageChoiceViewModel
	{
		[Required]
		public string PageChoice { get; set; }
		public string TheJSON {  get; set; }
	}
}