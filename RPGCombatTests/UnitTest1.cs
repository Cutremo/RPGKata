using FluentAssertions;

namespace RPGCombatTests;

public class Tests
{
    static Character SomeCharacter => new();
    static Character OtherCharacter => new();
    [Test]
    public void DealHundredDamage()
    {
        var doc = OtherCharacter;

        SomeCharacter.DealDamageTo(doc, 100);

        doc.Health.Should().Be(900);
    }

    [Test]
    public void DefaultHealthIsAThousand()
    {
        SomeCharacter
            .Health
            .Should().Be(1000);
    }

    [Test]
    public void KillCharacter()
    {
        var sut = SomeCharacter;

        OtherCharacter.DealDamageTo(sut, 1000);

        sut.Health.Should().Be(0);
        sut.Alive.Should().BeFalse();
    }

    [Test]
    public void CharacterIsAliveByDefault()
    {
        SomeCharacter
            .Alive
            .Should().BeTrue();
    }

    [Test]
    public void DamageClampsToZero()
    {
        var sut = SomeCharacter;

        OtherCharacter.DealDamageTo(sut, 1300);

        sut.Health.Should().Be(0);
    }

    [Test]
    public void DefaultLevelIsOne()
    {
        SomeCharacter
            .Level
            .Should().Be(1);
    }

    [Test]
    public void CastHealToCharacter()
    {
        var sut = SomeCharacter;
        OtherCharacter.DealDamageTo(sut, 500);
        
        sut.Heal(100);

        sut.Health.Should().Be(600);
    }

    [Test]
    public void ClampHealthToAThousand()
    {
        var sut = SomeCharacter;
        OtherCharacter.DealDamageTo(sut, 100);
        
        sut.Heal(1000);

        sut.Health.Should().Be(1000);
    }
}