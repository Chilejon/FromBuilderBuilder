using System.ComponentModel.DataAnnotations;

namespace FormBuilderBuilder.Models
{
	public class HomeViewModel
	{
		[Required]
		public string FormNme { get; set; }
		[Required]
		public string BaseURL { get; set; }
		public string FirstPageSlug { get; set; }
	}
}