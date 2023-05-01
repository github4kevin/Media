using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class Music
    {
        [Key]
        [DisplayName("Music ID")]
        public int music_id { get; set; }

        [DisplayName("Music Name")]
        public string music_name { get; set; }

        [DisplayName("Folder Name")]
        public string folder_name { get; set; }

        [DisplayName("Artists")]
        public string artist_name { get; set; }

        [DisplayName("Album Name")]
        public string album_name { get; set; }

        [DisplayName("Studio")]
        public string music_studio { get; set; }

        [DisplayName("Country")]
        public string music_country { get; set; }

        [DisplayName("Genre")]
        public string music_genre { get; set; }

        [DisplayName("Size")]
        public string music_size { get; set; }

        [DisplayName("Duration")]
        public string music_duration { get; set; }

        [DisplayName("Added Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime music_added_date { get; set; }

        [DisplayName("File Name")]
        public string file_name { get; set; }

        [DisplayName("File Type")]
        public string file_type { get; set; }

        // Grid Sort Columns //

        public int music_sort_size { get; set; }

        public int music_sort_duration { get; set; }
    }
}