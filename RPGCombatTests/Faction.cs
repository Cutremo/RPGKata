namespace RPGCombatTests;

public struct Faction
{
    string name;
    Faction(string name) => this.name = name;
    public static Faction None => new();
    public static Faction WithName(string name) => new(name);
}