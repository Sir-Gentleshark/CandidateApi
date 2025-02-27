using Application.Services.CandidateRequests;
using Data.Database;
using Domain.Entitites.CandidateRequests;
using Domain.Helpers.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.CandidateRequests
{
    internal class RequestService : ICandidateRequestService
    {
        #region Constructor
        private readonly ApplicationDbContext _db;

        public RequestService(ApplicationDbContext db)
        {
            _db = db;
        }

        #endregion Constructor

        #region Create (C)

        /// </summary>
        /// <param name="request">Request to create in the database</param>
        /// <returns>The request that has been created in the database</returns>
        public async Task<CandidateRequest> CreateRequestAsync(CandidateRequest request, CancellationToken ct)
        {
            // Make sure that we do not have any categories in the database with the same name
            if (await _db.Candidates.AsNoTracking().AnyAsync(x => x.Position == request.Position))
                throw new CustomException($"A request with the name {request.Position} already exists.");

            // Add and save the request in the database
            _db.Candidates.Add(request);
            await _db.SaveChangesAsync(ct);
            return request;
        }

        #endregion Create (C)

        #region Read (R)

        /// </summary>
        /// <returns>List of requests from database</returns>
        public async Task<List<CandidateRequest>> GetRequestsAsync(CancellationToken ct)
        {
            List<CandidateRequest> requests = await _db.Candidates
                .AsNoTracking()
                .ToListAsync(cancellationToken: ct);

            if (requests.Count() == 0)
            {
                throw new KeyNotFoundException("There are no categories in the database. Please add a request and try again.");
            }

            return requests;
        }

        /// </summary>
        /// <param name="id">Request ID</param>
        /// <returns>Request</returns>
        public async Task<CandidateRequest> GetRequestByIdAsync(Guid id, CancellationToken ct)
        {
            return await getRequestByIdAsync(id, ct);
        }

        /// </summary>
        /// <param name="name">request Name</param>
        /// <returns>A request</returns>
        public async Task<CandidateRequest> GetRequestByNameAsync(string name, CancellationToken ct)
        {
            return await getRequestByNameAsync(name, ct);
        }

        #endregion Read (R)

        #region Update (U)

        /// <returns>The updated request</returns>
        /// <exception cref="CustomException">Thrown if a request in the database with the same name already exists</exception>
        public async Task<CandidateRequest> UpdateRequestAsync(CandidateRequest requestToUpdate, CancellationToken ct)
        {
            // Make sure that the request exist in the database
            CandidateRequest request = await getRequestByIdAsync(requestToUpdate.Id, ct);

            // Validation before updating the request
            // We don't want any categories in the database with the same name
            if (request.Position != requestToUpdate.Position && await _db.Candidates.AnyAsync(x => x.Position == requestToUpdate.Position))
            {
                throw new CustomException($"A request with the name {requestToUpdate.Position} already exist in the database. Please choose another name.");
            }

            // No problems, let's update the request
            _db.Candidates.Update(requestToUpdate);
            await _db.SaveChangesAsync(cancellationToken: ct);
            return requestToUpdate;
        }

        #endregion Update (U)

        #region Delete (D)

        /// </summary>
        /// <param name="id">ID of the request to delete</param>
        public async Task DeleteRequestAsync(Guid id, CancellationToken ct)
        {
            CandidateRequest request = await getRequestByIdAsync(id, ct);
            _db.Candidates.Remove(request);
            await _db.SaveChangesAsync(cancellationToken: ct);
        }

        #endregion Delete (D)

        #region Helpers

        /// <summary>
        /// Get a request by the id of the request.
        /// </summary>
        /// <param name="id">ID for request</param>
        /// <returns>The request matching the ID provided for the request.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the request wasn't found in the database</exception>
        private async Task<CandidateRequest> getRequestByIdAsync(Guid id, CancellationToken ct)
        {
            CandidateRequest request = await _db.Candidates.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken: ct);
            if (request == null) throw new KeyNotFoundException("The request was not found in the database.");
            return request;
        }

        /// </summary>
        /// <param name="name">Name of the request</param>
        /// <returns>The request matching the name provided for the request.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the request wasn't found in the database</exception>
        private async Task<CandidateRequest> getRequestByNameAsync(string name, CancellationToken ct)
        {
            CandidateRequest request = await _db.Candidates.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name, cancellationToken: ct);
            if (request == null) throw new KeyNotFoundException("The request was not found in the database.");
            return request;
        }

        #endregion Helpers

    }
}
