using Microsoft.AspNetCore.Mvc;
using hastane1.Models;
using Microsoft.AspNetCore.Http.HttpResults;


namespace hastane1.Controllers
{
	public class AsistanController : Controller
	{

		private readonly AppDbContext _db;


		public AsistanController(AppDbContext db)
		{
			_db = db;

		}


		public IActionResult Index()
		{
			IEnumerable<Asistan> objAsistanList = _db.Asistanlar;
			return View(objAsistanList);
		}
		//get
		public IActionResult Create()
		{
			return View();
		}
		//post
		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Create(Asistan obj)
		{


			_db.Asistanlar.Add(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");


		}

		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var AsistanDb = _db.Asistanlar.Find(id);
			//var  AsistanDbFirst = _db. Asistan.FirstOrDefault(u=>u.Id==id);
			//var  AsistanDbSingle = _db. Asistan.SingleOrDefault(u=>u.Id==id);

			if (AsistanDb == null)
			{
				return NotFound();
			}
			return View(AsistanDb);
		}

		//post
		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Edit(Asistan obj)
		{


			_db.Asistanlar.Update(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");


		}
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var AsistanDb = _db.Asistanlar.Find(id);
			

			if (AsistanDb == null)
			{
				return NotFound();
			}
			return View(AsistanDb);
		}

		//post
		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult DeletePOST(int? id)
		{
			var obj = _db.Asistanlar.Find(id);
			if (obj == null)
			{
				return NotFound();
			}

			_db.Asistanlar.Remove(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");


		}
	}
}


