namespace DTO.CandidateRequests
{
    public class UpdateRequestDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Position {  get; set; } = string.Empty;
        public int Status { get; set; }
    }
}
