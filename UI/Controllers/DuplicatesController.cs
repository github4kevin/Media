using cloudscribe.Pagination.Models;
using Microsoft.AspNetCore.Mvc;
using UI.Interfaces;
using UI.Models;

namespace PlexUI.Controllers
{
   public class DuplicatesController : Controller
   {
      // Establish Injectable Dependancies

      private readonly IDuplicates duplicateData;

      public DuplicatesController(IDuplicates _duplicateData)
      {
         duplicateData = _duplicateData;
      }

      // Get All Duplicates //

      [HttpGet]
      public IActionResult Index(string sortOrder, int pageNumber = 1, int pageSize = 30, string GlobalSearch = null)
      {
         // ViewBags

         ViewBag.CurrentSortOrder = sortOrder;
         ViewBag.CurrentSearch = GlobalSearch;

         ViewBag.MediaNameSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MediaName" ? "MediaName" : "MediaNameDesc";
         ViewBag.MediaTypeSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MediaType" ? "MediaType" : "MediaTypeDesc";
         ViewBag.MediaFolderSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MediaFolder" ? "MediaFolder" : "MediaFolderDesc";
         ViewBag.MediaSizeSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MediaSize" ? "MediaSize" : "MediaSizeDesc";
         ViewBag.MediaDurationSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MediaDuration" ? "MediaDuration" : "MediaDurationDesc";
         ViewBag.MediaReleaseSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MediaRelease" ? "MediaRelease" : "MediaReleaseDesc";
         ViewBag.MediaBackupSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MediaBackup" ? "MediaBackup" : "MediaBackupDesc";
         ViewBag.MediaQualitySort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MediaQuality" ? "MediaQuality" : "MediaQualityDesc";

         // Search Function

         var Duplicates = from d in duplicateData.GetAll()
                          select d;

         var DuplicateCount = Duplicates.Count();

         if (!String.IsNullOrEmpty(GlobalSearch))
         {
            Duplicates = Duplicates.Where(d => d.media_name.Contains(GlobalSearch)
                                      || d.media_type.Contains(GlobalSearch)
                                      || d.media_folder.Contains(GlobalSearch));
            DuplicateCount = Duplicates.Count();
         }

         // Sorting Logic

         switch (sortOrder)
         {
            default:
               Duplicates = Duplicates.OrderBy(d => d.media_type)
                                   .ThenBy(d => d.media_folder)
                                   .ThenBy(d => d.media_name);
               break;

            case "MediaNameDesc":
               Duplicates = Duplicates.OrderByDescending(d => d.media_type)
                                   .ThenByDescending(d => d.media_folder)
                                   .ThenByDescending(d => d.media_name);
               break;

            case "MediaType":
               Duplicates = Duplicates.OrderBy(d => d.media_type)
                                    .ThenBy(d => d.media_name);
               break;

            case "MediaTypeDesc":
               Duplicates = Duplicates.OrderByDescending(d => d.media_type)
                                    .ThenByDescending(d => d.media_name);
               break;

            case "MediaQuality":
               Duplicates = Duplicates.OrderBy(d => d.media_sort_quality)
                                    .ThenBy(d => d.media_name);
               break;

            case "MediaQualityDesc":
               Duplicates = Duplicates.OrderByDescending(d => d.media_sort_quality)
                                    .ThenByDescending(d => d.media_name);
               break;               

            case "MediaFolder":
               Duplicates = Duplicates.OrderBy(d => d.media_folder)
                                    .ThenBy(d => d.media_name);
               break;

            case "MediaFolderDesc":
               Duplicates = Duplicates.OrderByDescending(d => d.media_folder)
                                    .ThenByDescending(d => d.media_name);
               break;

            case "MediaSize":
               Duplicates = Duplicates.OrderBy(d => d.media_sort_size);
               break;

            case "MediaSizeDesc":
               Duplicates = Duplicates.OrderByDescending(d => d.media_sort_size);
               break;

            case "MediaDuration":
               Duplicates = Duplicates.OrderBy(d => d.media_sort_duration);
               break;

            case "MediaDurationDesc":
               Duplicates = Duplicates.OrderByDescending(d => d.media_sort_duration);
               break;

            case "MediaRelease":
               Duplicates = Duplicates.OrderBy(d => d.media_released);
               break;

            case "MediaReleaseDesc":
               Duplicates = Duplicates.OrderByDescending(d => d.media_released);
               break;
         }

         // Pagination Results

         var ExcludeRecords = (pageSize * pageNumber) - pageSize;

         Duplicates = Duplicates
             .Skip(ExcludeRecords)
             .Take(pageSize);

         var pagedResults = new PagedResult<Duplicates>()
         {
            Data = Duplicates.ToList(),
            TotalItems = DuplicateCount,
            PageNumber = pageNumber,
            PageSize = pageSize
         };

         return View(pagedResults);

      }
   }
}