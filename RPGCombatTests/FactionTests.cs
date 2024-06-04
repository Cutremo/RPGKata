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
    
    
}