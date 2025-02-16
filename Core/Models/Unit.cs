using System.ComponentModel;

namespace Core.Models;

public enum Unit
{
    Unknown = 0,
    [Description("grams")]
    g,
    [Description("kilograms")]
    Kg,
    [Description("milliliters")]
    ml,
    [Description("liters")]
    L,
    [Description("pieces")]
    pcs
}