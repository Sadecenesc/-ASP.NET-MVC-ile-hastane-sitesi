using Microsoft.AspNetCore.Mvc;
using hastane1.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace hastane1.Controllers
{
	public class RandevuController : Controller
	{

		private readonly AppDbContext _db;


		public RandevuController(AppDbContext db)
		{
			_db = db;

		}


		public IActionResult Index()
		{
			IEnumerable<Randevu> objRandevuList = _db.Randevular;
			return View(objRandevuList);
		}
		//get

		public IActionResult Create()
		{
			return View();
		}
		//post
		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Create(Randevu obj)
		{


			_db.Randevular.Add(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");


		}

		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var RandevuDb = _db.Randevular.Find(id);
		

			if (RandevuDb == null)
			{
				return NotFound();
			}
			return View(RandevuDb);
		}

		//post
		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Edit(Randevu obj)
		{


			_db.Randevular.Update(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");


		}
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var RandevuDb = _db.Randevular.Find(id);
			
			if (RandevuDb == null)
			{
				return NotFound();
			}
			return View(RandevuDb);
		}

		//post
		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult DeletePOST(int? id)
		{
			var obj = _db.Randevular.Find(id);
			if (obj == null)
			{
				return NotFound();
			}

			_db.Randevular.Remove(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult RandevuAl(int id)
		{
			var randevu = _db.Randevular
				.Include(a => a.OgretimUyesi)
				.FirstOrDefault(a => a.Id == id);

			if (randevu == null)
			{
				return NotFound();
			}

			ViewBag.Asistanlar = _db.Asistanlar
				.Select(a => new SelectListItem
				{
					Value = a.Id.ToString(),
					Text = a.Ad
				})
				.ToList();

			return View(randevu);
		}

		[HttpPost]
		public IActionResult RandevuAl(int id, int AsistanId)
		{
			var randevu = _db.Randevular.FirstOrDefault(a => a.Id == id);

			if (randevu == null)
			{
				TempData["error"] = "Randevu Bulunamadı.";
				return RedirectToAction("Index");
			}

			randevu.AsistanId = AsistanId;
		
			_db.SaveChanges();

			TempData["success"] = "Randevu Alma Başarılı!";
			return RedirectToAction("Index");


		}
        public IActionResult Detay(int id)
        {
            var Randevu = _db.Randevular
                .Include(a => a.Asistan)
                .Include(a => a.OgretimUyesi)
                .FirstOrDefault(a => a.Id == id);

            if (Randevu == null)
            {
                return NotFound();
            }

            return View(Randevu);
        }

       
    }

	}


