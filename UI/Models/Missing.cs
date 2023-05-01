using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class Missing
    {
        [DisplayName("Movie Name")]
        public string movie_name { get; set; }

        [DisplayName("Quality")]
        public string movie_quality { get; set; }

        [DisplayName("Size")]
        public string movie_size { get; set; }

        [DisplayName("Duration")]
        public string movie_duration { get; set; }

        [DisplayName("File Type")]
        public string movie_file_type { get; set; }

        // Grid Sorting Columns //
        public int movie_sort_duration { get; set; }

        public int movie_sort_size { get; set; }

        public int movie_sort_quality { get; set; }
    }
}