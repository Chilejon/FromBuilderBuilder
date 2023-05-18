using System.ComponentModel.DataAnnotations;

namespace FormBuilderBuilder.Models
{
	public class DeclarationViewModel
	{
		[Display(Name = "Opening paragraph")]
		public string? PTag { get; set; }
		[Required]
		[Display(Name = "Go to page slug e.g. why-is-it")]
		public string GoPageSlug { get; set; }
		[Required]
		public string TheJSON { get; set; }
	}
}