using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vocabulary_app.Models
{
    public class WordTopic
    {
        public Guid Id { get; set; }
        public Guid WordId { get; set; }
        public Word Word { get; set; }
        public Guid TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
