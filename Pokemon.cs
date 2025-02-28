using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text.Json.Serialization;
public class Pokemon
{
    [JsonPropertyName("name")]
    public string RawName { get; set; } = string.Empty;
    public string Name => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(RawName);
    [JsonPropertyName("height")]
    public int HeightInDecimeters { get; set; }
    [JsonPropertyName("weight")]
    public int WeightInHectograms { get; set; }
    [JsonPropertyName("abilities")]
    public List<AbilityWrapper>? Abilities { get; set; }
    [JsonPropertyName("types")]
    public List<TypeWrapper>? Types { get; set; }
    [JsonPropertyName("stats")]
    public List<StatWrapper>? Stats { get; set; }

    public double HeightInMeters => HeightInDecimeters / 10.0;
    public double WeightInKilograms => WeightInHectograms / 10.0;

    public override string ToString()
    {
        string newLine = Environment.NewLine;

        string abilities = Abilities?.Count > 0
        ? string.Join(", ", Abilities.ConvertAll(a => a.Ability.Name))
        : "Ingen data";

        string types = Types != null
        ? string.Join(", ", Types.ConvertAll(t => t.Type.Name))
        : "Ingen data";

        string stats = Stats != null
        ? string.Join(", ", Stats.ConvertAll(s => $"{s.Stat.Name}: {s.BaseStat}"))
        : "Ingen data";

        return $"Navn: {Name}{newLine}" +
        $"Høyde: {HeightInMeters} m{newLine}" +
        $"Vekt: {WeightInKilograms} kg{newLine}" +
        $"Type: {types}{newLine}" +
        $"Evner: {abilities}{newLine}" +
        $"Base Stats: {stats}";
    }
}

public class AbilityWrapper
{
    [JsonPropertyName("ability")]
    public Ability Ability { get; set; } = new Ability();
}

public class Ability
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}

public class TypeWrapper
{
    [JsonPropertyName("type")]
    public TypeInfo Type { get; set; } = new TypeInfo();
}

public class TypeInfo
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}

public class StatWrapper
{
    [JsonPropertyName("base_stat")]
    public int BaseStat { get; set; }
    [JsonPropertyName("stat")]
    public StatInfo Stat { get; set; } = new StatInfo();
}

public class StatInfo
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}