using Microsoft.AspNetCore.Mvc;
using hastane1.Models;

namespace hastane1.Controllers
{
	public class UserController : Controller
	{
		private readonly AppDbContext _db;

		public UserController(AppDbContext db)
		{
			_db = db;
		}

		
		public IActionResult Index()
		{
			IEnumerable<User> userList = _db.Users;
			return View(userList);
		}

		
		public IActionResult Create()
		{
			return View();
		}

		
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(User user)
		{
			if (ModelState.IsValid)
			{
				_db.Users.Add(user);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(user);
		}

		
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var userFromDb = _db.Users.Find(id);
			if (userFromDb == null)
			{
				return NotFound();
			}

			return View(userFromDb);
		}

	
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(User user)
		{
			if (ModelState.IsValid)
			{
				_db.Users.Update(user);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(user);
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var userFromDb = _db.Users.Find(id);
			if (userFromDb == null)
			{
				return NotFound();
			}

			return View(userFromDb);
		}

	
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePOST(int? id)
		{
			var userFromDb = _db.Users.Find(id);
			if (userFromDb == null)
			{
				return NotFound();
			}

			_db.Users.Remove(userFromDb);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
