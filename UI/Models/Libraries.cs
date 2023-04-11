using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
   public class Libraries
   {
      [Key]
      [DisplayName("Library ID")]
      public int library_id { get; set; }

      [DisplayName("Library Name")]
      public string library_name { get; set; }

      [DisplayName("Show Total")]
      public string show_total { get; set; }

      [DisplayName("Library Total")]
      [DisplayFormat(DataFormatString = "{0:N0}")]
      public int library_total { get; set; }

      [DisplayName("SD Total")]
      [DisplayFormat(DataFormatString = "{0:N0}")]
      //Version 1 of Adding Commas to INT
      public int sd_total { get; set; }

      [DisplayFormat(DataFormatString = "{0:#,##0}")]
      [DisplayName("HD Total")]
      //Version 2 of Adding Commas to INT
      public int hd_total { get; set; }

      [DisplayName("Library Size")]
      public string library_size { get; set; }

      [DisplayName("Duration")]
      public string library_duration { get; set; }

      [DisplayName("Scanned Date")]
      [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
      public DateTime library_scanned_date { get; set; }

      // Grid Sorting Columns //

      public int library_sort_size { get; set; }

      public int library_sort_duration { get; set; }

      public int library_sort_total { get; set; }
   }
}