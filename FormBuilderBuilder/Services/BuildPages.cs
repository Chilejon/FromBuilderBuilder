using FormBuilderBuilder.Models;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace FormBuilderBuilder.Services
{
	public class BuildPages
	{
		public string Header = $"C:\\code\\FormBuilderBuilder\\FormBuilderBuilder\\JSON\\Basics\\header.json";
		public string Radio = $"C:\\code\\FormBuilderBuilder\\FormBuilderBuilder\\JSON\\Basics\\radio.json";
		public string Checkbox = $"C:\\code\\FormBuilderBuilder\\FormBuilderBuilder\\JSON\\Basics\\checkbox.json";
		public string Endform = $"C:\\code\\FormBuilderBuilder\\FormBuilderBuilder\\JSON\\Basics\\endform.json";
        public string Textbox = $"C:\\code\\FormBuilderBuilder\\FormBuilderBuilder\\JSON\\Basics\\textbox.json";
		public string Declaration = $"C:\\code\\FormBuilderBuilder\\FormBuilderBuilder\\JSON\\Basics\\declaration.json";
		public string Textarea = $"C:\\code\\FormBuilderBuilder\\FormBuilderBuilder\\JSON\\Basics\\textarea.json";
		public string FileUpload = $"C:\\code\\FormBuilderBuilder\\FormBuilderBuilder\\JSON\\Basics\\fileupload.json";
		public string FullContactDetails = $"C:\\code\\FormBuilderBuilder\\FormBuilderBuilder\\JSON\\Basics\\fullcontactdetails.json";
        
        public string OutputJSON = $"C:\\code\\FormBuilderBuilder\\FormBuilderBuilder\\JSON\\Output\\Output{DateTime.Now.ToString().Replace(":","").Replace(" ", "").Replace("/", "")}.json";
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
			savedJSONFile = savedJSONFile.Replace("#FormName", homeViewModel.FormName);
			savedJSONFile = savedJSONFile.Replace("#BaseURL", homeViewModel.BaseURL);
			savedJSONFile = savedJSONFile.Replace("#FirstPageSlug", homeViewModel.FirstPageSlug);

			File.WriteAllText(OutputJSON, savedJSONFile);

			return OutputJSON;
		}

		public string BuildTheJson(TextboxViewModel textboxViewModel)
		{

			File.AppendAllText(textboxViewModel.TheJSON, File.ReadAllText(Textbox));

			string savedJSONFile = File.ReadAllText(textboxViewModel.TheJSON);

            savedJSONFile = savedJSONFile.Replace("#TextboxPTag", textboxViewModel.PTag);
			savedJSONFile = savedJSONFile.Replace("#TextboxTitle", textboxViewModel.Title);
			savedJSONFile = savedJSONFile.Replace("#TextboxPageSlug", textboxViewModel.PageSlug);
			savedJSONFile = savedJSONFile.Replace("#TextboxQuestionID", textboxViewModel.QuestionID);
			savedJSONFile = savedJSONFile.Replace("#TextboxLabel", textboxViewModel.Label);
            savedJSONFile = savedJSONFile.Replace("#TextboxHint", textboxViewModel.Hint);
            savedJSONFile = savedJSONFile.Replace("#TextboxCustomValidationMessage", textboxViewModel.CustomValidationMessage);
			if (textboxViewModel.Optional == "yes")
			{
                savedJSONFile = savedJSONFile.Replace("#TextboxOptional", "true");
            }
			else
			{
                savedJSONFile = savedJSONFile.Replace("#TextboxOptional", "false");
            }
			
			savedJSONFile = savedJSONFile.Replace("#TextboxGoPageSlug", textboxViewModel.GoPageSlug);

			File.WriteAllText(textboxViewModel.TheJSON, savedJSONFile);

			return textboxViewModel.TheJSON;
		}

		public string BuildTheJson(TextareaViewModel textareaViewModel)
		{

			File.AppendAllText(textareaViewModel.TheJSON, File.ReadAllText(Textarea));

			string savedJSONFile = File.ReadAllText(textareaViewModel.TheJSON);
			savedJSONFile = savedJSONFile.Replace("#TextareaPTag", textareaViewModel.PTag);
			savedJSONFile = savedJSONFile.Replace("#TextareaTitle", textareaViewModel.Title);
			savedJSONFile = savedJSONFile.Replace("#TextareaPageSlug", textareaViewModel.PageSlug);
			savedJSONFile = savedJSONFile.Replace("#TextareaQuestionID", textareaViewModel.QuestionID);
			savedJSONFile = savedJSONFile.Replace("#TextareaLabel", textareaViewModel.Label);
			savedJSONFile = savedJSONFile.Replace("#TextareaCustomValidationMessage", textareaViewModel.CustomValidationMessage);
            if (textareaViewModel.DisplayCharacterCount == "yes")
            {
                savedJSONFile = savedJSONFile.Replace("#TextareaDisplayCharacterCount", "true");
            }
            else
            {
                savedJSONFile = savedJSONFile.Replace("#TextareaDisplayCharacterCount", "false");
            }
            savedJSONFile = savedJSONFile.Replace("#TextareaDisplayCharacterCount", textareaViewModel.DisplayCharacterCount);
			savedJSONFile = savedJSONFile.Replace("#TextareaHint", textareaViewModel.Hint);
			savedJSONFile = savedJSONFile.Replace("#TextareaMaxLength", textareaViewModel.MaxLength.ToString());


			//savedJSONFile = savedJSONFile.Replace("#TextareaOptional", textareaViewModel.Optional);
            if (textareaViewModel.Optional == "yes")
            {
                savedJSONFile = savedJSONFile.Replace("#TextareaOptional", "true");
            }
            else
            {
                savedJSONFile = savedJSONFile.Replace("#TextareaOptional", "false");
            }
            savedJSONFile = savedJSONFile.Replace("#TextareaGoPageSlug", textareaViewModel.GoPageSlug);

			File.WriteAllText(textareaViewModel.TheJSON, savedJSONFile);

			return textareaViewModel.TheJSON;
		}

		public string BuildTheJson(RadioViewModel radioViewModel)
		{

			File.AppendAllText(radioViewModel.TheJSON, File.ReadAllText(Radio));

			string savedJSONFile = File.ReadAllText(radioViewModel.TheJSON);
            savedJSONFile = savedJSONFile.Replace("#RadioPTag", radioViewModel.PTag);
            savedJSONFile = savedJSONFile.Replace("#RadioTitle", radioViewModel.Title);
			savedJSONFile = savedJSONFile.Replace("#RadioPageSlug", radioViewModel.PageSlug);
			savedJSONFile = savedJSONFile.Replace("#RadioQuestionID", radioViewModel.QuestionID);
			savedJSONFile = savedJSONFile.Replace("#RadioLabel", radioViewModel.Label);
			savedJSONFile = savedJSONFile.Replace("#RadioCustomValidationMessage", radioViewModel.CustomValidationMessage);
			savedJSONFile = savedJSONFile.Replace("#RadioHint", radioViewModel.Hint);

			savedJSONFile = savedJSONFile.Replace("#RadioOption1Text", radioViewModel.Option1Text);
			savedJSONFile = savedJSONFile.Replace("#RadioOption1Value", radioViewModel.Option1Value);
			savedJSONFile = savedJSONFile.Replace("#RadioOption2Text", radioViewModel.Option2Text);
			savedJSONFile = savedJSONFile.Replace("#RadioOption2Value", radioViewModel.Option2Value);

			savedJSONFile = savedJSONFile.Replace("#RadioOptional", radioViewModel.Optional);
			savedJSONFile = savedJSONFile.Replace("#RadioGoPageSlug", radioViewModel.GoPageSlug);

			File.WriteAllText(radioViewModel.TheJSON, savedJSONFile);

			return radioViewModel.TheJSON;
		}

		public string BuildTheJson(CheckboxViewModel checkboxViewModel)
		{

			File.AppendAllText(checkboxViewModel.TheJSON, File.ReadAllText(Checkbox));

			string savedJSONFile = File.ReadAllText(checkboxViewModel.TheJSON);
			savedJSONFile = savedJSONFile.Replace("#CheckboxTitle", checkboxViewModel.Title);
            savedJSONFile = savedJSONFile.Replace("#CheckboxPTag", checkboxViewModel.PTag);
            savedJSONFile = savedJSONFile.Replace("#CheckboxPageSlug", checkboxViewModel.PageSlug);
			savedJSONFile = savedJSONFile.Replace("#CheckboxQuestionID", checkboxViewModel.QuestionID);
			savedJSONFile = savedJSONFile.Replace("#CheckboxLabel", checkboxViewModel.Label);
			savedJSONFile = savedJSONFile.Replace("#CheckboxCustomValidationMessage", checkboxViewModel.CustomValidationMessage);
			savedJSONFile = savedJSONFile.Replace("#CheckboxHint", checkboxViewModel.Hint);

			savedJSONFile = savedJSONFile.Replace("#CheckboxOption1Text", checkboxViewModel.Option1Text);
			savedJSONFile = savedJSONFile.Replace("#CheckboxOption1Value", checkboxViewModel.Option1Value);
			savedJSONFile = savedJSONFile.Replace("#CheckboxOption2Text", checkboxViewModel.Option2Text);
			savedJSONFile = savedJSONFile.Replace("#CheckboxOption2Value", checkboxViewModel.Option2Value);

			savedJSONFile = savedJSONFile.Replace("#CheckboxOptional", checkboxViewModel.Optional);
			savedJSONFile = savedJSONFile.Replace("#CheckboxGoPageSlug", checkboxViewModel.GoPageSlug);

			File.WriteAllText(checkboxViewModel.TheJSON, savedJSONFile);

			return checkboxViewModel.TheJSON;
		}

		public string BuildTheJson(DeclarationViewModel declarationViewModel)
		{

			File.AppendAllText(declarationViewModel.TheJSON, File.ReadAllText(Declaration));

			string savedJSONFile = File.ReadAllText(declarationViewModel.TheJSON);
			savedJSONFile = savedJSONFile.Replace("#DeclarationPTag", declarationViewModel.PTag);
			savedJSONFile = savedJSONFile.Replace("#DeclarationGoPageSlug", declarationViewModel.GoPageSlug);

			File.WriteAllText(declarationViewModel.TheJSON, savedJSONFile);

			return declarationViewModel.TheJSON;
		}

		public string BuildTheJson(FileUploadViewModel fileUploadViewModel)
		{

			File.AppendAllText(fileUploadViewModel.TheJSON, File.ReadAllText(FileUpload));

			string savedJSONFile = File.ReadAllText(fileUploadViewModel.TheJSON);
			savedJSONFile = savedJSONFile.Replace("#FileUploadTitle", fileUploadViewModel.Title);
			savedJSONFile = savedJSONFile.Replace("#FileUploadPageSlug", fileUploadViewModel.PageSlug);
			savedJSONFile = savedJSONFile.Replace("#FileUploadListItems", fileUploadViewModel.ListItems);
			savedJSONFile = savedJSONFile.Replace("#FileUploadPTag", fileUploadViewModel.PTag);
			savedJSONFile = savedJSONFile.Replace("#FileUploadGoPageSlug", fileUploadViewModel.GoPageSlug);

			File.WriteAllText(fileUploadViewModel.TheJSON, savedJSONFile);

			return fileUploadViewModel.TheJSON;
		}

		public void BuildTheJson(string TheJSON)
		{
			File.AppendAllText(TheJSON, File.ReadAllText(FullContactDetails));
		}

        //public void BuildTheJsonFooter(string TheJSON)
        //{
        //    File.AppendAllText(TheJSON, File.ReadAllText(Footer));
        //}

        public void BuildTheJsonEndform(string TheJSON)
        {
            File.AppendAllText(TheJSON, File.ReadAllText(Endform));

			//string savedJSONFile = File.ReadAllText(TheJSON);
			//savedJSONFile = savedJSONFile.Replace("\"PageSlug\": \"success\"", "\"PageSlug\": \"summary\"");

			//File.WriteAllText(TheJSON, savedJSONFile);
		
		}
    }
}
