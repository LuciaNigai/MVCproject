using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using lab2.Models;

namespace lab2.Controllers
{
     public class SendMailController : Controller
     {
          // GET: SendMail
          public ActionResult Index()
          {
               return View();
          }

          [HttpPost]
          public ActionResult Index(Email em)
          {
               string to = em.To;
               string subject = em.Subject;
               string body = em.Body;

               MailMessage mm = new MailMessage();
               mm.To.Add(to);
               mm.Subject = subject;
               mm.Body = body;
               mm.From = new MailAddress("luchianigaj@gmail.com");
               mm.IsBodyHtml = false;
               SmtpClient smtp = new SmtpClient("smtp.gmail.com");
               smtp.Port = 587;
               smtp.UseDefaultCredentials = true;
               smtp.EnableSsl = true;
               smtp.Credentials = new System.Net.NetworkCredential("luchianigaj@gmail.com", "password");
               smtp.Send(mm);
               ViewBag.message = "The mail Has Been Sent To" + em.To + "Successfully..!";

               return View();
          }
     }
}