using System.ComponentModel.DataAnnotations;

namespace FormBuilderBuilder.Models
{
	public class TextboxViewModel
	{
		[Required]
		public string Title { get; set; }
		[Required]
		public string PageSlug { get; set; }
		[Required]
		public string QuestionID { get; set; }
		[Required]
		public string Label { get; set; }
		
		public string CustomValidationMessage { get; set; }
		
		public string Optional { get; set; }
		[Required]
		public string GoPageSlug { get; set; }

		[Required]
		public string TheJSON { get; set; }
	}
}