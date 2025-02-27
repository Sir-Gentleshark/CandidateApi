using Application.Features.CandidateRequests.Commands;
using Application.Services.CandidateRequests;
using MediatR;

namespace Application.Features.Categories.Handlers.Delete
{
    public class DeleteCandidateRequestHandler : IRequestHandler<DeleteCandidateRequestByIdCommand>
    {
        private readonly ICandidateRequestService _requestService;

        public DeleteCandidateRequestHandler(ICandidateRequestService candidateRequest)
        {
            _requestService = candidateRequest;
        }

        public async Task Handle(DeleteCandidateRequestByIdCommand request, CancellationToken cancellationToken)
        {
            await _requestService.DeleteRequestAsync(request.id, cancellationToken);
        }
    }
}
