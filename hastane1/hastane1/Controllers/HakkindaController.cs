using Microsoft.AspNetCore.Mvc;
using hastane1.Models;
using Microsoft.AspNetCore.Http.HttpResults;


namespace hastane1.Controllers
{
    public class HakkindaController : Controller
    {

        private readonly AppDbContext _db;


        public HakkindaController(AppDbContext db)
        {
            _db = db;

        }


        public IActionResult Index()
        {
            IEnumerable<BolumHakkinda> objBolumList = _db.BolumHakkinda;
            return View(objBolumList);
        }
        //get
        public IActionResult Create()
        {
            return View();
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(BolumHakkinda obj)
        {


            _db.BolumHakkinda.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }

        
        
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var BolumhakkindaDb = _db.BolumHakkinda.Find(id);
           

            if (BolumhakkindaDb == null)
            {
                return NotFound();
            }
            return View(BolumhakkindaDb);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.BolumHakkinda.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.BolumHakkinda.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}


