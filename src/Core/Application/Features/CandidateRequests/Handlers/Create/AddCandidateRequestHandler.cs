using Application.Features.CandidateRequests.Commands;
using Application.Services.CandidateRequests;
using Domain.Entitites.CandidateRequests;
using MediatR;

namespace Application.Features.CandidateRequests.Handlers.Create
{
    public class AddCandidateRequestHandler : IRequestHandler<AddCandidateRequestCommand, CandidateRequest>
    {
        private readonly ICandidateRequestService _requestService;

        public AddCandidateRequestHandler(ICandidateRequestService categories)
        {
            _requestService = categories;
        }

        public async Task<CandidateRequest> Handle(AddCandidateRequestCommand request, CancellationToken cancellationToken)
        {
            return await _requestService.CreateRequestAsync(request.category, cancellationToken);
        }
    }
}
