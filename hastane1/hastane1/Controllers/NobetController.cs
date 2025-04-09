
using hastane1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


public class NobetController : Controller
{
    private readonly AppDbContext _db;

    public NobetController(AppDbContext context)
    {
        _db = context;
    }
  
    public IActionResult Index(int year, int month)
    {
        year = year == 0 ? DateTime.Now.Year : year;
        month = month == 0 ? DateTime.Now.Month : month;

        var nobetler = _db.Nobetler
            .Include(s => s.Asistan)
            .Include(s => s.Bolum)
            .Where(s => s.Tarih.Year == year && s.Tarih.Month == month)
            .ToList();

        ViewBag.Year = year;
        ViewBag.Month = month;
        return View(nobetler);
    }
  

    public IActionResult Create()
    {
        ViewBag.Asistanlar = _db.Asistanlar
            .Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Ad
            }).ToList();
        ViewBag.Bolumler = _db.Bolumler
                    .Select(d => new SelectListItem
                    {
                        Value = d.Id.ToString(),
                        Text = d.BolumAdi
                    }).ToList();
        return View();


    }

    [HttpPost]
    [ValidateAntiForgeryToken]
   
    public IActionResult Create(Nobet Nobet)
    {
        if (ModelState.IsValid)
        {
            
            var existingShift = _db.Nobetler
                .FirstOrDefault(s => s.AsistanId == Nobet.AsistanId && s.Tarih == Nobet.Tarih);

            if (existingShift != null)
            {
                ModelState.AddModelError("", "This assistant already has a shift on the selected date.");
                ViewBag.Asistanlar = _db.Asistanlar
                    .Select(a => new SelectListItem
                    {
                        Value = a.Id.ToString(),
                        Text = a.Ad
                    }).ToList();
                ViewBag.Bolumler = _db.Bolumler
                    .Select(d => new SelectListItem
                    {
                        Value = d.Id.ToString(),
                        Text = d.BolumAdi
                    }).ToList();
                return View(Nobet);
            }

            _db.Nobetler.Add(Nobet);
            _db.SaveChanges();
            TempData["success"] = "Shift added successfully!";
            return RedirectToAction("Index");
        }

        ViewBag.Asistanlar = _db.Asistanlar
                     .Select(a => new SelectListItem
                     {
                         Value = a.Id.ToString(),
                         Text = a.Ad
                     }).ToList();
        ViewBag.Bolumler = _db.Bolumler
            .Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.BolumAdi
            }).ToList();
        return View(Nobet);
    }

    
    [HttpPost]
    [ValidateAntiForgeryToken]
 
    public IActionResult Delete(int id)
    {
        var nobet = _db.Nobetler.Find(id);
        if (nobet == null)
        {
            return NotFound();
        }

        _db.Nobetler.Remove(nobet);
        _db.SaveChanges();
        TempData["success"] = "Shift deleted successfully!";
        return RedirectToAction("Index");
    }


    public IActionResult Detay(int id)
    {
        var nobet = _db.Nobetler
            .Include(s => s.Asistan)
            .Include(s => s.Bolum)
            .FirstOrDefault(s => s.Id == id);

        if (nobet == null)
        {
            return NotFound();
        }

        return View(nobet);
    }
}