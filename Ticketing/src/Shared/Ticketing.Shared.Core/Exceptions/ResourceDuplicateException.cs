namespace Ticketing.Shared.Core.Exceptions
{
    public class ResourceDuplicateException : Exception
    {
        public ResourceDuplicateException(string message) : base(message)
        {
        }
    }
}
