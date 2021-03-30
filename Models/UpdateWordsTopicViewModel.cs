using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vocabulary_app.Models
{
    public class UpdateWordsTopicViewModel
    {
        public Guid TopicId { get; set; }
        public IEnumerable<Guid> WordIds { get; set; } = new List<Guid>();
    }
}
