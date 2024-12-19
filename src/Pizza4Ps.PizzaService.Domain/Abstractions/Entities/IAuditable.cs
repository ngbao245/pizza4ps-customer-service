namespace Pizza4Ps.PizzaService.Domain.Abstractions.Entities
{
    public interface IAuditable : IDateTracking, IUserTracking, ISoftDelete
    {
    }
}
