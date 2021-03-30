using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vocabulary_app.Models
{
    public class AdvancedWordTestQuestion
    {
        public Word Word { get; set; }
        public List<Word> Answers { get; set; }
    }
}
