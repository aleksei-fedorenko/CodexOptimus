namespace Services.Helpers
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Throwing an <see cref="ArgumentNullException"/> if the <paramref name="obj"/> is null
        /// </summary>
        /// <typeparam name="T">Argument type</typeparam>
        /// <param name="obj">Argument</param>
        /// <param name="argumentName">Argument name</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T ThrowIfNull<T>(this T obj, string argumentName) where T : class
            => obj ?? throw new ArgumentNullException(argumentName);
    }
}