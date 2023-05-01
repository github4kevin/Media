using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
   public class Episodes
   {
      [DisplayName("Show ID")]
      public int show_id { get; set; }

      [DisplayName("Show Name")]
      public string show_name { get; set; }

      [DisplayName("Season Number")]
      [DisplayFormat(DataFormatString = "{0:00}")]
      public int season_number { get; set; }

      [DisplayName("Episode Number")]
      [DisplayFormat(DataFormatString = "{0:00}")]
      public int episode_number { get; set; }

      [Key]
      [DisplayName("Episode ID")]
      public int episode_id { get; set; }

      [DisplayName("Episode Name")]
      public string episode_name { get; set; }

      [DisplayName("Episode Quality")]
      public string episode_quality { get; set; }

      [DisplayName("Episode Size")]
      public string episode_size { get; set; }

      [DisplayName("Episode Duration")]
      public string episode_duration { get; set; }

      [DisplayName("Episode Summary")]
      public string episode_summary { get; set; }

      [DisplayName("Episode FPS")]
      public float episode_fps { get; set; }

      [DisplayName("Episode Video Codec")]
      public string episode_video_codec { get; set; }

      [DisplayName("Episode Audio Codec")]
      public string episode_audio_codec { get; set; }

      [DisplayName("Episode Release Date")]
      [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
      public DateTime episode_release_date { get; set; }

      [DisplayName("Episode Added Date")]
      [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
      public DateTime episode_added_date { get; set; }

      [DisplayName("Episode Rating")]
      public float episode_rating { get; set; }

      [DisplayName("Show Genre")]
      public string show_genre { get; set; }

      [DisplayName("Show Content Rating")]
      public string show_content_rating { get; set; }

      [DisplayName("Show Studio")]
      public string show_studio { get; set; }

      [DisplayName("Episode Viewed")]
      public bool episode_viewed { get; set; }

      [DisplayName("Episode View Count")]
      public int episode_view_count { get; set; }

      [DisplayName("Episode View Device")]
      public string episode_view_device { get; set; }

      // Grid Sorting Columns //

      public int episode_sort_size { get; set; }

      public int episode_sort_quality { get; set; }

      public int episode_sort_duration { get; set; }
   }
}