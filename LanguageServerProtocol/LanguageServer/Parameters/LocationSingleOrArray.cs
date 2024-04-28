using LanguageServer.Json;

namespace LanguageServer.Parameters
{
    public class LocationSingleOrArray : Either
    {
        public static implicit operator LocationSingleOrArray(Location value) => new(value);

        public static implicit operator LocationSingleOrArray(Location[] value) => new(value);

        public LocationSingleOrArray(Location value) : base(value, typeof(Location)) { }

        public LocationSingleOrArray(Location[] value) : base(value, typeof(Location[])) { }

        public bool IsSingle => type == typeof(Location);

        public bool IsArray => type == typeof(Location[]);

        public Location Single => (Location)value;

        public Location[] Array => (Location[])value;
    }
}
