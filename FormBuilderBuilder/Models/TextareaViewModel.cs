using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FormBuilderBuilder.Models
{
	public class TextareaViewModel
	{
		[Required]
		[Display(Name = "Title")]
		public string Title { get; set; }
		[Required]
		[Display(Name = "Page slug e.g. page-slug")]
		public string PageSlug { get; set; }
		[Required]
		public string QuestionID { get; set; }
		[Required]
		public string Label { get; set; }
		[Display(Name = "Error message")]
		public string? CustomValidationMessage { get; set; }
		[Display(Name = "Hint")]
		public string? Hint { get; set; }

		public string Optional { get; set; }
		[Display(Name = "Max length e.g. 250")]
		public int MaxLength { get; set; }
		[Display(Name = "Display character count")]
		public string DisplayCharacterCount { get; set; }
		[Display(Name = "Next page slug")]
		[Required]
		public string GoPageSlug { get; set; }

		[Required]
		public string TheJSON { get; set; }
	}
}