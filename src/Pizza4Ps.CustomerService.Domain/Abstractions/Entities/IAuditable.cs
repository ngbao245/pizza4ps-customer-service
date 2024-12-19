namespace Pizza4Ps.CustomerService.Domain.Abstractions.Entities
{
    public interface IAuditable : IDateTracking, IUserTracking, ISoftDelete
    {
    }
}
