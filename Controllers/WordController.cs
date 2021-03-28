using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using vocabulary_app.Data;
using vocabulary_app.Models;

namespace vocabulary_app.Controllers
{
    public class WordController : Controller
    {


        private readonly ApplicationDbContext _dbContext;

        public WordController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ActionResult Index()
        {
            ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;

            // the principal identity is a claims identity.
            // now we need to find the NameIdentifier claim
            var userIdClaim = claimsIdentity.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            var userIdValue = userIdClaim.Value;

            IEnumerable<Word> words = _dbContext.Words.Where(s => s.UserId == userIdValue);

            ViewBag.Words = words;

            return View();

        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Word word)
        {

            if (word != null)
            {
                ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;

                // the principal identity is a claims identity.
                // now we need to find the NameIdentifier claim
                var userIdClaim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                var userIdValue = userIdClaim.Value;


                IdentityUser user = _dbContext.Users.FirstOrDefault(IdentityUser => IdentityUser.Id == userIdValue);

                word.User = user;
                word.UserId = user.Id;

                //It doesn`t work*
                _dbContext.Words.Add(word);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index", "Word");
        }

        public ActionResult Edit(Guid Id)
        {
            Word word = _dbContext.Words.Find(Id);
            ViewBag.Words = word;
            return View();
        }

        // POST: WordController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid Id, [Bind("Id,OriginalValue,TranslatedValue,PartOfSpeech,PartOfSpeechDetails,Description")] Word word)
        {

            if (word != null)
            {
                ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;

                // the principal identity is a claims identity.
                // now we need to find the NameIdentifier claim
                var userIdClaim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                var userIdValue = userIdClaim.Value;


                IdentityUser user = _dbContext.Users.FirstOrDefault(IdentityUser => IdentityUser.Id == userIdValue);

                word.User = user;
                word.UserId = user.Id;

                _dbContext.Update(word);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index", "Word");

        }

        public ActionResult Delete(Guid Id)
        {
            Word word = _dbContext.Words.Find(Id);
            ViewBag.Words = word;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid Id, IFormCollection collection)
        {
            Word word = _dbContext.Words.Find(Id);
            if (word == null)
            {
                return RedirectToAction(nameof(Index));
            }

            _dbContext.Words.Remove(word);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Topic");

        }
        public static Guid ToGuid(int value)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
        }
    }
}
