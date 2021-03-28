using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace vocabulary_app.Models
{
    public class Topic
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.-]*$", ErrorMessage = "only letters and numbers")]
        [StringLength(20, ErrorMessage = "Назва теми повинна бути не більше 20 та не менше 1 alphanumeric!", MinimumLength = 1)]
        public string Name { get; set; }
        public IEnumerable<WordTopic> WordTopics { get; set; }
        public IEnumerable<TopicVocabulary> TopicVocabularies { get; set; }

    }
}
