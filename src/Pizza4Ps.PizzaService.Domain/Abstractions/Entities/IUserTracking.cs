namespace Pizza4Ps.PizzaService.Domain.Abstractions.Entities
{
    public interface IUserTracking
    {
        string? CreatedBy { get; set; }
        string? ModifiedBy { get; set; }
    }
}
