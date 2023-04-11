using cloudscribe.Pagination.Models;
using Microsoft.AspNetCore.Mvc;
using UI.Interfaces;
using UI.Models;

namespace UI.Controllers
{
   public class LibrariesController : Controller
   {
      // Establish Injectable Dependancies

      private readonly ILibraries libraryData;

      public LibrariesController(ILibraries _libraryData)
      {
         libraryData = _libraryData;
      }

      // Get All Libraries

      public ActionResult Index(string GlobalSearch, string sortOrder, int pageNumber = 1, int pageSize = 30)
      {
         // ViewBags

         ViewBag.CurrentSortOrder = sortOrder;
         ViewBag.CurrentSearch = GlobalSearch;

         ViewBag.LibraryNameSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "LibraryName" ? "LibraryName" : "LibraryNameDesc";
         ViewBag.ShowTotalSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "ShowTotal" ? "ShowTotal" : "ShowTotalDesc";
         ViewBag.SDTotalSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "SDTotal" ? "SDTotal" : "SDTotalDesc";
         ViewBag.HDTotalSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "HDTotal" ? "HDTotal" : "HDTotalDesc";
         ViewBag.LibraryTotalSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "LibraryTotal" ? "LibraryTotal" : "LibraryTotalDesc";
         ViewBag.LibrarySizeSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "LibrarySize" ? "LibrarySize" : "LibrarySizeDesc";
         ViewBag.LibraryDurationSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "LibraryDuration" ? "LibraryDuration" : "LibraryDurationDesc";
         ViewBag.ScannedDateSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "ScannedDate" ? "ScannedDate" : "ScannedDateDesc";

         // Search Function

         var Libraries = from L in libraryData.GetAll()
                         select L;

         var LibraryCount = Libraries.Count();

         if (!String.IsNullOrEmpty(GlobalSearch))
         {
            Libraries = Libraries.Where(L => L.library_name.Contains(GlobalSearch));
            LibraryCount = Libraries.Count();
         }

         // Sorting Logic

         switch (sortOrder)
         {
            default:
               Libraries = Libraries.OrderBy(L => L.library_name);
               break;

            case "LibraryNameDesc":
               Libraries = Libraries.OrderByDescending(L => L.library_name);
               break;

            case "ShowTotal":
               Libraries = Libraries.OrderBy(L => L.show_total);
               break;

            case "ShowTotalDesc":
               Libraries = Libraries.OrderByDescending(L => L.show_total);
               break;

            case "LibraryTotal":
               Libraries = Libraries.OrderBy(L => L.library_total);
               break;

            case "LibraryTotalDesc":
               Libraries = Libraries.OrderByDescending(L => L.library_total);
               break;

            case "LibrarySize":
               Libraries = Libraries.OrderBy(L => L.library_sort_size);
               break;

            case "LibrarySizeDesc":
               Libraries = Libraries.OrderByDescending(L => L.library_sort_size);
               break;

            case "ScannedDate":
               Libraries = Libraries.OrderBy(L => L.library_scanned_date);
               break;

            case "ScannedDateDesc":
               Libraries = Libraries.OrderByDescending(L => L.library_scanned_date);
               break;

            case "SDTotal":
               Libraries = Libraries.OrderBy(L => L.sd_total);
               break;

            case "SDTotalDesc":
               Libraries = Libraries.OrderByDescending(L => L.sd_total);
               break;

            case "HDTotal":
               Libraries = Libraries.OrderBy(L => L.hd_total);
               break;

            case "HDTotalDesc":
               Libraries = Libraries.OrderByDescending(L => L.hd_total);
               break;

            case "LibraryDuration":
               Libraries = Libraries.OrderBy(L => L.library_sort_duration);
               break;

            case "LibraryDurationDesc":
               Libraries = Libraries.OrderByDescending(L => L.library_sort_duration);
               break;
            }

         // Pagination Results

         var ExcludeRecords = (pageSize * pageNumber) - pageSize;

         Libraries = Libraries
             .Skip(ExcludeRecords)
             .Take(pageSize);

         var pagedResults = new PagedResult<Libraries>()
         {
            Data = Libraries.ToList(),
            TotalItems = LibraryCount,
            PageNumber = pageNumber,
            PageSize = pageSize
         };

         return View(pagedResults);
      }
   }
}