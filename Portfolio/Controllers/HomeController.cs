using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailSender _emailSender;

        
        public HomeController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactForm msg)
        {
            try
            {

                string FromAddress = "codebyhart";
                string FromAdressTitle = "Email from ASP.NET Core 1.1";
                //To Address 
                string ToAddress = "codebyhart";
                string ToAdressTitle = "Microsoft ASP.NET Core";
                string Subject = "Hello World - Sending email using ASP.NET Core 1.1";
                string BodyContent =
                    "ASP.NET Core was previously called ASP.NET 5. It was renamed in January 2016. It supports cross-platform frameworks ( Windows, Linux, Mac ) for building modern cloud-based internet-connected applications like IOT, web apps, and mobile back-end.";

                //Smtp Server 
                string SmtpServer = "smtp.gmail.com";
                //Smtp Port Number 
                int SmtpPortNumber = 587;

                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(FromAdressTitle, FromAddress));
                mimeMessage.To.Add(new MailboxAddress(ToAdressTitle, ToAddress));
                mimeMessage.Subject = Subject;
                mimeMessage.Body = new TextPart("plain")
                {
                    Text = BodyContent

                };

                using (var client = new SmtpClient())
                {

                    client.Connect(SmtpServer, SmtpPortNumber, SecureSocketOptions.StartTls);
                    
                    // Note: only needed if the SMTP server requires authentication 
                    // Error 5.5.1 Authentication  
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate("codebyhart", "7codeBaker");
                    client.Send(mimeMessage);
                    Console.WriteLine("The mail has been sent successfully !!");
                    Console.ReadLine();
                    client.Disconnect(true);

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View();
        }

       
        public IActionResult AboutMe()
        {
            return View();
        }

      
        public IActionResult Projects()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
    }
}