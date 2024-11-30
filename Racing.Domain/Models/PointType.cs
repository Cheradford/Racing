using Racing.Domain.Abstraction;

namespace Racing.Domain.Models;

public enum PointType
{
    [EnumColor("#F7F5FB")]
    Regular,
    [EnumColor("#274690")]
    Rain,
    [EnumColor("#F9AB55")]
    Heat,
    [EnumColor("#FF5A5F")]
    Finish
}