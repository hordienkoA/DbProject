namespace DbProject.Model
{
    public class PlaceHost
    {
        public int Id { get; set; }
        public int? PlaceId { get; set; }
        public Place Place { get; set; }
        public int? HostId { get; set; }
        public HostGuide HostGuide { get; set; }
    }
}