using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace vocabulary_app.Models
{
    public class AdvancedWordTestQuestion
    {

        [Required]
        public Word Word { get; set; }

        [Required]
        public List<Word> Answers { get; set; }
    }
}
