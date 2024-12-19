namespace Pizza4Ps.PizzaService.Domain.Abstractions.Entities
{
    public interface IDateTracking
    {
        DateTimeOffset CreatedDate { get; set; }
        DateTimeOffset? ModifiedDate { get; set; }
    }
}
