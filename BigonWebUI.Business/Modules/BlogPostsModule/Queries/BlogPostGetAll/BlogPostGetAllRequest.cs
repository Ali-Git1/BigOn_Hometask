using BigonApp.Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.BlogPostsModule.Queries.BlogPostGetAll
{
    public class BlogPostGetAllRequest : IRequest<IEnumerable<BlogPostGetAllDto>>
    {
    }
}
