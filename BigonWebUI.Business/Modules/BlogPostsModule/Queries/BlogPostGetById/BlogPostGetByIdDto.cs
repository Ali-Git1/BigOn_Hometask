﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.BlogPostsModule.Queries.BlogPostGetById
{
    public class BlogPostGetByIdDto
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Body { get; set; }
        public string FilePath { get; set; }
        public string Slug { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }

        public DateTime? PublishedAt { get; set; }
        public int? PublishedBy { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }



    }
}