using Application.Features.CandidateRequests.Commands;
using Application.Services.CandidateRequests;
using Domain.Entitites.CandidateRequests;
using MediatR;

namespace Application.Features.Categories.Handlers.Update
{
    public class UpdateCandidateRequestHandler : IRequestHandler<UpdateCandidateRequestCommand, CandidateRequest>
    {
        private readonly ICandidateRequestService _requestService;

        public UpdateCandidateRequestHandler(ICandidateRequestService categories)
        {
            _requestService = categories;
        }

        public async Task<CandidateRequest> Handle(UpdateCandidateRequestCommand request, CancellationToken cancellationToken)
        {
            return await _requestService.UpdateRequestAsync(request.CandidateRequest, cancellationToken);
        }
    }
}
