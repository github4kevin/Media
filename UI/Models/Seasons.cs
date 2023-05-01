using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
   public class Seasons
   {
      [Key]
      [DisplayName("season ID")]
      public int season_id { get; set; }

      [DisplayName("Show ID")]
      public int show_id { get; set; }

      [DisplayName("Show Name")]
      public string show_name { get; set; }

      [DisplayName("Season")]
      [DisplayFormat(DataFormatString = "{0:00}")]
      public int season_number { get; set; }

      [DisplayName("Episodes")]
      [DisplayFormat(DataFormatString = "{0:00}")]
      public int season_episodes { get; set; }

      [DisplayName("Quality")]
      public string season_quality { get; set; }

      [DisplayName("Size")]
      public string season_size { get; set; }

      [DisplayName("Studio")]
      public string season_studio { get; set; }

      [DisplayName("Duration")]
      public string season_duration { get; set; }

      [DisplayName("Release Date")]
      [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
      public DateTime season_release_date { get; set; }

      [DisplayName("Year")]
      public int season_release_year { get; set; }

      [DisplayName("Added")]
      [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
      public DateTime season_added_date { get; set; }

      // Grid Sorting Columns //

      public int season_sort_size { get; set; }

      public int season_sort_duration { get; set; }

      public int season_sort_quality { get; set; }
   }
}