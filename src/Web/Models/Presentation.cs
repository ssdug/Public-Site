using System;

namespace Web.Models
{
    public class Presentation
    {
        public string Id { get; set; }
        public PresenterReference Presenter { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PresentationDate { get; set; }
        public bool Booked { get; set; }
    }

    public class PresenterReference
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}