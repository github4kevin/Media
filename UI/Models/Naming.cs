using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
   public class Naming
   {
      [DisplayName("Library ID")]
      public int library_id { get; set; }

      [DisplayName("Library Name")]
      public string library_name { get; set; }

      [DisplayName("Show ID")]
      public int show_id { get; set; }

      [DisplayName("Show Name")]
      public string show_name { get; set; }

      [DisplayName("Season Number")]
      [DisplayFormat(DataFormatString = "{0:00}")]
      public int season_number { get; set; }

      [DisplayName("Total Episodes")]
      [DisplayFormat(DataFormatString = "{0:00}")]
      public int total_episodes { get; set; }

      [DisplayName("Total Size")]
      public string total_size { get; set; }

      [DisplayName("Total Duration")]
      public string total_duration { get; set; }

      // Grid Sorting Columns //

      public int total_sort_duration { get; set; }

      public int total_sort_size { get; set; }
   }
}