namespace IChiba.Core
{
    /// <summary>
    /// Represents work context
    /// </summary>
    public interface IWorkContext
    {
        string LanguageId { get; }

        string UserId { get; }

        string UserName { get; }
    }
}
