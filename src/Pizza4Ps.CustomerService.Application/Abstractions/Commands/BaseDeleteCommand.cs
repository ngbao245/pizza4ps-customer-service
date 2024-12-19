namespace Pizza4Ps.CustomerService.Application.Abstractions.Commands
{
    public class BaseDeleteCommand
    {
        public bool isHardDelete { get; set; } = false;
    }
}
