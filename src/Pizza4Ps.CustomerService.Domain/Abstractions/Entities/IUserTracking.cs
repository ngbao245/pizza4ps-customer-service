namespace Pizza4Ps.CustomerService.Domain.Abstractions.Entities
{
    public interface IUserTracking
    {
        string? CreatedBy { get; set; }
        string? ModifiedBy { get; set; }
    }
}
