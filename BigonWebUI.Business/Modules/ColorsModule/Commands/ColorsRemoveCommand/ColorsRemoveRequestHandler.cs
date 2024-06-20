using BigonApp.Infrastructure.Entities;
using BigonApp.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.ColorsModule.Commands.ColorsRemoveCommand
{
    internal class ColorsRemoveRequestHandler : IRequestHandler<ColorsRemoveRequest,IEnumerable<Color>>
    {
        private readonly IColorRepository _colorRepository;

        public ColorsRemoveRequestHandler(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public async Task<IEnumerable<Color>> Handle(ColorsRemoveRequest request, CancellationToken cancellationToken)
        {
            var color = _colorRepository.Get(x => x.Id == request.Id && x.DeletedBy == null);

            _colorRepository.Remove(color);

            return /*await*/ _colorRepository.GetAll(x => x.DeletedBy == null);
        }
    }
}
