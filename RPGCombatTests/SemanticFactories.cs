namespace RPGCombatTests;

public static class SemanticFactories
{
    public static Meters Meters(this int value) => new(value);
}