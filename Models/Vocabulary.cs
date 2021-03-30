using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace vocabulary_app.Models
{
    public class Vocabulary
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.-]*$", ErrorMessage = "only letters and numbers")]
        [StringLength(20, ErrorMessage = "Назва словника повинна бути не більше 20 та не менше 1 літери!", MinimumLength = 1)]
        public string Name { get; set; }
        public IEnumerable<TopicVocabulary> TopicVocabularies { get; set; }
    }
}
