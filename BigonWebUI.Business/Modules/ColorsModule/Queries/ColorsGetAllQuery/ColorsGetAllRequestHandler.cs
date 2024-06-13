using BigonApp.Infrastructure.Entities;
using BigonApp.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.ColorsModule.Queries.ColorsGetAllQuery
{
    internal class ColorsGetAllRequestHandler : IRequestHandler<ColorsGetAllRequest, IEnumerable<Color>>
    {
        private readonly IColorRepository _colorRepository;

        public ColorsGetAllRequestHandler(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }
        public async Task<IEnumerable<Color>> Handle(ColorsGetAllRequest request, CancellationToken cancellationToken)
        {
           return  await _colorRepository.GetAll(c => c.DeletedBy == null);
        }
    }
}
