using BigonApp.Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.TagsModule.Commands.TagsEditCommand
{
    public class TagsEditRequest : IRequest<Tag>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
    }
}
