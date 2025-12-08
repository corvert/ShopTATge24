using Microsoft.AspNetCore.Mvc;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;

namespace ShopTARge24.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailServices _emailServices;

        public EmailController
            (
                IEmailServices emailServices
            )
        {
            _emailServices = emailServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(EmailViewModel vm)
        {
            var files = Request.Form.Files.Any() ? Request.Form.Files.ToList() : new List<IFormFile>();

            var emailDto = new EmailDto
            {
                To = vm.To,
                Subject = vm.Subject,
                Body = vm.Body,
                Attachment = files
            };
            _emailServices.SendEmail(emailDto);
            return RedirectToAction(nameof(Index));
        }
    }
}