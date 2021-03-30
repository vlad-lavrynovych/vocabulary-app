using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vocabulary_app.Models
{
    public class WordTestAnswer
    {
        public Guid WordId { get; set; }
        public string Translation { get; set; }
        public bool Correct { get; set; }
        public string CorrectTranslation { get; set; }
        public string OriginalValue { get; set; }
    }
}
