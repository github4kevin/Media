using cloudscribe.Pagination.Models;
using Microsoft.AspNetCore.Mvc;
using UI.Interfaces;
using UI.Models;

namespace UI.Controllers
{
   public class MoviesController : Controller
   {
      // Establish Injectable Dependancies

      private readonly IMovies movieData;

      public MoviesController(IMovies _movieData)
      {
         movieData = _movieData;
      }

      // Get All Movies

      public IActionResult Index(string GlobalSearch, string sortOrder, int pageNumber = 1, int pageSize = 30)
      {
         // ViewBags

         ViewBag.CurrentSortOrder = sortOrder;
         ViewBag.CurrentSearch = GlobalSearch;

         ViewBag.MovieIDSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MovieID" ? "MovieID" : "MovieIDDesc";
         ViewBag.MovieNameSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MovieName" ? "MovieName" : "MovieNameDesc";
         ViewBag.MovieSizeSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MovieSize" ? "MovieSize" : "MovieSizeDesc";
         ViewBag.MovieQualitySort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MovieQuality" ? "MovieQuality" : "MovieQualityDesc";
         ViewBag.MovieDurationSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MovieDuration" ? "MovieDuration" : "MovieDurationDesc";
         ViewBag.MovieReleaseDateSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MovieReleaseDate" ? "MovieReleaseDate" : "MovieReleaseDateDesc";
         ViewBag.MovieAddedDateSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MovieAddedDate" ? "MovieAddedDate" : "MovieAddedDateDesc";
        ViewBag.MovieContentRatingSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MovieContentRating" ? "MovieContentRating" : "MovieContentRatingDesc";
        ViewBag.MovieAudienceSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MovieAudience" ? "MovieAudience" : "MovieAudienceDesc";   
         ViewBag.MovieCriticSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MovieCritic" ? "MovieCritic" : "MovieCriticDesc";           
         ViewBag.MovieFPSSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MovieFPS" ? "MovieFPS" : "MovieFPSDesc";   
         ViewBag.MovieFileTypeSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MovieFileType" ? "MovieFileType" : "MovieFileTypeDesc";            

         // Search Function

         var Movies = from m in movieData.GetAll()
                      select m;

         var MovieCount = Movies.Count();

         if (!String.IsNullOrEmpty(GlobalSearch))
         {
            Movies = Movies.Where(m => m.movie_name.Contains(GlobalSearch)
                                    || m.movie_content_rating.Contains(GlobalSearch));
            MovieCount = Movies.Count();
         }

         // Sorting Logic

         switch (sortOrder)
         {
            default:
               Movies = Movies.OrderByDescending(m => m.movie_added_date);
               break;

            case "MovieAddedDate":
               Movies = Movies.OrderBy(m => m.movie_added_date);
               break;

            case "MovieID":
               Movies = Movies.OrderBy(m => m.movie_id);
               break;

            case "MovieIDDesc":
               Movies = Movies.OrderByDescending(m => m.movie_id);
               break;

            case "MovieSize":
               Movies = Movies.OrderBy(m => m.movie_sort_size);
               break;

            case "MovieSizeDesc":
               Movies = Movies.OrderByDescending(m => m.movie_sort_size);
               break;

            case "MovieQuality":
               Movies = Movies.OrderBy(m => m.movie_sort_quality);
               break;

            case "MovieQualityDesc":
               Movies = Movies.OrderByDescending(m => m.movie_sort_quality);
               break;

            case "MovieDuration":
               Movies = Movies.OrderBy(m => m.movie_sort_duration);
               break;

            case "MovieDurationDesc":
               Movies = Movies.OrderByDescending(m => m.movie_sort_duration);
               break;

            case "MovieReleaseDate":
               Movies = Movies.OrderBy(m => m.movie_release_date);
               break;

            case "MovieReleaseDateDesc":
               Movies = Movies.OrderByDescending(m => m.movie_release_date);
               break;

            case "MovieName":
               Movies = Movies.OrderBy(m => m.movie_name);
               break;

            case "MovieNameDesc":
               Movies = Movies.OrderByDescending(m => m.movie_name);
               break;

            case "MovieAudience":
               Movies = Movies.OrderBy(m => m.movie_audience_rating);
               break;

            case "MovieAudienceDesc":
               Movies = Movies.OrderByDescending(m => m.movie_audience_rating);
               break;   

            case "MovieCritic":
               Movies = Movies.OrderBy(m => m.movie_critic_rating);
               break;

            case "MovieCriticeDesc":
               Movies = Movies.OrderByDescending(m => m.movie_critic_rating);
               break;

            case "MovieContentRating":
                Movies = Movies.OrderBy(m => m.movie_content_rating);
                break;

            case "MovieContentRatingDesc":
                Movies = Movies.OrderByDescending(m => m.movie_content_rating);
                break;

            case "MovieFPS":
                Movies = Movies.OrderBy(m => m.movie_fps);
                break;

            case "MovieFPSDesc":
               Movies = Movies.OrderByDescending(m => m.movie_fps);
               break;       

            case "MovieFileType":
               Movies = Movies.OrderBy(m => m.movie_file_type);
               break;

            case "MovieFileTypeDesc":
               Movies = Movies.OrderByDescending(m => m.movie_file_type);
               break;                                        

         }

         // Pagination Results

         var ExcludeRecords = (pageSize * pageNumber) - pageSize;

         Movies = Movies
             .Skip(ExcludeRecords)
             .Take(pageSize);

         var pagedResults = new PagedResult<Movies>()
         {
            Data = Movies.ToList(),
            TotalItems = MovieCount,
            PageNumber = pageNumber,
            PageSize = pageSize
         };

         return View(pagedResults);
      }

      // Get Individual Movie //

      public IActionResult Details(int id)
      {
         // ViewBag for Next Button
         var nextID = movieData.GetAll()
                         .OrderBy(i => i.movie_id)
                         .Where(i => i.movie_id > id)
                         .Select(i => i.movie_id)
                         .FirstOrDefault();

         ViewBag.NextID = nextID;

         // ViewBag for Previous Button
         var previousID = movieData.GetAll()
                         .OrderBy(i => i.movie_id)
                         .Reverse()
                         .Where(i => i.movie_id < id)
                         .Select(i => i.movie_id)
                         .FirstOrDefault();

         ViewBag.PreviousID = previousID;

         // Retrieve Details for Single Record

         var singleMovie = movieData.Find(id);
         if (singleMovie == null)
         {
            return NotFound();
         }

         return View(singleMovie);
      }
   }
}