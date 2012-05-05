using System;
using System.Collections.Generic;

namespace Web.Models
{
    public class Presentation
    {
        public Presentation()
        {
            Presenters = new List<PresenterReference>();
        }
        public string Id { get; set; }
        public string Slug { get; set; }
        public PresenterReference Presenter { get; set; }
        public IList<PresenterReference> Presenters { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PresentationDate { get; set; }
        public bool Booked { get; set; }
    }

    public class PresenterReference
    {
        public string Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}