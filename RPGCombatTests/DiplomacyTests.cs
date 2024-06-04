using FluentAssertions;
using static RPGCombatTests.TestApi;

namespace RPGCombatTests;

public class DiplomacyTests
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
        
        sut.EnrollInFaction(Alliance);
        
        sut.HasAllegianceTo(Alliance).Should().BeTrue();
        sut.HasAllegianceToAnyFaction().Should().BeTrue();
    }

    [Test]
    public void MultipleAllegiance()
    {
        var sut = SomeCharacter;
        sut.EnrollInFaction(Alliance);
        sut.EnrollInFaction(Horde);
        
        sut.HasAllegianceTo(Alliance).Should().BeTrue();
        sut.HasAllegianceTo(Horde).Should().BeTrue();
    }

    [Test]
    public void HasNoAllegianceToCertainFactionByDefault()
    {
        SomeCharacter
            .HasAllegianceTo(Horde)
            .Should().BeFalse();
    }

    [Test]
    public void UnalignedCharactersAreEnemies()
    {
        SomeCharacter
            .IsEnemyOf(OtherCharacter)
            .Should().BeTrue();
    }

}