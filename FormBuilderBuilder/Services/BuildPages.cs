using FormBuilderBuilder.Models;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace FormBuilderBuilder.Services
{
	public class BuildPages
	{
		public string Header = $"C:\\code\\FromBuilderBuilder\\FormBuilderBuilder\\JSON\\Basics\\header.json";
		public string Footer = $"C:\\code\\FromBuilderBuilder\\FormBuilderBuilder\\JSON\\Basics\\footer.json";
		public string Textbox = $"C:\\code\\FromBuilderBuilder\\FormBuilderBuilder\\JSON\\Basics\\textbox.json";
		public string Textarea = $"C:\\code\\FromBuilderBuilder\\FormBuilderBuilder\\JSON\\Basics\\textarea.json";
		public string FullContactDetails = $"C:\\code\\FromBuilderBuilder\\FormBuilderBuilder\\JSON\\Basics\\fullcontactdetails.json";
        
        public string OutputJSON = $"C:\\code\\FromBuilderBuilder\\FormBuilderBuilder\\JSON\\Output\\Output{DateTime.Now.ToString().Replace(":","").Replace(" ", "").Replace("/", "")}.json";
       // C:\code\FromBuilderBuilder\FormBuilderBuilder\JSON\Output
        public string BuildTheJson(HomeViewModel homeViewModel)
		{
			using (var output = File.Create(OutputJSON))
			{
				foreach (var file in new[] { Header })
				{
					using (var input = File.OpenRead(file))
					{
						input.CopyTo(output);
					}
				}
				output.Close();
			}

			string savedJSONFile = File.ReadAllText(OutputJSON);
			savedJSONFile = savedJSONFile.Replace("#FormName", homeViewModel.FormNme);
			savedJSONFile = savedJSONFile.Replace("#BaseURL", homeViewModel.BaseURL);
			savedJSONFile = savedJSONFile.Replace("#FirstPageSlug", homeViewModel.FirstPageSlug);

			File.WriteAllText(OutputJSON, savedJSONFile);

			return OutputJSON;
		}

		public string BuildTheJson(TextboxViewModel textboxViewModel)
		{

			File.AppendAllText(textboxViewModel.TheJSON, File.ReadAllText(Textbox));

			string savedJSONFile = File.ReadAllText(textboxViewModel.TheJSON);
			savedJSONFile = savedJSONFile.Replace("#TextboxTitle", textboxViewModel.Title);
			savedJSONFile = savedJSONFile.Replace("#TextboxPageSlug", textboxViewModel.PageSlug);
			savedJSONFile = savedJSONFile.Replace("#TextboxQuestionID", textboxViewModel.QuestionID);
			savedJSONFile = savedJSONFile.Replace("#TextboxLabel", textboxViewModel.Label);
			savedJSONFile = savedJSONFile.Replace("#TextboxCustomValidationMessage", textboxViewModel.CustomValidationMessage);
			savedJSONFile = savedJSONFile.Replace("#TextboxOptional", textboxViewModel.Optional);
			savedJSONFile = savedJSONFile.Replace("#TextboxGoPageSlug", textboxViewModel.GoPageSlug);

			File.WriteAllText(textboxViewModel.TheJSON, savedJSONFile);

			return textboxViewModel.TheJSON;
		}

		public string BuildTheJson(TextareaViewModel textareaViewModel)
		{

			File.AppendAllText(textareaViewModel.TheJSON, File.ReadAllText(Textarea));

			string savedJSONFile = File.ReadAllText(textareaViewModel.TheJSON);
			savedJSONFile = savedJSONFile.Replace("#TextareaTitle", textareaViewModel.Title);
			savedJSONFile = savedJSONFile.Replace("#TextareaPageSlug", textareaViewModel.PageSlug);
			savedJSONFile = savedJSONFile.Replace("#TextareaQuestionID", textareaViewModel.QuestionID);
			savedJSONFile = savedJSONFile.Replace("#TextareaLabel", textareaViewModel.Label);
			savedJSONFile = savedJSONFile.Replace("#TextareaCustomValidationMessage", textareaViewModel.CustomValidationMessage);
			savedJSONFile = savedJSONFile.Replace("#TextareaOptional", textareaViewModel.Optional);
			savedJSONFile = savedJSONFile.Replace("#TextareaGoPageSlug", textareaViewModel.GoPageSlug);

			File.WriteAllText(textareaViewModel.TheJSON, savedJSONFile);

			return textareaViewModel.TheJSON;
		}

		public void BuildTheJson(string TheJSON)
		{
			File.AppendAllText(TheJSON, File.ReadAllText(FullContactDetails));
		}

        public void BuildTheJsonFooter(string TheJSON)
        {
            File.AppendAllText(TheJSON, File.ReadAllText(Footer));
        }
    }
}
