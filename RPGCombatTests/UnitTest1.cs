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
        
        sut.CastHealTo(sut, 100);

        sut.Health.Should().Be(600);
    }

    [Test]
    public void ClampHealthToAThousand()
    {
        var sut = SomeCharacter;
        OtherCharacter.DealDamageTo(sut, 100);
        
        sut.CastHealTo(sut, 1000);

        sut.Health.Should().Be(1000);
    }
}

public class Character
{
    public void DealDamageTo(Character target, int damage)
    {
        if(target == this)
            throw new ArgumentException("Cannot attack itself");
        target.Health = Math.Max(0, target.Health - damage);
    }

    public int Health { get; private set; } = 1000;
    public bool Alive => Health > 0;
    public bool Dead => !Alive;
    public int Level => 1;

    public void CastHealTo(Character target, int healAmount)
    {
        if (target.Dead)
            throw new ArgumentException("Cannot heal a dead character");
        
        target.Health = Math.Min(1000, target.Health + healAmount);
    }
}