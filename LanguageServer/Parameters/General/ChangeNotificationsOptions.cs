using LanguageServer.Json;

namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// For <c>initialize</c>
    /// </summary>
    /// <remarks>
    /// <see cref="string"/> | <see cref="bool"/>
    /// </remarks>
    /// <seealso>Spec 3.6.0</seealso>
    public class ChangeNotificationsOptions : Either<string, bool>
    {
        public ChangeNotificationsOptions(string value) : base(value) { }
        public ChangeNotificationsOptions(bool value) : base(value) { }
        public static implicit operator ChangeNotificationsOptions(string value) => new(value);
        public static implicit operator ChangeNotificationsOptions(bool value) => new(value);
    }
}
