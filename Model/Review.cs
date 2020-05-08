namespace DbProject.Model
{
    public class Review
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int? HostGuideId { get; set; }
        public HostGuide HostGuide { get; set; }
    }
}