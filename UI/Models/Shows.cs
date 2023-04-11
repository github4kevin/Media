using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
   public class Shows
   {
      [DisplayName("Folder ID")]
      public int folder_id { get; set; }

      [Key]
      [DisplayName("Show ID")]
      public int show_id { get; set; }

      [DisplayName("Show Name")]
      public string show_name { get; set; }

      [DisplayName("Seasons")]
      [DisplayFormat(DataFormatString = "{0:00}")]
      public int show_seasons { get; set; }

      [DisplayName("Episodes")]
      [DisplayFormat(DataFormatString = "{0:00}")]
      public int show_episodes { get; set; }

      [DisplayName("Quality")]
      public string show_quality { get; set; }

      [DisplayName("Size")]
      public string show_size { get; set; }

      [DisplayName("Duration")]
      public string show_duration { get; set; }

      [DisplayName("Release Date")]
      [DisplayFormat(DataFormatString = "{0:yyyy}")]
      public DateTime show_release_date { get; set; }

      [DisplayName("Added Date")]
      [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
      public DateTime show_added_date { get; set; }

      [DisplayName("Last Viewed")]
      [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
      public DateTime show_last_viewed { get; set; }

      [DisplayName("Rating")]
      public float show_rating { get; set; }

      [DisplayName("Content Rating")]
      public string show_content_rating { get; set; }

      [DisplayName("Genre(s)")]
      public string show_genre { get; set; }

      [DisplayName("Studio")]
      public string show_studio { get; set; }

      [DisplayName("Collection")]
      public string show_collection { get; set; }

      [DisplayName("Summary")]
      public string show_summary { get; set; }

      // Grid Sorting Columns //

      public int show_sort_duration { get; set; }

      public int show_sort_size { get; set; }

      public int show_sort_quality { get; set; }
   }
}