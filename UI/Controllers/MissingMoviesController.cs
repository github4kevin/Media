using cloudscribe.Pagination.Models;
using Microsoft.AspNetCore.Mvc;
using UI.Interfaces;
using UI.Models;

namespace UI.Controllers
{
    public class MissingMoviesController : Controller
    {
        // Establish Injectable Dependancies

        private readonly IMissingMovies missingmovieData;

        public MissingMoviesController(IMissingMovies _missingmovieData)
        {
            missingmovieData = _missingmovieData;
        }

        // Get All Missing Movies

        public IActionResult Index(string GlobalSearch, string sortOrder, int pageNumber = 1, int pageSize = 30)
        {
            // ViewBags

            ViewBag.CurrentSortOrder = sortOrder;
            ViewBag.CurrentSearch = GlobalSearch;

            ViewBag.MovieNameSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MovieName" ? "MovieName" : "MovieNameDesc";
            ViewBag.MovieSizeSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MovieSize" ? "MovieSize" : "MovieSizeDesc";
            ViewBag.MovieQualitySort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MovieQuality" ? "MovieQuality" : "MovieQualityDesc";
            ViewBag.MovieDurationSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MovieDuration" ? "MovieDuration" : "MovieDurationDesc";

            // Search Function

            var MissingMovies = from m in missingmovieData.GetAll()
                                select m;

            var MissingMovieCount = MissingMovies.Count();

            if (!String.IsNullOrEmpty(GlobalSearch))
            {
                MissingMovies = MissingMovies.Where(m => m.movie_name.Contains(GlobalSearch));
                MissingMovieCount = MissingMovies.Count();
            }

            // Sorting Logic

            switch (sortOrder)
            {
                default:
                    MissingMovies = MissingMovies.OrderBy(m => m.movie_name);
                    break;

                case "MovieNameDesc":
                    MissingMovies = MissingMovies.OrderByDescending(m => m.movie_name);
                    break;

                case "MovieSize":
                    MissingMovies = MissingMovies.OrderBy(m => m.movie_sort_size);
                    break;

                case "MovieSizeDesc":
                    MissingMovies = MissingMovies.OrderByDescending(m => m.movie_sort_size);
                    break;

                case "MovieQuality":
                    MissingMovies = MissingMovies.OrderBy(m => m.movie_sort_quality);
                    break;

                case "MovieQualityDesc":
                    MissingMovies = MissingMovies.OrderByDescending(m => m.movie_sort_quality);
                    break;

                case "MovieDuration":
                    MissingMovies = MissingMovies.OrderBy(m => m.movie_sort_duration);
                    break;

                case "MovieDurationDesc":
                    MissingMovies = MissingMovies.OrderByDescending(m => m.movie_sort_duration);
                    break;
            }

            // Pagination Results

            var ExcludeRecords = (pageSize * pageNumber) - pageSize;

            MissingMovies = MissingMovies
                .Skip(ExcludeRecords)
                .Take(pageSize);

            var pagedResults = new PagedResult<MissingMovies>()
            {
                Data = MissingMovies.ToList(),
                TotalItems = MissingMovieCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return View(pagedResults);
        }
    }
}