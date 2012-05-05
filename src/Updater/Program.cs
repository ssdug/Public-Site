using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client;
using Web.Infrastructure;
using Web.Infrastructure.Extensions;
using Web.Models;

namespace Updater
{
    class Program
    {
        public static IDocumentSession DocumentSession { get; set; }

        static void Main(string[] args)
        {

            using(DocumentSession = DocumentStoreHolder.DocumentStore.OpenSession())
            {
                UpdatePresenters();
                DocumentSession.SaveChanges();
            }
            Console.Write("The upgrade has completed.");
            Console.ReadKey();

        }

        private static void UpdatePresenters()
        {
            //fetch all presenters
            var presenters = DocumentSession.Query<Presenter>();
            Console.WriteLine("Processing {0} Presenters...", presenters.Count());
            //foreach
            foreach (var presenter in presenters)
            {
                Console.WriteLine("Processing {0}", presenter.Name);
                //fetch all presentations for presenter
                var presentations = DocumentSession.Query<Presentation>()
                                                   .Where(presentation => presentation.Presenter.Id == presenter.Email);
                Console.WriteLine("{0} has {1} presentations to modify", presenter.Name, presentations.Count());
                foreach (var presentation in presentations)
                {
                    Console.WriteLine("updating {0}", presentation.Title);
                    //update presentation slug
                    var newPresentaion = new Presentation
                                             {
                                                Title = presentation.Title,
                                                Booked = presentation.Booked,
                                                Description = presentation.Description,
                                                PresentationDate = presentation.PresentationDate,
                                                Slug = presentation.Title.Slugify()
                                             };
                    
                    newPresentaion.Presenters.Add(new PresenterReference{ Name = presenter.Name, Email = presenter.Email, Slug = presenter.Name.Slugify()});
                    DocumentSession.Store(newPresentaion);
                    DocumentSession.Delete(presentation);
                }
                var newPresenter = new Presenter
                                       {
                                           Name = presenter.Name,
                                           Email = presenter.Email,
                                           Slug = presenter.Name.Slugify(),
                                           Site = presenter.Site,
                                           Bio = presenter.Bio
                                       };
                DocumentSession.Store(newPresenter);
                DocumentSession.Delete(presenter);
            }       
        }
    }
}
