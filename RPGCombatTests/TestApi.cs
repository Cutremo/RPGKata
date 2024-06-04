namespace RPGCombatTests;
using static RPGCombatTests.Character;

public class TestApi
{
    public static Character SomeCharacter => MeleeFighter;
    public static Character OtherCharacter => MeleeFighter;
    public static Character SomeoneElse => MeleeFighter;
    public static Faction Alliance => Faction.WithName("Alliance");
    public static Faction Horde => Faction.WithName("Horde");
}