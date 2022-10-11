namespace HackathonWithMVC.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public float Price { get; set; }
        public int CourseId { get; set; }
        public int UserId { get; set; }
        public bool IsBilled { get; set; }
        public string ImgPath { get; set; }

    }
}
