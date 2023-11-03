namespace Api.Infrastructure.Dto
{
    public class EntityDto
    {
        public Guid Id { get; set; }
        public DateTime OperationDate { get; set; }
        public decimal Amount { get; set; }
    }
}
