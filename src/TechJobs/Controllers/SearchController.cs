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
            if (searchTerm != null && searchType != "all")
            {
                ViewBag.jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.searchTerm = searchTerm;
                return View("Index");
            }

            // If searchTerm box has something && searchType is "all"
            else if (searchTerm != null)
            {
                ViewBag.jobs = JobData.FindByValue(searchTerm);
                ViewBag.searchTerm = searchTerm;
                return View("Index");
            }

            // If searchTerm box is empty && searchType is "all"
            else if (searchTerm == null && searchType == "all")
            {
                ViewBag.jobs = JobData.FindAll();
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
