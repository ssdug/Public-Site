using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Presenter
    {
        public Presenter()
        {
            Presentations = new List<string>();
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public string Bio { get; set; }

        public IList<string> Presentations { get; set; }
    }
}