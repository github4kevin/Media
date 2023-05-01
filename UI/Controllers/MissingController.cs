using cloudscribe.Pagination.Models;
using Microsoft.AspNetCore.Mvc;
using UI.Interfaces;
using UI.Models;

namespace UI.Controllers
{
    public class MissingController : Controller
    {
        // Establish Injectable Dependancies

        private readonly IMissing missingData;

        public MissingController(IMissing _missingData)
        {
            missingData = _missingData;
        }

        // Get All Missing Movies

        public IActionResult Index(string GlobalSearch, string sortOrder, int pageNumber = 1, int pageSize = 30)
        {
            // ViewBags

            ViewBag.CurrentSortOrder = sortOrder;
            ViewBag.CurrentSearch = GlobalSearch;

            ViewBag.MovieNameSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MovieName" ? "MovieName" : "MovieNameDesc";
            ViewBag.MovieFileType = String.IsNullOrEmpty(sortOrder) || sortOrder != "MovieFileType" ? "MovieFileType" : "MovieFileTypeDesc";
            ViewBag.MovieSizeSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MovieSize" ? "MovieSize" : "MovieSizeDesc";
            ViewBag.MovieQualitySort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MovieQuality" ? "MovieQuality" : "MovieQualityDesc";
            ViewBag.MovieDurationSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MovieDuration" ? "MovieDuration" : "MovieDurationDesc";

            // Search Function

            var Missing = from m in missingData.GetAll()
                                select m;

            var MissingCount = Missing.Count();

            if (!String.IsNullOrEmpty(GlobalSearch))
            {
                Missing = Missing.Where(m => m.movie_name.Contains(GlobalSearch));
                MissingCount = Missing.Count();
            }

            // Sorting Logic

            switch (sortOrder)
            {
                default:
                    Missing = Missing.OrderBy(m => m.movie_name);
                    break;

                case "MovieNameDesc":
                    Missing = Missing.OrderByDescending(m => m.movie_name);
                    break;

                case "MovieSize":
                    Missing = Missing.OrderBy(m => m.movie_sort_size);
                    break;

                case "MovieSizeDesc":
                    Missing = Missing.OrderByDescending(m => m.movie_sort_size);
                    break;

                case "MovieQuality":
                    Missing = Missing.OrderBy(m => m.movie_sort_quality);
                    break;

                case "MovieQualityDesc":
                    Missing = Missing.OrderByDescending(m => m.movie_sort_quality);
                    break;

                case "MovieFileType":
                    Missing = Missing.OrderBy(m => m.movie_file_type);
                    break;

                case "MovieFileTypeDesc":
                    Missing = Missing.OrderByDescending(m => m.movie_file_type);
                    break;
            }

            // Pagination Results

            var ExcludeRecords = (pageSize * pageNumber) - pageSize;

            Missing = Missing
                .Skip(ExcludeRecords)
                .Take(pageSize);

            var pagedResults = new PagedResult<Missing>()
            {
                Data = Missing.ToList(),
                TotalItems = MissingCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return View(pagedResults);
        }
    }
}