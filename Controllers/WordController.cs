using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
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
        public IActionResult Index()
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
        public async Task<IActionResult> Create(Word word)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Create));
            }

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

                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Word");
        }

        public async Task<IActionResult> Edit(Guid Id)
        {
            Word word = await _dbContext.Words.FindAsync(Id);
            ViewBag.Words = word;
            return View();
        }

        // POST: WordController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid Id, [Bind("Id,OriginalValue,TranslatedValue,PartOfSpeech,PartOfSpeechDetails,Description")] Word word)
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
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Word");

        }

        public async Task<IActionResult> Delete(Guid Id)
        {
            Word word = await _dbContext.Words.FindAsync(Id);
            ViewBag.Words = word;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid Id, IFormCollection collection)
        {
            Word word = await _dbContext.Words.FindAsync(Id);
            if (word == null)
            {
                return RedirectToAction(nameof(Index));
            }

            _dbContext.Words.Remove(word);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Word");

        }
        public static Guid ToGuid(int value)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
        }
    }
}
