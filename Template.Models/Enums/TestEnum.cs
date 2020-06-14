using System.Text.Json.Serialization;

namespace Template.Models.Enums
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum TestEnum
	{
		A = 1,
		B,
		C
	}
}