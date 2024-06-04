using FluentAssertions;
using static RPGCombatTests.TestApi;

namespace RPGCombatTests;

public class FactionTests
{
    [Test]
    public void CharacterHasNoAllegianceByDefault()
    {
        SomeCharacter
            .HasAllegianceToAnyFaction()
            .Should().BeFalse();
    }

    [Test]
    public void EnrollInFaction()
    {
        var sut = SomeCharacter;
        
        sut.EnrollInFaction(Faction.WithName("Alliance"));
        
        sut.HasAllegianceTo(Faction.WithName("Alliance")).Should().BeTrue();
        sut.HasAllegianceToAnyFaction().Should().BeTrue();
    }

    [Test]
    public void MultipleAllegiance()
    {
        var sut = SomeCharacter;
        sut.EnrollInFaction(Faction.WithName("Alliance"));
        sut.EnrollInFaction(Faction.WithName("Horde"));
        
        sut.HasAllegianceTo(Faction.WithName("Alliance")).Should().BeTrue();
        sut.HasAllegianceTo(Faction.WithName("Horde")).Should().BeTrue();
    }

    [Test]
    public void HasNoAllegianceToCertainFactionByDefault()
    {
        SomeCharacter
            .HasAllegianceTo(Faction.WithName("Horde"))
            .Should().BeFalse();
    }

    [Test]
    public void alskdlskldk()
    {
        SomeCharacter.IsAlliedTo(OtherCharacter).Should().BeFalse();
    }
}