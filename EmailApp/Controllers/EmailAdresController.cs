using EmailApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using EmailApp.DataContext;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using EmailApp.Services;

namespace EmailApp.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class EmailAdresController :ControllerBase
    {
        EmailDbContext db = new EmailDbContext();
        private readonly IEmailSender _emailSender;

        public EmailAdresController(IEmailSender emailSender)
        {
            this._emailSender = emailSender;
        }

        [HttpPost]//Mail Gönderme
        public async Task<IActionResult> Index(string email, string subject, string body)
        {
            await _emailSender.SendEmailAsync(email, subject, body);
            return Ok();
        }

        [HttpPost]//Mail ekleme
    public IActionResult AddEmailAddress(EmailAdres emailAdres)
    {
            List<EmailAdres> tumListe = new List<EmailAdres>();
            Regex validateEmailRegex = new Regex("^\\S+@\\S+\\.\\S+$");
         
            if (!validateEmailRegex.IsMatch(emailAdres.Address))
            {
                Console.WriteLine(emailAdres.Address + " is not a valid Email address ");
                return BadRequest("Bu e-posta formata uygun değil.");
            }

            HashSet<string> uniqueEmails = new HashSet<string>(tumListe.Select(item => item.Address));

            if (uniqueEmails.Contains(emailAdres.Address))
            {
                Console.WriteLine("Bu e-posta zaten mevcut.");
                return BadRequest("Bu e-posta zaten mevcut.");
            }

            tumListe.Add(emailAdres);
            db.SaveChanges();
            return Ok("Başarıyla eklendi");
        }

    [HttpGet]// Tüm liste çekme
    public IActionResult GetAllEmailAddresses()
    {
        
        List<EmailAdres> tumListe = new List<EmailAdres>(); 
        return Ok(tumListe);
    }

    [HttpDelete("DeleteByEmail/{emailAdres}")]// Adres ile silme
    public IActionResult DeleteEmailByEmail(string emailAddress)
        {
            List<EmailAdres> tumListe = new List<EmailAdres>();
            EmailAdres silinecekEmail = tumListe.FirstOrDefault(email => email.Address == emailAddress);

            if (silinecekEmail != null)
            {
                tumListe.Remove(silinecekEmail);
                // Veritabanını güncelleme 
                db.SaveChanges();
                return Ok("E-posta adresi başarıyla silindi.");
            }
            else
            {
                
                return NotFound("E-posta adresi bulunamadı.");
            }
        }

    [HttpDelete("DeleteByEmailId/{id}")]// Id ile silme
    public IActionResult DeleteEmailById(int id)
        {
            List<EmailAdres> tumListe = new List<EmailAdres>();
            EmailAdres silinecekEmail = tumListe.FirstOrDefault(e => e.Id == id);

            if (silinecekEmail != null)
            {
                tumListe.Remove(silinecekEmail);
                db.SaveChanges();
                return Ok(silinecekEmail);
            }
            else
            {
                
                return NotFound("E-posta adresi bulunamadı.");
            }
        }
    }

    





}
