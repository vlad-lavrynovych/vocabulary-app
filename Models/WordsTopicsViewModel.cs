using System;
using System.Collections.Generic;

namespace vocabulary_app.Models
{
    public class WordsTopicsViewModel
    {
        public Guid TopicId { get; set; }
        public IList<WordTopicsViewModel> WordTopicsViewModels { get; set; }
    }
}
