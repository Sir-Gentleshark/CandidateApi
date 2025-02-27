using Application.Features.CandidateRequests.Queries;
using Application.Services.CandidateRequests;
using Domain.Entitites.CandidateRequests;
using MediatR;

namespace Application.Features.Categories.Handlers.Read
{
    public class GetCandidateRequestByNameHandler : IRequestHandler<GetCandidateRequestByNameQuery, CandidateRequest>
    {
        private readonly ICandidateRequestService _requestService;

        public GetCandidateRequestByNameHandler(ICandidateRequestService requestService)
        {
            _requestService = requestService;
        }


        public async Task<CandidateRequest> Handle(GetCandidateRequestByNameQuery request, CancellationToken cancellationToken)
        {
            return await _requestService.GetRequestByNameAsync(request.name, cancellationToken);
        }
    }
}
