using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FormBuilderBuilder.Models
{
	public class HomeViewModel
	{
		[Required]
		[DisplayName("Form name")]
		public string FormName { get; set; }
		[Required]
		[DisplayName("Url e.g. form-name")]
		public string BaseURL { get; set; }
		[DisplayName("First page slug e.g. what-is-wrong")]
		public string FirstPageSlug { get; set; }
	}
}