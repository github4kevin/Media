using cloudscribe.Pagination.Models;
using Microsoft.AspNetCore.Mvc;
using UI.Interfaces;
using UI.Models;

namespace UI.Controllers
{
   public class NamingController : Controller
   {
      // Establish Injectable Dependancies

      private readonly INaming namingData;

      public NamingController(INaming _namingData)
      {
         namingData = _namingData;
      }

      // Get All Episode Names

      public IActionResult Index(string GlobalSearch, string sortOrder, int pageNumber = 1, int pageSize = 15)
      {
         // ViewBags

         ViewBag.CurrentSortOrder = sortOrder;
         ViewBag.CurrentSearch = GlobalSearch;
         ViewBag.ShowNameSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "ShowName" ? "ShowName" : "ShowNameDesc";
         ViewBag.SeasonNumberSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "SeasonNumber" ? "SeasonNumber" : "SeasonNumberDesc";
         ViewBag.TotalEpisodeSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "TotalEpisode" ? "TotalEpisode" : "TotalEpisodeDesc";
         ViewBag.TotalSizeSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "TotalSize" ? "TotalSize" : "TotalSizeDesc";
         ViewBag.DurationSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "Duration" ? "Duration" : "DurationDesc";

         // Search Function

         var Naming = from n in namingData.GetAll()
                      select n;

         var NamingCount = Naming.Count();

         if (!String.IsNullOrEmpty(GlobalSearch))
         {
            Naming = Naming.Where(n => n.library_name.Contains(GlobalSearch)
                                    || n.show_name.Contains(GlobalSearch));
            NamingCount = Naming.Count();
         }

         // Sorting Logic

         switch (sortOrder)
         {
            default:
               Naming = Naming.OrderBy(n => n.library_name).ThenBy(n => n.show_name).ThenBy(n => n.season_number);
               break;

            case "LibraryNameDesc":
               Naming = Naming.OrderByDescending(n => n.library_name).ThenByDescending(n => n.show_name).ThenByDescending(n => n.season_number);
               break;

            case "FolderName":
               Naming = Naming.OrderBy(n => n.show_name).ThenBy(n => n.season_number);
               break;

            case "FolderNameDesc":
               Naming = Naming.OrderByDescending(n => n.show_name).ThenByDescending(n => n.season_number);
               break;

            case "ShowName":
               Naming = Naming.OrderBy(n => n.show_name).ThenBy(n => n.season_number);
               break;

            case "ShowNameDesc":
               Naming = Naming.OrderByDescending(n => n.show_name).ThenByDescending(n => n.season_number);
               break;

            case "TotalEpisode":
               Naming = Naming.OrderBy(n => n.total_episodes);
               break;

            case "TotalEpisodeDesc":
               Naming = Naming.OrderByDescending(n => n.total_episodes);
               break;

            case "Duration":
               Naming = Naming.OrderBy(n => n.total_sort_duration);
               break;

            case "DurationDesc":
               Naming = Naming.OrderByDescending(n => n.total_sort_duration);
               break;


            case "TotalSize":
               Naming = Naming.OrderBy(n => n.total_sort_size);
               break;

            case "TotalSizeDesc":
               Naming = Naming.OrderByDescending(n => n.total_sort_size);
               break;
         }

         // Pagination Results

         var ExcludeRecords = (pageSize * pageNumber) - pageSize;

         Naming = Naming
             .Skip(ExcludeRecords)
             .Take(pageSize);

         var pagedResults = new PagedResult<Naming>()
         {
            Data = Naming.ToList(),
            TotalItems = NamingCount,
            PageNumber = pageNumber,
            PageSize = pageSize
         };

         return View(pagedResults);
      }
   }
}