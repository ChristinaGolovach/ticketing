namespace Ticketing.Shared.Core.Exceptions
{
    public class MethodNotAllowedException : Exception
    {
        public MethodNotAllowedException(string message) : base (message)
        {
        }
    }
}
