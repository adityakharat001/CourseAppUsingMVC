using System.ComponentModel.DataAnnotations;

namespace HackathonWithMVC.Models
{
    public class Course
    {
        
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public float Rating { get; set; }
        public string ImgPath { get; set; }
    }
}
