using Microsoft.AspNetCore.Mvc;
using MindigFenyesWebModul.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindigFenyesTestModul
{
    public class UnitTest_Web
    {
        [Fact]
        public void IndexViewTeszt()
        {
            var sajatContoller = new HibaBejelentesController();
            var eredmeny = sajatContoller.Index() as ViewResult;
            Assert.Equal("Index", eredmeny.ViewName);
        }
    }
}
