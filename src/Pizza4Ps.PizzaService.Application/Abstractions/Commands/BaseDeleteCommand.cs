namespace Pizza4Ps.PizzaService.Application.Abstractions.Commands
{
    public class BaseDeleteCommand
    {
        public bool isHardDelete { get; set; } = false;
    }
}
