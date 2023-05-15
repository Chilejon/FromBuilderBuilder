using FormBuilderBuilder.Models;
using FormBuilderBuilder.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FormBuilderBuilder.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
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

				case "FullContactDetails":
                    BuildPages buildPages = new BuildPages();
                    buildPages.BuildTheJson(pageChoiceViewModel.TheJSON);

					ViewBag.TheJSON = pageChoiceViewModel.TheJSON;
					return View("PageChoice", pageChoiceViewModel);

                case "Summary":
                    BuildPages sbuildPages = new BuildPages();
                    sbuildPages.BuildTheJsonSummary(pageChoiceViewModel.TheJSON);

                    ViewBag.TheJSON = pageChoiceViewModel.TheJSON;
                    return View("PageChoice", pageChoiceViewModel);

                case "Footer":
                    BuildPages fbuildPages = new BuildPages();
                    fbuildPages.BuildTheJsonFooter(pageChoiceViewModel.TheJSON);

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

			BuildPages buildPages = new BuildPages();
			string theJSON = buildPages.BuildTheJson(textboxViewModel);

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

			BuildPages buildPages = new BuildPages();
			string theJSON = buildPages.BuildTheJson(textareaViewModel);
			ViewBag.TheJSON = textareaViewModel.TheJSON;
			return View("PageChoice");
		}

		public IActionResult Radio(PageChoiceViewModel pageChoiceViewModel)
		{
			ViewBag.TheJSON = pageChoiceViewModel.TheJSON;
			return View();
		}

		[HttpPost]
		public IActionResult Radio(TextboxViewModel textareaViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(textareaViewModel);
			}

			BuildPages buildPages = new BuildPages();
			string theJSON = buildPages.BuildTheJson(textareaViewModel);
			return View("PageChoice");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}