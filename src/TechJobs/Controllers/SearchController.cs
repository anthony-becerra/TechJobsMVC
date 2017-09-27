using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        public IActionResult Results(string searchType, string searchTerm) // searchType & searchTerm taken from Views/Search/Index.cshtml form.
        {
            ViewBag.columns = ListController.columnChoices;

            // if user enters searchTerm, find jobs by searchTerm and pass them into the Views/Search/Index.cshtml view.
            if (searchTerm != null)
            {
                ViewBag.jobs = JobData.FindByValue(searchTerm);
                ViewBag.searchTerm = searchTerm;
                return View("Index");
            }

            // else return back to SearchController > Index action method.
            else
            {
                return Redirect("/search");
            }
        }
    }
}
