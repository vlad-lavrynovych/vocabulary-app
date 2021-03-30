using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace vocabulary_app.Models
{
    public class Word : IEquatable<Word>
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public string OriginalValue { get; set; }
        public string TranslatedValue { get; set; }
        public string PartOfSpeech { get; set; }
        public string PartOfSpeechDetails { get; set; }
        public string Description { get; set; }
        public IEnumerable<WordTopic> WordTopics { get; set; }

        public override bool Equals(object obj)
        {
            return obj != null && Equals(obj as Word);
        }

        public bool Equals(Word other)
        {
            return other != null &&
                   Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }

}
