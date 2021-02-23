using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vocabulary_app.Models
{
    public class Topic
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public IEnumerable<WordTopic> WordTopics { get; set; }
        public IEnumerable<TopicVocabulary> TopicVocabularies { get; set; }

    }
}
