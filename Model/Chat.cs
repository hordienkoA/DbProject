using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DbProject.Model
{
    public class Chat
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public byte Usefulness { get; set; }
        public string Nick { get; set; }
        public int? TourId{ get; set; }
        public Tour Tour { get; set; }
        
    }
}