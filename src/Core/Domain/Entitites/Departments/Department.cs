using Domain.Entitites.CandidateRequests;

namespace Domain.Entitites.Departments
{
    public class Department : Base
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Mark { get; set; } = 0;

        // Relationship
        public Guid RequestId { get; set; }
        public CandidateRequest CandidateRequest { get; set; }
    }
}
