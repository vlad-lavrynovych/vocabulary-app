using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace vocabulary_app.Models
{
    public class Word
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }


        public IdentityUser User { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z]+", ErrorMessage = "only letters")]
        [StringLength( 20, ErrorMessage = "Слово повинно бути не більше 20 та не менше 1 літери!", MinimumLength = 1)]
        public string OriginalValue { get; set; }

        [Required]
        [RegularExpression(@"[А-Яа-я]+", ErrorMessage = "only cyrylic letters")]
        [StringLength(20, ErrorMessage = "Переклад повинен бути не більше 20 та не менше 1 літери!", MinimumLength = 1)]
        public string TranslatedValue { get; set; }

        [Required]
        public string PartOfSpeech { get; set; }

        public string PartOfSpeechDetails { get; set; }


        [StringLength(200, ErrorMessage = "Опис повинен бути не більше 200 та не менше 1 літери!", MinimumLength = 1)]
        public string Description { get; set; }
        public IEnumerable<WordTopic> WordTopics { get; set; }
    }
}
