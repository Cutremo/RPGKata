using FluentAssertions;
using static RPGCombatTests.TestApi;

namespace RPGCombatTests;

public class FactionTests
{
    [Test]
    public void jskjdsjkjdsk()
    {
        SomeCharacter
            .IsEnrolledInAnyFaction()
            .Should().BeFalse();
    }

    [Test]
    public void ksjkdjskjdk()
    {
        var sut = SomeCharacter;
        
        sut.EnrollInFaction(Faction.WithName("Alliance"));
        
        sut.IsEnrolledInFaction(Faction.WithName("Alliance"))
            .Should().BeTrue();
    }
}

public struct Faction
{
    string name;
    Faction(string name) => this.name = name;
    public static Faction None => new();
    public static Faction WithName(string name) => new(name);
}