using System;
using System.Collections.Generic;

namespace DbProject.Model
{
    public class Tour
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Review { get; set; }
        public string AdditionalInfo { get; set; }
        
        public List<HostGuide> HostGuides { get; set; }
        public List<TouristGuide> TouristGuides { get; set; }
        public List<Chat> Chats { get; set; }
    }
}