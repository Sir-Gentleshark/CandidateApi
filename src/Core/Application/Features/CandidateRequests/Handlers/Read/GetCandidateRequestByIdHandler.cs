using Application.Features.CandidateRequests.Queries;
using Application.Services.CandidateRequests;
using Domain.Entitites.CandidateRequests;
using MediatR;

namespace Application.Features.Categories.Handlers.Read
{
    public class GetCandidateRequestByIdHandler : IRequestHandler<GetCandidateRequestByIdQuery, CandidateRequest>
    {
        private readonly ICandidateRequestService _categories;

        public GetCandidateRequestByIdHandler(ICandidateRequestService categories)
        {
            _categories = categories;
        }

        public async Task<CandidateRequest> Handle(GetCandidateRequestByIdQuery request, CancellationToken cancellationToken)
        {
            return await _categories.GetRequestByIdAsync(request.id, cancellationToken);
        }
    }
}
