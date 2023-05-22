using System.ComponentModel.DataAnnotations;

namespace FormBuilderBuilder.Models
{
	public class FileUploadViewModel
	{
		[Required]
		public string Title { get; set; }
		[Required]
		[Display(Name = "Page slug e.g. page-slug")]
		public string PageSlug { get; set; }
		[Display(Name = "Opening paragraph")]
		public string? PTag { get; set; }
		[Required]
		public string ListItems { get; set; }
		[Required]
		[Display(Name = "Go to page slug e.g. why-is-it")]
		public string GoPageSlug { get; set; }
		[Required]
		public string TheJSON { get; set; }
	}
}