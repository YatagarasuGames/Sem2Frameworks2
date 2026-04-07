namespace Frameworks2.Core
{
    public sealed class ModuleLoadException : Exception
    {
        public ModuleLoadException(string message)
            : base(message)
        {
        }
    }
}
