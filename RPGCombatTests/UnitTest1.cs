using FluentAssertions;
namespace RPGCombatTests;

public class Tests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void DealHundredDamage()
    {
        var sut = new Character();
        var doc = new Character();

        sut.DealDamageTo(doc, 100);
        
        doc.Health.Should().Be(900);
    }

    [Test]
    public void DefaultHealthIsAThousand()
    {
        new Character()
            .Health
            .Should().Be(1000);
    }

    [Test]
    public void ksjdjskjdks()
    {
        var sut = new Character();
        
        new Character().DealDamageTo(sut, 1000);
        
        sut.Health.Should().Be(0);
        sut.Alive.Should().BeFalse();
    }

    [Test]
    public void ksjdkjsdjks()
    {
        new Character()
            .Alive
            .Should().BeTrue();
    }
}

public class Character
{
    
    public void DealDamageTo(Character target, int damage)
    {
        target.Health -= damage;
    }

    public int Health { get; private set; } = 1000;
    public bool Alive => Health > 0;
}