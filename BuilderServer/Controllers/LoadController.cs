using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Runtime.CompilerServices;

namespace CSV2.Controllers
{
    public class LoadController : Controller
    {
        private string _fileName;
        public IActionResult Index()
        {            
            string[]data =_fileName.Split(';');
            return Content(_fileName);
        }
        public LoadController()
        {
            _fileName = 
            System.IO.File.ReadAllText("input.csv");
        }
        public string Get(int? maxTime, string? Name)
        {
            return $"{maxTime}:{Name}";
        }

    }
}
