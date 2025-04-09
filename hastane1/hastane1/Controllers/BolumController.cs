using Microsoft.AspNetCore.Mvc;
using hastane1.Models;
using Microsoft.AspNetCore.Http.HttpResults;


namespace hastane1.Controllers
{
	public class BolumController : Controller
	{

		private readonly AppDbContext _db;


		public BolumController(AppDbContext db)
		{
			_db = db;

		}


		public IActionResult Index()
		{
			IEnumerable<Bolum> objBolumList = _db.Bolumler;
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

		public IActionResult Create(Bolum obj)
		{


			_db.Bolumler.Add(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");


		}

		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var BolumDb = _db.Bolumler.Find(id);
			

			if (BolumDb == null)
			{
				return NotFound();
			}
			return View(BolumDb);
		}

		//post
		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Edit(Bolum obj)
		{


			_db.Bolumler.Update(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");


		}
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var BolumDb = _db.Bolumler.Find(id);
			
			if (BolumDb == null)
			{
				return NotFound();
			}
			return View(BolumDb);
		}

		//post
		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult DeletePOST(int? id)
		{
			var obj = _db.Bolumler.Find(id);
			if (obj == null)
			{
				return NotFound();
			}

			_db.Bolumler.Remove(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");


		}
	}
}


