using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace vocabulary_app.Models
{
    public class WordTestAnswer
    {
        public Guid WordId { get; set; }

        [Required]
        public string Translation { get; set; }

        [Required]
        public bool Correct { get; set; }

        [Required]
        public string CorrectTranslation { get; set; }
        [Required]
        public string OriginalValue { get; set; }
    }
}
