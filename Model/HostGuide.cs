using System.Collections.Generic;

namespace DbProject.Model
{
    public class HostGuide
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Language { get; set; }
        public int Age { get; set; }
        public double Experience { get; set; }
        public string Address { get; set; }
        public byte Stars { get; set; }
        public string AdditionalInfo { get; set; }
        public List<Review> Reviews { get; set; }
        public int? TourId { get; set; }
        public Tour Tour { get; set; }
    }   
}