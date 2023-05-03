using cloudscribe.Pagination.Models;
using Microsoft.AspNetCore.Mvc;
using UI.Interfaces;
using UI.Models;

namespace UI.Controllers
{
   public class SeasonsController : Controller
   {
      // Establish Injectable Dependancies

      private readonly ISeasons seasonData;

      public SeasonsController(ISeasons _seasonData)
      {
         seasonData = _seasonData;
      }

      // Get All Seasons of Shows
      public IActionResult Index(string GlobalSearch, string sortOrder, int pageNumber = 1, int pageSize = 30)
      {
         // ViewBags

         ViewBag.CurrentSortOrder = sortOrder;
         ViewBag.CurrentSearch = GlobalSearch;

         ViewBag.ShowIDSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "ShowID" ? "ShowID" : "ShowID_Desc";
         ViewBag.ShowNameSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "ShowName" ? "ShowName" : "ShowNameDesc";
         ViewBag.SeasonNumberSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "SeasonNumber" ? "SeasonNumber" : "SeasonNumberDesc";
         ViewBag.SeasonEpisodeSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "SeasonEpisode" ? "SeasonEpisode" : "SeasonEpisodeDesc";
         ViewBag.SeasonSizeSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "SeasonSize" ? "SeasonSize" : "SeasonSizeDesc";
         ViewBag.SeasonQualitySort = String.IsNullOrEmpty(sortOrder) || sortOrder != "SeasonQuality" ? "SeasonQuality" : "SeasonQualityDesc";
         ViewBag.SeasonDurationSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "SeasonDuration" ? "SeasonDuration" : "SeasonDurationDesc";
         ViewBag.SeasonYearSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "SeasonYear" ? "SeasonYear" : "SeasonYearDesc";
         ViewBag.SeasonAddedDateSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "SeasonAddedDate" ? "SeasonAddedDate" : "SeasonAddedDateDesc";

         // Search Function

         var Seasons = from s in seasonData.GetAll()
                       select s;

         var SeasonCount = Seasons.Count();

         if (!String.IsNullOrEmpty(GlobalSearch))
         {
            Seasons = Seasons.Where(s => s.show_name.Contains(GlobalSearch));
            SeasonCount = Seasons.Count();
         }

         // Sorting Logic

         switch (sortOrder)
         {
            default:
               Seasons = Seasons.OrderByDescending(s => s.season_added_date)
                       .ThenByDescending(s => s.season_number)
                       .ThenByDescending(s => s.season_episodes);

               break;

            case "ShowAddedDateDesc":
               Seasons = Seasons.OrderBy(s => s.season_added_date)
                                  .ThenBy(s => s.season_number)
                                  .ThenBy(s => s.season_episodes);
               break;

            case "ShowID":
               Seasons = Seasons.OrderBy(s => s.show_id)
                                   .ThenBy(s => s.season_number);
               break;

            case "ShowID_Desc":
               Seasons = Seasons.OrderByDescending(s => s.show_id)
                                   .ThenByDescending(s => s.season_number);
               break;

            case "ShowName":
               Seasons = Seasons.OrderBy(s => s.show_name)
                                   .ThenBy(s => s.season_number)
                                   .ThenBy(s => s.season_episodes);
               break;

            case "ShowNameDesc":
               Seasons = Seasons.OrderByDescending(s => s.show_name)
                                   .ThenByDescending(s => s.season_number)
                                   .ThenByDescending(s => s.season_episodes);
               break;

            case "SeasonNumber":
               Seasons = Seasons.OrderBy(s => s.season_number);
               break;

            case "SeasonNumberDesc":
               Seasons = Seasons.OrderByDescending(s => s.season_number);
               break;

            case "SeasonEpisode":
               Seasons = Seasons.OrderBy(s => s.season_episodes);
               break;

            case "SeasonEpisodeDesc":
               Seasons = Seasons.OrderByDescending(s => s.season_episodes);
               break;

            case "SeasonSize":
               Seasons = Seasons.OrderBy(s => s.season_sort_size);
               break;

            case "SeasonSizeDesc":
               Seasons = Seasons.OrderByDescending(s => s.season_sort_size);
               break;

            case "SeasonStudio":
               Seasons = Seasons.OrderBy(s => s.season_studio);
               break;

            case "SeasonStudioDesc":
               Seasons = Seasons.OrderByDescending(s => s.season_studio);
               break;

            case "SeasonQuality":
               Seasons = Seasons.OrderBy(s => s.season_sort_quality);
               break;

            case "SeasonQualityDesc":
               Seasons = Seasons.OrderByDescending(s => s.season_sort_quality);
               break;

            case "SeasonDuration":
               Seasons = Seasons.OrderBy(s => s.season_sort_duration);
               break;

            case "SeasonDurationDesc":
               Seasons = Seasons.OrderByDescending(s => s.season_sort_size);
               break;

            case "SeasonYear":
               Seasons = Seasons.OrderBy(s => s.season_release_year);
               break;

            case "SeasonYearDesc":
               Seasons = Seasons.OrderByDescending(s => s.season_release_year);
               break;
         }

         // Pagination Results

         var ExcludeRecords = (pageSize * pageNumber) - pageSize;

         Seasons = Seasons
             .Skip(ExcludeRecords)
             .Take(pageSize);

         var pagedResults = new PagedResult<Seasons>()
         {
            Data = Seasons.ToList(),
            TotalItems = SeasonCount,
            PageNumber = pageNumber,
            PageSize = pageSize
         };

         return View(pagedResults);
      }
   }
}