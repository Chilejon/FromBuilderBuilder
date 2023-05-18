using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FormBuilderBuilder.Models
{
	public class RadioViewModel
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
		[Display(Name = "Optional")]
		public string Optional { get; set; }
		
		[Display(Name = "Option 1 Text")]
		[Required]
		public string Option1Text { get; set; }
		[Display(Name = "Option 1 Value")]
		[Required]
		public string Option1Value { get; set; }
		[Display(Name = "Option 2 Text")]
		[Required]
		public string Option2Text { get; set; }
		[Display(Name = "Option 2 Value")]
		[Required]
		public string Option2Value { get; set; }


		[Display(Name = "Next page slug")]
		[Required]
		public string GoPageSlug { get; set; }

		[Required]
		public string TheJSON { get; set; }
	}
}