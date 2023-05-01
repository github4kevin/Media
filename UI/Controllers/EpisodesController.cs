using cloudscribe.Pagination.Models;
using Microsoft.AspNetCore.Mvc;
using UI.Interfaces;
using UI.Models;

namespace PlexUI.Controllers
{
   public class EpisodesController : Controller
   {
      // Establish Injectable Dependancies

      private readonly IEpisodes episodeData;

      public EpisodesController(IEpisodes _episodeData)
      {
         episodeData = _episodeData;
      }

      // Get All Episodes //

      [HttpGet]
      public IActionResult Index(string sortOrder, int pageNumber = 1, int pageSize = 30, string GlobalSearch = null)
      {
         // ViewBags

         ViewBag.CurrentSortOrder = sortOrder;
         ViewBag.CurrentSearch = GlobalSearch;

         ViewBag.FolderNameSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "FolderName" ? "FolderName" : "FolderNameDesc";
         ViewBag.ShowNameSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "ShowName" ? "ShowName" : "ShowNameDesc";
         ViewBag.ServerNameSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "ServerName" ? "ServerName" : "ServerNameDesc";
         ViewBag.EpisodeNameSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "EpisodeName" ? "EpisodeName" : "ShowNameDesc";
         ViewBag.EpisodeSizeSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "EpisodeSize" ? "EpisodeSize" : "EpisodeSizeDesc";
         ViewBag.EpisodeQualitySort = String.IsNullOrEmpty(sortOrder) || sortOrder != "EpisodeQuality" ? "EpisodeQuality" : "EpisodeQualityDesc";
         ViewBag.EpisodeDurationSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "EpisodeDuration" ? "EpisodeDuration" : "EpisodeDurationDesc";
         ViewBag.EpisodeAddedDateSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "EpisodeAddedDate" ? "EpisodeAddedDate" : "EpisodeAddedDateDesc";

         // Search Function

         var Episodes = from x in episodeData.GetAll()
                        select x;

         var EpisodeCount = Episodes.Count();

         if (!String.IsNullOrEmpty(GlobalSearch))
         {
            Episodes = Episodes.Where(x => x.show_name.Contains(GlobalSearch)
                                         || x.episode_name.Contains(GlobalSearch));
            EpisodeCount = Episodes.Count();
         }

         // Sorting Logic

         switch (sortOrder)
         {

            default:
               Episodes = Episodes.OrderByDescending(x => x.episode_added_date);
               break;

            case "EpisodeAddedDate":
               Episodes = Episodes.OrderBy(x => x.episode_added_date);
               break;


            case "ShowName":
               Episodes = Episodes.OrderBy(x => x.show_name)
                                    .ThenBy(x => x.season_number)
                                    .ThenBy(x => x.episode_number);
               break;

            case "ShowNameDesc":
               Episodes = Episodes.OrderByDescending(x => x.show_name)
                                    .ThenByDescending(x => x.season_number)
                                    .ThenByDescending(x => x.episode_number);
               break;

            case "FolderName":
               Episodes = Episodes.OrderBy(x => x.show_name)
                                    .ThenBy(x => x.season_number)
                                    .ThenBy(x => x.episode_number);
               break;

            case "FolderNameDesc":
               Episodes = Episodes.OrderByDescending(x => x.show_name)
                                    .ThenByDescending(x => x.season_number)
                                    .ThenByDescending(x => x.episode_number);
               break;

            case "EpisodeSize":
               Episodes = Episodes.OrderBy(x => x.episode_sort_size);
               break;

            case "EpisodeSizeDesc":
               Episodes = Episodes.OrderByDescending(x => x.episode_sort_size);
               break;

            case "EpisodeDuration":
               Episodes = Episodes.OrderBy(x => x.episode_sort_duration);
               break;

            case "EpisodeDurationDesc":
               Episodes = Episodes.OrderByDescending(x => x.episode_sort_duration);
               break;

            case "EpisodeQuality":
               Episodes = Episodes.OrderBy(x => x.episode_sort_quality);
               break;

            case "EpisodeQualityDesc":
               Episodes = Episodes.OrderByDescending(x => x.episode_sort_quality);
               break;
         }

         // Pagination Results

         var ExcludeRecords = (pageSize * pageNumber) - pageSize;

         Episodes = Episodes
             .Skip(ExcludeRecords)
             .Take(pageSize);

         var pagedResults = new PagedResult<Episodes>()
         {
            Data = Episodes.ToList(),
            TotalItems = EpisodeCount,
            PageNumber = pageNumber,
            PageSize = pageSize
         };

         return View(pagedResults);
      }
   }
}