using System.Reflection;

namespace Pizza4Ps.CustomerService.Persistence
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
