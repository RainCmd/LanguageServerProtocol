using LanguageServer.Json;

namespace LanguageServer.Parameters.General
{
    /// <summary>
    /// <see cref="RenameOptions"/> | <see cref="bool"/>
    /// </summary>
    public class RenameOptionsOrBoolean : Either<RenameOptions, bool>
    {
        public RenameOptionsOrBoolean(RenameOptions value) : base(value) { }
        public RenameOptionsOrBoolean(bool value) : base(value) { }


        public static implicit operator RenameOptionsOrBoolean(RenameOptions value) => new(value);
        public static implicit operator RenameOptionsOrBoolean(bool value) => new(value);

    }
}
