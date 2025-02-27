using Domain.Entitites.Managers;

namespace Domain.Entitites.CandidateRequests;
    public class CandidateRequest: Base
    {
        public enum Status { Submitted, Approved, Declined}
        public string Name {  get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Status Status { get; set; } = Status.Submitted;

        // Relationship
        public Guid ManagerId { get; set; }
        public Manager Manager { get; set; }
    }
