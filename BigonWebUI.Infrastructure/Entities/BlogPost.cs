using BigonApp.Infrastructure.Commons.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Infrastructure.Entities
{
    public class BlogPost:BaseEntity<int>
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string FilePath { get; set; }
        public string Slug { get; set; }
        public int CategoryId { get; set; }
        public DateTime? PublishedAt { get; set; }
        public int? PublishedBy { get; set; }


    }
}
