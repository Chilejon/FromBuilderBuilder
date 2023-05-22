using FormBuilderBuilder.Models;
using System.IO;

namespace FormBuilderBuilder.Services
{
	public class JSONEdits
	{
		
        public string ReadJSON(string TheJSON)
        {
			string readText = File.ReadAllText(TheJSON);

			return readText;
		}
    }
}
