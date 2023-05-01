using cloudscribe.Pagination.Models;
using Microsoft.AspNetCore.Mvc;
using UI.Interfaces;
using UI.Models;

namespace PlexUI.Controllers
{
    public class MusicController : Controller
    {
        // Establish Injectable Dependancies

        private readonly IMusic musicData;

        public MusicController(IMusic _musicData)
        {
            musicData = _musicData;
        }

        // Get All Music

        public IActionResult Index(string GlobalSearch, string sortOrder, int pageNumber = 1, int pageSize = 30)
        {
            // ViewBags

            ViewBag.CurrentSortOrder = sortOrder;
            ViewBag.CurrentSearch = GlobalSearch;

            ViewBag.MusicIDSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MusicID" ? "MusicID" : "MusicID_Desc";
            ViewBag.MusicNameSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MusicName" ? "MusicName" : "MusicNameDesc";
            ViewBag.FolderNameSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "FolderName" ? "FolderName" : "FolderNameDesc";
            ViewBag.ArtistNameSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "ArtistName" ? "ArtistName" : "ArtistNameDesc";
            ViewBag.AlbumNameSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "AlbumName" ? "AlbumName" : "AlbumNameDesc";
            ViewBag.MusicStudioSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MusicStudio" ? "MusicStudio" : "MusicStudioDesc";
            ViewBag.MusicGenreSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MusicGenre" ? "MusicGenre" : "MusicGenreDesc";
            ViewBag.MusicSizeSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MusicSize" ? "MusicSize" : "MusicSizeDesc";
            ViewBag.FileNameSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "FileName" ? "FileName" : "FileNameDesc";
            ViewBag.MusicCountrySort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MusicCountry" ? "MusicCountry" : "MusicCountryDesc";
            ViewBag.MusicDurationSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MusicDuration" ? "MusicDuration" : "MusicDurationDesc";
            ViewBag.MusicDateAddedSort = String.IsNullOrEmpty(sortOrder) || sortOrder != "MusicDateAdded" ? "MusicDateAdded" : "MusicDateAdded_Desc";

            // Search Function

            var Music = from m in musicData.GetAll()
                        select m;

            var MusicCount = Music.Count();

            if (!String.IsNullOrEmpty(GlobalSearch))
            {
                Music = Music.Where(m => m.music_name.Contains(GlobalSearch)
                                        || m.artist_name.Contains(GlobalSearch)
                                        || m.album_name.Contains(GlobalSearch)
                                        || m.music_studio.Contains(GlobalSearch)
                                        || m.music_genre.Contains(GlobalSearch));
                MusicCount = Music.Count();
            }

            // Sorting Logic

            switch (sortOrder)
            {
                default:
                    Music = Music.OrderByDescending(m => m.music_added_date);
                    break;

                case "MusicDateAdded":
                    Music = Music.OrderBy(m => m.music_added_date);
                    break;

                case "MusicID":
                    Music = Music.OrderBy(m => m.music_id);
                    break;

                case "MusicID_Desc":
                    Music = Music.OrderByDescending(m => m.music_id);
                    break;

                case "MusicName":
                    Music = Music.OrderBy(m => m.music_name);
                    break;

                case "MusicNameDesc":
                    Music = Music.OrderByDescending(m => m.music_name);
                    break;

                case "FileName":
                    Music = Music.OrderBy(m => m.file_name);
                    break;

                case "FileNameDesc":
                    Music = Music.OrderByDescending(m => m.file_name);
                    break;

                case "MusicCountry":
                    Music = Music.OrderBy(m => m.music_country);
                    break;

                case "MusicCountryDesc":
                    Music = Music.OrderByDescending(m => m.music_country);
                    break;

                case "FolderName":
                    Music = Music.OrderBy(m => m.folder_name)
                                        .ThenBy(m => m.music_name);
                    break;

                case "FolderNameDesc":
                    Music = Music.OrderByDescending(m => m.folder_name)
                                        .ThenByDescending(m => m.music_name);
                    break;

                case "ArtistName":
                    Music = Music.OrderBy(m => m.artist_name);
                    break;

                case "ArtistNameDesc":
                    Music = Music.OrderByDescending(m => m.artist_name);
                    break;

                case "AlbumName":
                    Music = Music.OrderBy(m => m.album_name);
                    break;

                case "AlbumNameDesc":
                    Music = Music.OrderByDescending(m => m.album_name);
                    break;

                case "MusicStudio":
                    Music = Music.OrderBy(m => m.music_studio);
                    break;

                case "MusicStudioDesc":
                    Music = Music.OrderByDescending(m => m.music_studio);
                    break;

                case "MusicGenre":
                    Music = Music.OrderBy(m => m.music_genre);
                    break;

                case "MusicGenreDesc":
                    Music = Music.OrderByDescending(m => m.music_genre);
                    break;

                case "MusicSize":
                    Music = Music.OrderBy(m => m.music_sort_size);
                    break;

                case "MusicSizeDesc":
                    Music = Music.OrderByDescending(m => m.music_sort_size);
                    break;

                case "MusicDuration":
                    Music = Music.OrderBy(m => m.music_sort_duration);
                    break;

                case "MusicDurationDesc":
                    Music = Music.OrderByDescending(m => m.music_sort_duration);
                    break;
            }

            // Pagination Results

            var ExcludeRecords = (pageSize * pageNumber) - pageSize;

            Music = Music
                .Skip(ExcludeRecords)
                .Take(pageSize);

            var pagedResults = new PagedResult<Music>()
            {
                Data = Music.ToList(),
                TotalItems = MusicCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return View(pagedResults);
        }
    }
}