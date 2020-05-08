namespace DbProject.Model
{
    public class TouristGuide
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public double Age { get; set; }
        public string AdditionalInfo { get; set; }
        public string Language { get; set; }
        public int? TourId { get; set; }
        public Tour Tour { get; set; }
    }
}