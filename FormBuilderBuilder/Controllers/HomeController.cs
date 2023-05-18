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

		public HomeController(ILogger<HomeController> logger, BuildPages buildPages)
		{
			_logger = logger;
			_buildPages = buildPages;
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

			return View("PageChoice");
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

			
			if(pageChoiceViewModel.PageChoice == "FullContactDetails")
			{
				
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

				case "FullContactDetails":
					//BuildPages buildPages = new BuildPages();
					_buildPages.BuildTheJson(pageChoiceViewModel.TheJSON);
					ViewBag.TheJSON = pageChoiceViewModel.TheJSON;
					return View("PageChoice", pageChoiceViewModel);

				case "Endform":
                    //BuildPages fbuildPages = new BuildPages();
					_buildPages.BuildTheJsonEndform(pageChoiceViewModel.TheJSON);
                    ViewBag.TheJSON = pageChoiceViewModel.TheJSON;
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

			PageChoiceViewModel pageChoiceViewModel = new PageChoiceViewModel();
			pageChoiceViewModel.TheJSON = theJSON;

			ViewBag.TheJSON = textboxViewModel.TheJSON;
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
			return View("PageChoice");
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
			return View("PageChoice");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}