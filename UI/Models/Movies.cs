using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
   public class Movies
   {
      [Key]
      [DisplayName("Movie ID")]
      public int movie_id { get; set; }

      [DisplayName("Movie Name")]
      public string movie_name { get; set; }

      [DisplayName("Quality")]
      public string movie_quality { get; set; }

      [DisplayName("Size")]
      public string movie_size { get; set; }

      [DisplayName("Duration")]
      public string movie_duration { get; set; }

      [DisplayName("Released")]
      [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
      public DateTime movie_release_date { get; set; }

      [DisplayName("Added")]
      [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
      public DateTime movie_added_date { get; set; }

      [DisplayName("Audience")]
      [DisplayFormat(DataFormatString = "{0:0.0}")]      
      public float movie_audience_rating { get; set; }

      [DisplayName("Critic")]
      [DisplayFormat(DataFormatString = "{0:0.0}")]      
      public float movie_critic_rating { get; set; }      

      [DisplayName("Content Rating")]   
      public string movie_content_rating { get; set; }

      [DisplayName("Genre")]
      public string movie_genre { get; set; }

      [DisplayName("Studio")]
      public string movie_studio { get; set; }

      [DisplayName("Country")]
      public string movie_country { get; set; }

      [DisplayName("Movie FPS")]
      public float movie_fps { get; set; }

      [DisplayName("Video Codec")]
      public string movie_video_codec { get; set; }

      [DisplayName("Audio Codec")]
      public string movie_audio_codec { get; set; }

      [DisplayName("Collection")]
      public string movie_collection { get; set; }

      [DisplayName("File Type")]
      public string movie_file_type { get; set; }

      [DisplayName("Filepath")]
      public string movie_file_path { get; set; }

      // Grid Sorting Columns //
      public int movie_sort_duration { get; set; }

      public int movie_sort_size { get; set; }

      public int movie_sort_quality { get; set; }
   }
}