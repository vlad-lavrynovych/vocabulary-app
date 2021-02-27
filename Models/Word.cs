using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vocabulary_app.Models
{
    public class Word
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string OriginalValue { get; set; }
        public string TranslatedValue { get; set; }
        public string PartOfSpeech { get; set; }
        public string PartOfSpeechDetails { get; set; }
        public string Description { get; set; }
        public IEnumerable<WordTopic> WordTopics { get; set; }
    }
}
