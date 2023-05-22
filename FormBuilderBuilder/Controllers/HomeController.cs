using FormBuilderBuilder.Models;
using FormBuilderBuilder.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FormBuilderBuilder.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly BuildPages _buildPages;
		private readonly JSONEdits _jSONEdits;

		public HomeController(ILogger<HomeController> logger, BuildPages buildPages, JSONEdits jSONEdits)
		{
			_logger = logger;
			_buildPages = buildPages;
			_jSONEdits = jSONEdits;	
		}

		public IActionResult Index()
		{
			// heading details
			HomeViewModel homeViewModel = new HomeViewModel();	
			return View(homeViewModel);
		}

		[HttpPost]
		public IActionResult Index(HomeViewModel homeViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(homeViewModel);
			}

			BuildPages buildPages =	new BuildPages();
			string theJSON = buildPages.BuildTheJson(homeViewModel);

			ViewBag.TheJSON = theJSON;

			PageChoiceViewModel viewModel = new PageChoiceViewModel();
			
			return View("PageChoice", viewModel);
		}

		public IActionResult PageChoice()
		{
			// heading details
			PageChoiceViewModel pageChoiceViewModel = new PageChoiceViewModel();
			return View(pageChoiceViewModel);
		}

		[HttpPost]
		public IActionResult PageChoice(PageChoiceViewModel pageChoiceViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(pageChoiceViewModel);
			}

            switch (pageChoiceViewModel.PageChoice)
			{
				case "Textbox":
					TextboxViewModel TBviewModel = new TextboxViewModel();
					TBviewModel.TheJSON = pageChoiceViewModel.TheJSON;
					return View(pageChoiceViewModel.PageChoice, TBviewModel);

				case "TextArea":
					TextareaViewModel TAviewModel = new TextareaViewModel();
					TAviewModel.TheJSON = pageChoiceViewModel.TheJSON;
					return View(pageChoiceViewModel.PageChoice, TAviewModel);

                case "Radio":
					RadioViewModel radioViewModel = new RadioViewModel();
					radioViewModel.TheJSON = pageChoiceViewModel.TheJSON;
					return View(pageChoiceViewModel.PageChoice, radioViewModel);

				case "Checkbox":
					CheckboxViewModel checkboxViewModel = new CheckboxViewModel();
					checkboxViewModel.TheJSON = pageChoiceViewModel.TheJSON;
					return View(pageChoiceViewModel.PageChoice, checkboxViewModel);

				case "Declaration":
					DeclarationViewModel declarationViewModel = new DeclarationViewModel();
					declarationViewModel.TheJSON = pageChoiceViewModel.TheJSON;
					return View(pageChoiceViewModel.PageChoice, declarationViewModel);

				case "FileUpload":
					FileUploadViewModel fileUploadViewModel = new FileUploadViewModel();
					fileUploadViewModel.TheJSON = pageChoiceViewModel.TheJSON;
					return View(pageChoiceViewModel.PageChoice, fileUploadViewModel);

				case "FullContactDetails":
					//BuildPages buildPages = new BuildPages();
					_buildPages.BuildTheJson(pageChoiceViewModel.TheJSON);
					ViewBag.TheJSON = pageChoiceViewModel.TheJSON;
					return View("PageChoice", pageChoiceViewModel);

				case "Endform":
                    //BuildPages fbuildPages = new BuildPages();
					_buildPages.BuildTheJsonEndform(pageChoiceViewModel.TheJSON);
                    ViewBag.TheJSON = pageChoiceViewModel.TheJSON;
					pageChoiceViewModel.ShowOptions = false;
                    return View("PageChoice", pageChoiceViewModel);

                default:
					break;
			}

			return View("PageChoice", pageChoiceViewModel);
		}

		public IActionResult Textbox(PageChoiceViewModel pageChoiceViewModel)
		{
			ViewBag.TheJSON = pageChoiceViewModel.TheJSON;
			return View();
		}

		[HttpPost]
		public IActionResult Textbox(TextboxViewModel textboxViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(textboxViewModel);
			}

			//BuildPages buildPages = new BuildPages();
			string theJSON = _buildPages.BuildTheJson(textboxViewModel);


			ViewBag.TheJSON = textboxViewModel.TheJSON;
			PageChoiceViewModel pageChoiceViewModel = new PageChoiceViewModel() { ShowOptions = true };
			return View("PageChoice", pageChoiceViewModel);
		}

		public IActionResult Textarea(PageChoiceViewModel pageChoiceViewModel)
		{
			ViewBag.TheJSON = pageChoiceViewModel.TheJSON;
			return View();
		}

		[HttpPost]
		public IActionResult Textarea(TextareaViewModel textareaViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(textareaViewModel);
			}

			//BuildPages buildPages = new BuildPages();
			string theJSON = _buildPages.BuildTheJson(textareaViewModel);
			ViewBag.TheJSON = textareaViewModel.TheJSON;
			PageChoiceViewModel pageChoiceViewModel = new PageChoiceViewModel() { ShowOptions = true };
			return View("PageChoice", pageChoiceViewModel);
		}

		public IActionResult Radio(PageChoiceViewModel pageChoiceViewModel)
		{
			ViewBag.TheJSON = pageChoiceViewModel.TheJSON;
			return View();
		}

		[HttpPost]
		public IActionResult Radio(RadioViewModel radioViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(radioViewModel);
			}
						
			string theJSON = _buildPages.BuildTheJson(radioViewModel);
			ViewBag.TheJSON = radioViewModel.TheJSON;
			PageChoiceViewModel pageChoiceViewModel = new PageChoiceViewModel() { ShowOptions = true };
			return View("PageChoice", pageChoiceViewModel);
		}

		public IActionResult Checkbox(PageChoiceViewModel pageChoiceViewModel)
		{
			ViewBag.TheJSON = pageChoiceViewModel.TheJSON;
			return View();
		}

		[HttpPost]
		public IActionResult Checkbox(CheckboxViewModel checkboxViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(checkboxViewModel);
			}

			string theJSON = _buildPages.BuildTheJson(checkboxViewModel);
			ViewBag.TheJSON = checkboxViewModel.TheJSON;
			PageChoiceViewModel pageChoiceViewModel = new PageChoiceViewModel() { ShowOptions = true };
			return View("PageChoice", pageChoiceViewModel);
		}

		public IActionResult Declaration(PageChoiceViewModel pageChoiceViewModel)
		{
			ViewBag.TheJSON = pageChoiceViewModel.TheJSON;
			return View();
		}

		[HttpPost]
		public IActionResult Declaration(DeclarationViewModel declarationViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(declarationViewModel);
			}

			string theJSON = _buildPages.BuildTheJson(declarationViewModel);
			ViewBag.TheJSON = declarationViewModel.TheJSON;
			PageChoiceViewModel pageChoiceViewModel = new PageChoiceViewModel() { ShowOptions = true };
			return View("PageChoice", pageChoiceViewModel);
		}

		public IActionResult FileUpload(PageChoiceViewModel pageChoiceViewModel)
		{
			ViewBag.TheJSON = pageChoiceViewModel.TheJSON;
			return View();
		}

		[HttpPost]
		public IActionResult FileUpload(FileUploadViewModel fileUploadViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(fileUploadViewModel);
			}

			//BuildPages buildPages = new BuildPages();
			string theJSON = _buildPages.BuildTheJson(fileUploadViewModel);
			ViewBag.TheJSON = fileUploadViewModel.TheJSON;
			PageChoiceViewModel pageChoiceViewModel = new PageChoiceViewModel() { ShowOptions = true };
			return View("PageChoice", pageChoiceViewModel);
		}

		public IActionResult DisplayJSON(string TheLink)
		{
			//ViewBag.TheJSON = pageChoiceViewModel.TheJSON;

			DisplayJSONViewModel viewModel = new DisplayJSONViewModel();
			viewModel.DisplayJSON = _jSONEdits.ReadJSON(TheLink);
			viewModel.TheJSON =TheLink;


			return View(viewModel);
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}