using Microsoft.AspNetCore.Mvc;
using Sort.Logic;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Sort.Controler
{
    public class HomeController : Controller
    {
        private readonly ISortMethod sort;

        public HomeController( ISortMethod sort)
        {
            this.sort = sort;
        }

        public IActionResult Index() => View();

        public IActionResult SortReview() => View(sort.SortedNums());

        public IActionResult UpLoadFile()
        {
            return View();
        }


        [HttpPost]
        public IActionResult UpLoadFile([FromServices] IConfiguration configuration, IFormFile file)
        {
            if (file != null)
            {
                using (var fileStream = new FileStream(Path.Combine(configuration["DllFolderPath"],file.FileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                return View("Successfull");
            }
            else
            {
                return View();
            }


            
        }


    }
}
