using BigonApp.Business.Modules.BlogPostsModule.Queries.BlogPostGetAll;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.BlogPostsModule.Commands.BlogPostRemove
{
    public class BlogPostRemoveRequest:IRequest<IEnumerable<CategoriesGetAllDto>>
    {
        public int Id { get; set; }
    }
}
