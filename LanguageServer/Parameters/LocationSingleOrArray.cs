using LanguageServer.Json;

namespace LanguageServer.Parameters
{
    /// <summary>
    /// <see cref="Location"/> | <see cref="Location"/> []
    /// </summary>
    public class LocationSingleOrArray : Either<Location, Location[]>
    {
        public LocationSingleOrArray(Location value) : base(value) { }
        public LocationSingleOrArray(Location[] value) : base(value) { }
        public static implicit operator LocationSingleOrArray(Location value) => new(value);
        public static implicit operator LocationSingleOrArray(Location[] value) => new(value);
    }
}
