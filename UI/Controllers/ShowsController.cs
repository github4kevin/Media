using cloudscribe.Pagination.Models;
using Microsoft.AspNetCore.Mvc;
using UI.Interfaces;
using UI.Models;

namespace UI.Controllers
{
   public class ShowsController : Controller
   {
      // Establish Injectable Dependancies

      private readonly IShows showData;

      public ShowsController(IShows _showData)
      {
         showData = _showData;
      }

      // Get All Shows
      public IActionResult Index(string GlobalSearch, string sortOrder, int pageNumber = 1, int pageSize = 30)
      {
         // ViewBags

         ViewBag.CurrentSortOrder = sortOrder;
         ViewBag.CurrentSearch = GlobalSearch;

         ViewBag.ShowIDSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "ShowID" ? "ShowID" : "ShowID_Desc";

         ViewBag.ShowNameSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "ShowName" ? "ShowName" : "ShowNameDesc";

         ViewBag.ShowSeasonSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "ShowSeason" ? "ShowSeason" : "ShowSeasonDesc";
         ViewBag.ShowEpisodeSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "ShowEpisode" ? "ShowEpisode" : "ShowEpisodeDesc";
         ViewBag.ShowSizeSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "ShowSize" ? "ShowSize" : "ShowSizeDesc";
         ViewBag.ShowQualitySort = String.IsNullOrEmpty(sortOrder) || sortOrder != "ShowQuality" ? "ShowQuality" : "ShowQualityDesc";
         ViewBag.ShowReleaseDateSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "ShowReleaseDate" ? "ShowReleaseDate" : "ShowReleaseDateDesc";
         ViewBag.ShowDurationSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "ShowDurationDesc" ? "ShowDurationDesc" : "ShowDuration";
         ViewBag.ShowAddedDateSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "ShowAddedDate" ? "ShowAddedDate" : "ShowAddedDateDesc";
         ViewBag.ShowRatingSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "ShowRating" ? "ShowRating" : "ShowRatingDesc";
         ViewBag.ShowContentRatingSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "ShowContentRating" ? "ShowContentRating" : "ShowContentRatingDesc";

            // Search Function

            var Shows = from s in showData.GetAll()
                     select s;

         var ShowCount = Shows.Count();

         if (!String.IsNullOrEmpty(GlobalSearch))
         {
            Shows = Shows.Where(s => s.show_name.Contains(GlobalSearch)
                                    || s.show_content_rating.Contains(GlobalSearch));
            ShowCount = Shows.Count();
         }

         // Sorting Logic

         switch (sortOrder)
         {
            default:
               Shows = Shows.OrderByDescending(s => s.show_added_date);
               break;

            case "ShowAddedDate":
               Shows = Shows.OrderBy(s => s.show_added_date);
               break;

            case "ShowID":
               Shows = Shows.OrderBy(s => s.show_id);
               break;

            case "ShowID_Desc":
               Shows = Shows.OrderByDescending(s => s.show_id);
               break;

            case "ShowName":
               Shows = Shows.OrderBy(s => s.show_name);
               break;

            case "ShowNameDesc":
               Shows = Shows.OrderByDescending(s => s.show_name);
               break;               

            case "ShowSize":
               Shows = Shows.OrderBy(s => s.show_sort_size)
                                .ThenBy(s => s.show_name);
               break;

            case "ShowSizeDesc":
               Shows = Shows.OrderByDescending(s => s.show_sort_size)
                                .ThenByDescending(s => s.show_name);
               break;

            case "ShowDuration":
               Shows = Shows.OrderBy(s => s.show_sort_duration);
               break;

            case "ShowDurationDesc":
               Shows = Shows.OrderByDescending(s => s.show_sort_duration);
               break;

            case "ShowQuality":
               Shows = Shows.OrderBy(s => s.show_sort_quality);
               break;

            case "ShowQualityDesc":
               Shows = Shows.OrderByDescending(s => s.show_sort_quality);
               break;

            case "ShowSeason":
               Shows = Shows.OrderBy(s => s.show_seasons);
               break;

            case "ShowSeasonDesc":
               Shows = Shows.OrderByDescending(s => s.show_seasons);
               break;

            case "ShowEpisode":
               Shows = Shows.OrderBy(s => s.show_episodes);
               break;

            case "ShowEpisodeDesc":
               Shows = Shows.OrderByDescending(s => s.show_episodes);
               break;

            case "ShowReleaseDate":
               Shows = Shows.OrderBy(s => s.show_release_date);
               break;

            case "ShowReleaseDateDesc":
               Shows = Shows.OrderByDescending(s => s.show_release_date);
               break;

            case "ShowContentRating":
                Shows = Shows.OrderBy(s => s.show_content_rating);
                break;

            case "ShowContentRatingDesc":
                Shows = Shows.OrderByDescending(s => s.show_content_rating);
                break;

            case "ShowRatingDate":
                Shows = Shows.OrderBy(s => s.show_rating);
                break;

            case "ShowRatingDateDesc":
                Shows = Shows.OrderByDescending(s => s.show_rating);
                break;
            }

         // Formulate Pagination Results

         var ExcludeRecords = (pageSize * pageNumber) - pageSize;

         Shows = Shows
             .Skip(ExcludeRecords)
             .Take(pageSize);

         var pagedResults = new PagedResult<Shows>()
         {
            Data = Shows.ToList(),
            TotalItems = ShowCount,
            PageNumber = pageNumber,
            PageSize = pageSize
         };

         return View(pagedResults);
      }

      // Get Individual Show

      public IActionResult Details(int id)
      {
         // ViewBag for Next Button

         var nextID = showData.GetAll()
                         .OrderBy(i => i.show_id)
                         .Where(i => i.show_id > id)
                         .Select(i => i.show_id)
                         .FirstOrDefault();

         ViewBag.NextID = nextID;

         // ViewBag for Previous Button
         var previousID = showData.GetAll()
                         .OrderBy(i => i.show_id)
                         .Reverse()
                         .Where(i => i.show_id < id)
                         .Select(i => i.show_id)
                         .FirstOrDefault();

         ViewBag.PreviousID = previousID;

         // Retrieve Details for Single Record

         var singleShow = showData.Find(id);

         if (singleShow == null)
         {
            return NotFound();
         }

         return View(singleShow);
      }
   }
}