using Application.Features.CandidateRequests.Commands;
using Application.Services.CandidateRequests;
using Domain.Entitites.CandidateRequests;
using MediatR;

namespace Application.Features.CandidateRequests.Handlers.Update
{
    public class UpdateCandidateRequestHandler : IRequestHandler<UpdateCandidateRequestCommand, CandidateRequest>
    {
        private readonly ICandidateRequestService _requestService;

        public UpdateCandidateRequestHandler(ICandidateRequestService candidateRequest)
        {
            _requestService = candidateRequest;
        }

        public async Task<CandidateRequest> Handle(UpdateCandidateRequestCommand request, CancellationToken cancellationToken)
        {
            return await _requestService.UpdateRequestAsync(request.candidateRequest, cancellationToken);
        }
    }
}
