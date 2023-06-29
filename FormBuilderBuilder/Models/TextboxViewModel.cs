using System.ComponentModel.DataAnnotations;

namespace FormBuilderBuilder.Models
{
	public class TextboxViewModel
	{
		[Display(Name = "Opening paragraph")]
		public string? PTag { get; set; }
		[Required]
		[Display(Name = "Title of page e.g. What is it that you want to tell us?")]
		public string Title { get; set; }
		[Required]
		[Display(Name = "Page slug e.g. what-is-it")]
		public string PageSlug { get; set; }
		[Required]
		[Display(Name = "QuestionID e.g. whatIsIt")]
		public string QuestionID { get; set; }
		[Required]
		[Display(Name = "Question label e.g. What is it that you want to tell us?")]
		public string Label { get; set; }
        [Display(Name = "Hint")]
        public string? Hint { get; set; }
        [Display(Name = "Validation message e.g. Enter the details")]
		public string? CustomValidationMessage { get; set; }
		
		public string Optional { get; set; }
		[Required]
		[Display(Name = "Go to page slug e.g. why-is-it")]
		public string GoPageSlug { get; set; }

		[Required]
		public string TheJSON { get; set; }
	}
}