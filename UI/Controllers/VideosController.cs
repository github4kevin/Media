using cloudscribe.Pagination.Models;
using Microsoft.AspNetCore.Mvc;
using UI.Interfaces;
using UI.Models;

namespace PlexUI.Controllers
{
   public class VideosController : Controller
   {

      // Establish Injectable Dependancies

      private readonly IVideos videoData;

      public VideosController(IVideos _videoData)
      {
         videoData = _videoData;
      }
      // Get All Video Records
      public IActionResult Index(string GlobalSearch, string sortOrder, int pageNumber = 1, int pageSize = 30)
      {
         // ViewBags

         ViewBag.CurrentSortOrder = sortOrder;
         ViewBag.CurrentSearch = GlobalSearch;

         ViewBag.VideoIDSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "VideoID" ? "VideoID" : "VideoID_Desc";
         ViewBag.VideoNameSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "VideoName" ? "VideoName" : "VideoNameDesc";
         ViewBag.FolderNameSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "FolderName" ? "FolderName" : "FolderNameDesc";
         ViewBag.VideoSizeSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "VideoSize" ? "VideoSize" : "VideoSizeDesc";
         ViewBag.VideoDurationSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "VideoDuration" ? "VideoDuration" : "VideoDurationDesc";
         ViewBag.VideoQualitySort = String.IsNullOrEmpty(sortOrder) || sortOrder != "VideoQuality" ? "VideoQuality" : "VideoQualityDesc";

         // Search Function

         var Videos = from v in videoData.GetAll()
                      select v;

         var VideoCount = Videos.Count();

         if (!String.IsNullOrEmpty(GlobalSearch))
         {
            Videos = Videos.Where(v => v.video_name.Contains(GlobalSearch));
            VideoCount = Videos.Count();
         }

         // Sorting Logic

         switch (sortOrder)
         {
            default:
               Videos = Videos.OrderBy(v => v.video_name);
               break;

            case "VideoNameDesc":
               Videos = Videos.OrderByDescending(v => v.video_name);
               break;

            case "VideoSize":
               Videos = Videos.OrderBy(v => v.video_sort_size);
               break;

            case "VideoSizeDesc":
               Videos = Videos.OrderByDescending(v => v.video_sort_size);
               break;

            case "VideoDuration":
               Videos = Videos.OrderBy(v => v.video_sort_duration);
               break;

            case "VideoDurationDesc":
               Videos = Videos.OrderByDescending(v => v.video_sort_duration);
               break;

            case "VideoQuality":
               Videos = Videos.OrderBy(v => v.video_sort_quality);
               break;

            case "VideoQualityDesc":
               Videos = Videos.OrderByDescending(v => v.video_sort_quality);
               break;
         }

         // Formulate Pagination Results

         var ExcludeRecords = (pageSize * pageNumber) - pageSize;

         Videos = Videos
             .Skip(ExcludeRecords)
             .Take(pageSize);

         var pagedResults = new PagedResult<Videos>()
         {
            Data = Videos.ToList(),
            TotalItems = VideoCount,
            PageNumber = pageNumber,
            PageSize = pageSize
         };

         return View(pagedResults);

      }
   }
}
