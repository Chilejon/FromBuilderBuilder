using System.ComponentModel.DataAnnotations;

namespace FormBuilderBuilder.Models
{
	public class DisplayJSONViewModel
	{
		public string DisplayJSON { get; set; }
		[Required]
		public string TheJSON { get; set; }
	}
}