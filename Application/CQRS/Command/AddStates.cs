using Application.Interface;
using AutoMapper;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Command
{
    public class AddStates:IRequest<State>
    {
        public string? Name { get; set; }
        public int CountryId { get; set; }
    }
    public class AddStateHandler:IRequestHandler<AddStates, State>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public AddStateHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<State> Handle(AddStates request,CancellationToken cancellationToken)
        {
            var state = new State
            {
                StateName = request.Name,
                CountryId = request.CountryId
            };

            _context.States.Add(state);
            await _context.SaveChangesAsync();
            return state;

        }

    }
}
