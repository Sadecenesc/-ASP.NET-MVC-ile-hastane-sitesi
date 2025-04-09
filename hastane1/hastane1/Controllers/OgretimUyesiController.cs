using Microsoft.AspNetCore.Mvc;
using hastane1.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;


namespace hastane1.Controllers
{
    public class OgretimUyesiController : Controller
    {

        private readonly AppDbContext _db;


       public OgretimUyesiController(AppDbContext db)
        {
            _db = db;

        }

		

		public IActionResult Index()
        {
            IEnumerable<OgretimUyesi> objOgretimUyesiList = _db.OgretimUyeleri;
            return View(objOgretimUyesiList);
        }
		[Authorize(Roles = "Admin")]
		public IActionResult Create()
		{
			return View();
		}
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin")]
		public IActionResult Create(OgretimUyesi obj)
        {
         
            
                _db.OgretimUyeleri.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            
          
        }
		[Authorize(Roles = "Admin")]
		public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var OgretimUyesiDb = _db.OgretimUyeleri.Find(id);
         

            if (OgretimUyesiDb == null)
            {
                return NotFound();
            }
            return View(OgretimUyesiDb);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin")]
		public IActionResult Edit(OgretimUyesi obj)
        {


            _db.OgretimUyeleri.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
		[Authorize(Roles = "Admin")]
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var OgretimUyesiDb = _db.OgretimUyeleri.Find(id);
		
			if (OgretimUyesiDb == null)
			{
				return NotFound();
			}
			return View(OgretimUyesiDb);
		}

		//post
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin")]
		public IActionResult DeletePOST(int? id)
		{
			var obj = _db.OgretimUyeleri.Find(id);
			if (obj == null)
			{
				return NotFound();
			}

			_db.OgretimUyeleri.Remove(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");


		}
	}
}


