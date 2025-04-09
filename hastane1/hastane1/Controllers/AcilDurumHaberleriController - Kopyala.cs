

using Microsoft.AspNetCore.Mvc;
using hastane1.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;

namespace hastane1.Controllers
{
	public class AcilDurumHaberleriController : Controller
	{
		private readonly AppDbContext _db;

		public AcilDurumHaberleriController(AppDbContext db)
		{
			_db = db;
		}

		// GET: AcilDurumHaberleri
		public IActionResult Index()
		{
			IEnumerable<AcilDurumHaberi> objAcilhaberlerList = _db.AcilDurumHaberleri;
			return View(objAcilhaberlerList);
		}

		// GET: Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(AcilDurumHaberi obj)
		{
			if (ModelState.IsValid)
			{
				_db.AcilDurumHaberleri.Add(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		// GET: Edit
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var AcilDurumHaberiDb = _db.AcilDurumHaberleri.Find(id);
			if (AcilDurumHaberiDb == null)
			{
				return NotFound();
			}
			return View(AcilDurumHaberiDb);
		}

		// POST: Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(AcilDurumHaberi obj)
		{
			if (ModelState.IsValid)
			{
				_db.AcilDurumHaberleri.Update(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		// GET: Delete
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var AcilDurumHaberiDb = _db.AcilDurumHaberleri.Find(id);
			if (AcilDurumHaberiDb == null)
			{
				return NotFound();
			}
			return View(AcilDurumHaberiDb);
		}

		// POST: Delete
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePOST(int? id)
		{
			var obj = _db.AcilDurumHaberleri.Find(id);
			if (obj == null)
			{
				return NotFound();
			}

			_db.AcilDurumHaberleri.Remove(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
        private void SendEmailToAssistants(AcilDurumHaberi acilDurumHaberleri)
        {

            var userEmail = User?.FindFirstValue(ClaimTypes.Email) ?? "hattabenes@outlook.com";
            var userPassword = User?.FindFirstValue("UserPassword") ?? "Enessakarya54.";


            if (string.IsNullOrEmpty(userEmail) || string.IsNullOrEmpty(userPassword))
            {
                TempData["error"] = "Failed to send emails. User email is not available.";
                return;
            }

            var Asistanlar = _db.Asistanlar.Where(a => !string.IsNullOrEmpty(a.Eposta)).ToList();
            var OgretimUyesi = _db.OgretimUyeleri.Where(p => !string.IsNullOrEmpty(p.Eposta)).ToList();
            foreach (var Asistan in Asistanlar)
            {
                try
                {

                    var smtpClient = new SmtpClient("smtp.office365.com")
                    {
                        Port = 587, // TLS için doğru port
                        Credentials = new NetworkCredential(userEmail, userPassword), // Outlook kimlik bilgileri
                        EnableSsl = true, // Şifreli bağlantıyı etkinleştir
                    };


                   
                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(userEmail),
                        Subject = $"Emergency: {acilDurumHaberleri.Baslik}",
                        Body = $"<h3>{acilDurumHaberleri.Baslik}</h3><p>{acilDurumHaberleri.Aciklama}</p><p>Created At: {acilDurumHaberleri.Tarih}</p>",
                        IsBodyHtml = true,
                    };

                    mailMessage.To.Add(Asistan.Eposta);

                    
                    smtpClient.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine($"Failed to send email to {Asistan.Eposta}: {ex.Message}");
                }
            }
            foreach (var OgretimUyeleri  in OgretimUyesi)
            {
               
                try
                {
                    // Sabit Gmail hesabınızı ve şifrenizi burada tanımlayın
                    var userEposta = "hattabenes54@gmail.com"; // Buraya Gmail adresinizi yazın
                    var Password = "Enessakarya54";    // Buraya Gmail şifrenizi yazın

                    var smtpClient = new SmtpClient("smtp.gmail.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential(userEmail, userPassword), // Gmail hesabınız ve şifreniz burada kullanılır
                        EnableSsl = true,
                    };

                    // E-posta mesajını oluşturma
                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(userEmail), // Gönderen adresi olarak sabit Gmail adresinizi kullanın
                        Subject = $"Emergency: {acilDurumHaberleri.Baslik}",
                        Body = $"<h3>{acilDurumHaberleri.Baslik}</h3><p>{acilDurumHaberleri.Aciklama}</p><p>Created At: {acilDurumHaberleri.Tarih}</p>",
                        IsBodyHtml = true,
                    };

                    mailMessage.To.Add(OgretimUyeleri.Eposta); // Alıcı adresini ekleme

                    // E-postayı gönderme
                    smtpClient.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    // Hata yönetimi
                    Console.WriteLine($"Bir hata oluştu: {ex.Message}");
                }

                }
        }
    }
}
