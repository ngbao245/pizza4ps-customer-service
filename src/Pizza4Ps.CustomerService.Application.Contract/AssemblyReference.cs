using System.Reflection;

namespace Pizza4Ps.CustomerService.Contract
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
