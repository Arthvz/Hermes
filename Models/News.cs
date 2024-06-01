namespace Hermes.Models{
    public class News
    {
        public News()
        {
            ImageURL = string.Empty;
            Title = string.Empty;
            Content = string.Empty;
            Summary = string.Empty;
        }
        
        public int Id { get; set; }
        public string ImageURL { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public DateTime DatePosted { get; set; }
    }
}