﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using vocabulary_app.Data;
using vocabulary_app.Models;

namespace vocabulary_app.Controllers
{
    //Add a new controller, inherit it from Controller
    public class TopicController : Controller
    {

        private readonly ApplicationDbContext _dbContext;
        // GET: TopicController

        public async TopicController(ApplicationDbContext dbContext)
        {
            await _dbContext = dbContext;
        }
        public async ActionResult Index()
        {
            IEnumerable<Topic> topics = await _dbContext.Topics;

            ViewBag.Topics = topics;

            return View();
        }

        public async ActionResult TopicWordsIndex(Guid Id)
        {
            IEnumerable<Word> words = await _dbContext.Words;
            Topic topic = await _dbContext.Topics.Include(t => t.WordTopics).ThenInclude(i => i.Word).Where(t => t.Id.Equals(Id)).Single();

            if (topic.WordTopics == null)
            {
                topic.WordTopics = new List<WordTopic>();
            }

            //ViewBag.Words = words;
            //ViewBag.Topic = topic;

            WordsTopicsViewModel wordsTopicsViewModel = new WordsTopicsViewModel();

            wordsTopicsViewModel.TopicId = Id;

            IList<WordTopicsViewModel> list = new List<WordTopicsViewModel>();

            foreach (Word word in words)
            {
                list.Add(new WordTopicsViewModel(topic.WordTopics.Any(s => s.Word.Equals(word)), word));
            }

            wordsTopicsViewModel.WordTopicsViewModels = list;

            ViewBag.WordsTopicsViewModel = wordsTopicsViewModel;

            return View();
        }

        [HttpPost]

        public async ActionResult TopicWordsIndex([FromBody] UpdateWordsTopicViewModel updateWordsTopicViewModel)
        {
            IEnumerable<Word> words = await _dbContext.Words.Where(w => updateWordsTopicViewModel.WordIds.Any(s => w.Id.Equals(s)));
            Topic topic = await _dbContext.Topics.Include(t => t.WordTopics).Where(t => t.Id.Equals(updateWordsTopicViewModel.TopicId)).Single();
            List<WordTopic> wordTopics = new List<WordTopic>();
            foreach (Word word in words)
            {
                wordTopics.Add(new WordTopic(word, topic));
            }

            topic.WordTopics = wordTopics;

            await _dbContext.SaveChanges();

            return Ok();
        }

        // GET: TopicController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TopicController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TopicController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async ActionResult Create(Topic topic)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Create));
            }

            if (topic != null)
            {
                ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;

                // the principal identity is a claims identity.
                // now we need to find the NameIdentifier claim
                var userIdClaim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                var userIdValue = userIdClaim.Value;

                IdentityUser user = await _dbContext.Users.FirstOrDefault(IdentityUser => IdentityUser.Id == userIdValue);

                topic.User = user;
                topic.UserId = user.Id;

                //It doesn`t work*
                await _dbContext.Topics.Add(topic);
                await _dbContext.SaveChanges();
            }
            return RedirectToAction("Index", "Topic");
        }

        // GET: TopicController/Edit/5
        public async ActionResult Edit(Guid Id)
        {

            Topic topic = await _dbContext.Topics.Find(Id);

            ViewBag.Topics = topic;
            return View();
        }


        // POST: WordController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async ActionResult Edit(Guid Id, [Bind("Id,Name")] Topic topic)
        {


            if (topic != null)
            {
                ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;

                // the principal identity is a claims identity.
                // now we need to find the NameIdentifier claim
                var userIdClaim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                var userIdValue = userIdClaim.Value;


                IdentityUser user = await _dbContext.Users.FirstOrDefault(IdentityUser => IdentityUser.Id == userIdValue);

                topic.User = user;
                topic.UserId = user.Id;

                //It doesn`t work*
                await _dbContext.Update(topic);
                await _dbContext.SaveChanges();
            }

            return RedirectToAction("Index", "Topic");

        }

        // GET: TopicController/Delete/5

        public async ActionResult Delete(Guid Id)
        {
            Topic topic = await _dbContext.Topics.Find(Id);
            ViewBag.Topics = topic;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async ActionResult Delete(Guid Id, IFormCollection collection)
        {
            Topic topic = await _dbContext.Topics.Find(Id);
            if (topic == null)
            {
                return RedirectToAction(nameof(Index));
            }

            await _dbContext.Topics.Remove(topic);
            await _dbContext.SaveChanges();
            return RedirectToAction("Index", "Word");

        }
    }
}
