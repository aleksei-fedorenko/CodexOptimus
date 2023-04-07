namespace Services.Helpers
{
    public static class ObjectExtensions
    {
        public static T ThrowIfNull<T>(this T obj, string argumentName) where T : class
            => obj ?? throw new ArgumentNullException(argumentName);
    }
}