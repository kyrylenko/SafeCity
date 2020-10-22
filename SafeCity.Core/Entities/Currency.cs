using System.Runtime.Serialization;

namespace SafeCity.Core.Entities
{
    public enum Currency
    {
        [EnumMember(Value = "UAH")]
        Uah = 980,
        [EnumMember(Value = "USD")]
        Usd = 840,
        [EnumMember(Value = "EUR")]
        Euro = 978
    }
}
