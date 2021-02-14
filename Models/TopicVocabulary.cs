using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vocabulary_app.Models
{
    public class TopicVocabulary
    {
        public Guid Id {get;set;}
        public Guid VocabularyId { get; set; }
        public Vocabulary Vocabulary { get; set; }

        public Guid TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
