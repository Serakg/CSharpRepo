using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebHello.Models;

namespace WebHello.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            Login login = new Login();
            login.Nev = "Serák Gábor";
            login.LatogatasIdeje = DateTime.Now;
            return View();
        }

        [HttpPost]
        public IActionResult Sikeres(Login log)
        {
            TextWriter? txt = null;
            if (ModelState.IsValid)
            {
                string JsongValue = JsonConvert.SerializeObject(log);
                string logfile = "C:\\Users\\gabser\\Documents\\WebhelloLog\\Login log" + ".txt";
                if(System.IO.File.Exists(logfile)) 
                {
                    txt = new StreamWriter(logfile, append: true);
                }
                else
                {
                    txt = new StreamWriter(logfile, append: true);
                }

                txt.WriteLine(JsongValue);
                txt.Close();
            }
            return View(log);
        }
    }
}
