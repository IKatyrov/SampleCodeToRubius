using JetBrains.Annotations;

namespace Services
{
    public interface ILogger
    {
        void PrintLog([NotNull] string message);
        void PrintWarning([NotNull] string message);
        void PrintError([NotNull] string message);
    }
}