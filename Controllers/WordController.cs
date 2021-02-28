using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Index()
        {
            IEnumerable<Word> words = _dbContext.Words;

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

            if( word != null)
            {
                /*word.UserId = User.Identity.Name;
                 It doesn`t work*/ 
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
        public  ActionResult Edit(Guid Id, [Bind("Id,OriginalValue,TranslatedValue,PartOfSpeech,PartOfSpeechDetails,Description")] Word word)
        {

                
            _dbContext.Update(word);
            _dbContext.SaveChanges();
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
