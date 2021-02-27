using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vocabulary_app.Models
{
    public sealed class PartOfSpeech
    {
        private readonly String name;
        private readonly int value;

        public static PartOfSpeech NOUN = new PartOfSpeech(1, "NOUN");
        public static PartOfSpeech PRONOUN = new PartOfSpeech(2, "PRONOUN");
        public static PartOfSpeech VERB = new PartOfSpeech(3, "VERB");
        public static PartOfSpeech ADJECTIVE = new PartOfSpeech(4, "ADJECTIVE");
        public static PartOfSpeech ADVERB = new PartOfSpeech(5, "ADVERB");
        public static PartOfSpeech PREPOSITION = new PartOfSpeech(6, "PREPOSITION");
        public static PartOfSpeech CONJUNCTION = new PartOfSpeech(7, "CONJUNCTION");
        public static PartOfSpeech INTERJECTION = new PartOfSpeech(8, "INTERJECTION");

        private PartOfSpeech(int value, String name)
        {
            this.name = name;
            this.value = value;
        }

        public PartOfSpeech()
        { }
        public override String ToString()
        {
            return name;
        }
    }
}
