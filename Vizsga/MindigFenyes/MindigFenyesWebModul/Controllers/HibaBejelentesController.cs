using Microsoft.AspNetCore.Mvc;
using MindigFenyesWebModul.Models;

namespace MindigFenyesWebModul.Controllers
{
    public class HibaBejelentesController : Controller
    {
        public IActionResult Index()
        {
            HibaBejelentes hibaBejelentes = new HibaBejelentes();
            
            return View("Index");
        }

        [HttpPost]
        public IActionResult SikeresBejelentes() 
        {
            Bejelenteseim bejelenteseim= new Bejelenteseim();
            Bejelentesek bejelentes= new Bejelentesek();
            bejelentes.Cim = Request.Form["Cim"];
            bejelentes.Idopont = new DateTime(new Random().Next(2020, 2023), new Random().Next(1,12), new Random().Next(1, 29));
            bejelenteseim.Bejelenteseks.Add(bejelentes);
            bejelenteseim.SaveChanges();

            return View();
        }
    }
}
