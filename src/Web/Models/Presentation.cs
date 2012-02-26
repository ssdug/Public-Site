using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Presentation
    {
        public string Id { get; set; }
        public Presenter Presenter { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PresentationDate { get; set; }
        public bool Booked { get; set; }
    }
}