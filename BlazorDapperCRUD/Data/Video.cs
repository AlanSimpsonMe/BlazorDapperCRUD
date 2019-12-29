using System;
// This is essentially a model for one row in the Video table.
// You can use System.ComponentModel.DataAnnotations if you're familiar. Keeping this barebones.
namespace BlazorDapperCRUD.Data
{
    public class Video
    {
        public int VideoID { get; set; }
        public string Title { get; set; }
        public DateTime DatePublished { get; set; }
        public bool IsActive { get; set; }
    }
}
