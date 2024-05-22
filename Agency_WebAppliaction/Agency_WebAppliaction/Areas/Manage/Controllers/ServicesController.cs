using Agency_WebAppliaction.DAL;
using Agency_WebAppliaction.Models;
using Microsoft.AspNetCore.Mvc;

namespace Agency_WebAppliaction.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ServicesController : Controller
    {
        AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ServicesController( AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult Index()
        {
            return View(_context.services.ToList());
        }
        public IActionResult Create ()
        {
            return View();
        }
        [HttpPost]
         public IActionResult Create (Service services) 
        {
            string path = _environment.WebRootPath + @"\Upload\";
            string filename=services.ImgFile.FileName;
            using (FileStream stream = new FileStream(path + filename, FileMode.Create))
            {
               services.ImgFile.CopyTo(stream);
            }
            services.ImgUrl = filename;
            _context.services.Add(services);
            _context.SaveChanges();
            return RedirectToAction("Index");   
        }
        public IActionResult Update (int id) 
        {
            var services = _context.services.FirstOrDefault(x=>x.Id==id);
            return View(services);


        }
        [HttpPost]
        public IActionResult Update (Service services) 
        { 
            var oldservices=_context.services.FirstOrDefault(x=>x.Id==services.Id);
            if (oldservices==null)
            {
                return View();
            }
            if(services.ImgFile!=null)
            {
                string path = _environment.WebRootPath + @"\Upload\";
                FileInfo fileInfo = new FileInfo(path+ oldservices.ImgUrl);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
                string filename = services.ImgFile.FileName;
                using (FileStream stream = new FileStream(path + filename, FileMode.Create))
                {
                    services.ImgFile.CopyTo(stream);
                }
                oldservices.ImgUrl = filename;
            }
            oldservices.Title= services.Title;
            oldservices.Description= services.Description;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Delete (int id)
        {
            var services= _context.services.FirstOrDefault(x=>x.Id == id);
            if(services==null)
            {
                return View();
            }
            _context.services.Remove(services);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
