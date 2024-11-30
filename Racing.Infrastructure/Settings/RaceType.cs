using System.ComponentModel;

namespace Racing.Domain.Abstraction;

public enum RaceType
{
    [Description("Наземные гонки")]
    Ground,
    [Description("Воздушные гонки")]
    Air,
    [Description("Смешанные гонки")]
    Mixed
}