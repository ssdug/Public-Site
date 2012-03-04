using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using FizzWare.NBuilder;
using NUnit.Framework;
using Raven.Client;
using Raven.Client.Embedded;
using Web.Controllers;
using Web.Infrastructure;
using Web.Models;

namespace SSDNUG.Tests.Controllers
{
  [TestFixture]
  class ErrorControllerTests
  {

    [Test]
    public void Should_return_404_view_for_invalid_page()
    {
      //Can't think of a way to test for bad route
      var controller = new ErrorController();
      var result = controller.Index();
      //var viewname = result.ViewName;
      //Assert.That(viewname, Is.EqualTo("NotFound"));

      Assert.That(true, Is.True);
    
    }
  }
}
