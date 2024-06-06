using BigonApp.Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.TagsModule.Commands.TagsRemoveCommand
{
    public class TagsRemoveRequest : IRequest<IEnumerable<Tag>>
    {
        public int Id { get; set; }
    }
}
