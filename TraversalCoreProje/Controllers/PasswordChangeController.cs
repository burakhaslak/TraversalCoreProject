using AutoMapper.Internal;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class PasswordChangeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration; // EKLE

        public PasswordChangeController(UserManager<AppUser> userManager, IConfiguration configuration) // EKLE
        {
            _userManager = userManager;
            _configuration = configuration; // EKLE
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgotPasswordViewModel forgotPasswordViewModel)
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordViewModel.Mail);

            // GÜVENLİK: Null kontrolü ekle
            if (user == null)
            {
                return View();
            }

            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetTokenLink = Url.Action("ResetPassword", "PasswordChange", new
            {
                userId = user.Id,
                token = passwordResetToken
            }, HttpContext.Request.Scheme);

            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", _configuration["EmailSettings:Username"]); // DEĞİŞTİR
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", forgotPasswordViewModel.Mail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = passwordResetTokenLink;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "Request for resetting password.";

            using (var client = new SmtpClient())
            {
                client.Connect(
                    _configuration["EmailSettings:SmtpServer"],  // DEĞİŞTİR
                    int.Parse(_configuration["EmailSettings:Port"]), // DEĞİŞTİR
                    false);

                client.Authenticate(
                    _configuration["EmailSettings:Username"],  // DEĞİŞTİR
                    _configuration["EmailSettings:Password"]); // DEĞİŞTİR

                client.Send(mimeMessage);
                client.Disconnect(true);
            }

            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string userid, string token)
        {
            TempData["userid"] = userid;
            TempData["token"] = token;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            var userid = TempData["userid"];
            var token = TempData["token"];

            if (userid == null || token == null)
            {
                return RedirectToAction("ForgetPassword"); // Hata durumunda yönlendir
            }

            var user = await _userManager.FindByIdAsync(userid.ToString());

            // GÜVENLİK: Null kontrolü ekle
            if (user == null)
            {
                return RedirectToAction("ForgetPassword");
            }

            var result = await _userManager.ResetPasswordAsync(user, token.ToString(), resetPasswordViewModel.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }

            return View();
        }
    }
}