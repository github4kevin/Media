using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
   public class Videos
   {
      [Key]
      [DisplayName("Video ID")]
      public int video_id { get; set; }

      [DisplayName("Video Name")]
      public string video_name { get; set; }

      [DisplayName("Quality")]
      public string video_quality { get; set; }

      [DisplayName("Size")]
      public string video_size { get; set; }

      [DisplayName("Duration")]
      public string video_duration { get; set; }

      // Grid Sorting Columns //

      public int video_sort_size { get; set; }

      public int video_sort_quality { get; set; }

      public int video_sort_duration { get; set; }
   }
}
