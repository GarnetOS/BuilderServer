using BuilderServer.Data;
using BuilderServer.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Runtime.CompilerServices;

namespace CSV2.Controllers
{
    public class LoadController : Controller
    {
        public readonly ApplicationDbContext _context;
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
        public Item Select(int SBU)
        {
            var selectedItem = _context.Items
                .Where(i => i.SBU <= SBU)
                .OrderByDescending(i => i.SBU)
                .FirstOrDefault();
            return selectedItem;
        }
        void Write(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }
    }
}
