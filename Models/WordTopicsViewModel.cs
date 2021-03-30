using System;

namespace vocabulary_app.Models
{
    public class WordTopicsViewModel
    {
        public bool Selected { get; set; }
        public Word Word { get; set; }

        public WordTopicsViewModel(bool selected, Word word)
        {
            Selected = selected;
            Word = word;
        }

        public WordTopicsViewModel()
        {
        }
    }
}
