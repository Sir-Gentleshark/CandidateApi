using Application.Services.Common;
using Domain.Entitites.CandidateRequests;

namespace Application.Services.CandidateRequests
{
    public interface ICandidateRequestService : ITransientService
    {
        /// <summary>
        /// Get a single Request by the ID of the Request.
        /// </summary>
        /// <param name="id">Request ID</param>
        /// <returns>A Single Request</returns>
        Task<CandidateRequest> GetRequestByIdAsync(Guid id, CancellationToken ct);

        /// <summary>
        /// Get a single Request by the name of the Request.
        /// </summary>
        /// <param name="name">Request name</param>
        /// <returns>A Single Request</returns>
        Task<CandidateRequest> GetRequestByNameAsync(string name, CancellationToken ct);

        /// <summary>
        /// Get all requests in the database (if any).<br />
        /// </summary>
        /// <returns>A list of requests to enumerate</returns>
        Task<List<CandidateRequest>> GetRequestsAsync(CancellationToken ct);

        /// <summary>
        /// Add a new Request to the database.<br />
        /// This method will check if the Request already exist in the database by checking the name of the Request.<br />
        /// If a caetgory already exists in the database with the same name, an exception will be thrown and a status code of 400 (Bad Request) will be returned.
        /// </summary>
        /// <param name="Request">Request to add in database</param>
        /// <returns>The Request that has been added in the database</returns>
        Task<CandidateRequest> CreateRequestAsync(CandidateRequest Request, CancellationToken ct);

        /// <summary>
        /// Update a Request in the database.<br />
        /// If the Request doesn't exist a status code of 404 (Not Found) will be returned.<br />
        /// If the Request name matches the name of another Request in the database, a status code of 400 (Bad Request) will be returned.
        /// The updated Request name can also not be the same as the one of the current Request.
        /// </summary>
        /// <param name="Request">Request to update</param>
        /// <returns>The updated Request in the database</returns>
        Task<CandidateRequest> UpdateRequestAsync(CandidateRequest Request, CancellationToken ct);

        /// <summary>
        /// Delete a specific Request by the ID of the Request.<br />
        /// If the Request doesn't exist a status code of 404 (Not Found) will be returned.
        /// </summary>
        /// <param name="id">Request ID</param>
        /// <returns></returns>
        Task DeleteRequestAsync(Guid id, CancellationToken ct);
    }
}
