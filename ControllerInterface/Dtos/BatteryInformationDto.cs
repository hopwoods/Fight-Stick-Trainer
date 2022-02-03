using System.Text.Json.Serialization;

namespace ControllerInterface.Dtos;

public class BatteryInformationDto: IEquatable<BatteryInformationDto>
{
    [JsonPropertyName("BatteryType")]
    public BatteryType BatteryType { get; set; }

    [JsonPropertyName("BatteryLevel")]
    public BatteryLevel BatteryLevel { get; set; }

    #region Equality members

    public bool Equals(BatteryInformationDto? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return BatteryType == other.BatteryType && BatteryLevel == other.BatteryLevel;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((BatteryInformationDto)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine((int)BatteryType, (int)BatteryLevel);
    }

    #endregion
}
