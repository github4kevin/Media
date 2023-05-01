using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
   public class Duplicates
   {
      [Key]
      [DisplayName("Media ID")]
      public int media_id { get; set; }

      [DisplayName("Media Name")]
      public string media_name { get; set; }

      [DisplayName("Media Type")]
      public string media_type { get; set; }

      [DisplayName("Media Folder")]
      public string media_folder { get; set; }

      [DisplayName("Media Size")]
      public string media_size { get; set; }

      [DisplayName("Media Duration")]
      public string media_duration { get; set; }

      [DisplayName("Media Quality")]
      public string media_quality { get; set; }      

      [DisplayName("Media Released")]
      [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
      public DateTime media_released { get; set; }

      [DisplayName("Backups")]
      public int total_backups { get; set; }

      // Grid Sorting Columns //

      public int media_sort_size { get; set; }

      public int media_sort_duration { get; set; }

      public int media_sort_quality { get; set; }
   }
}
