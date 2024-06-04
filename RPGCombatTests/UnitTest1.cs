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
}

public class Character
{
    
    public void DealDamageTo(Character target, int damage)
    {
        target.Health -= damage;
    }

    public int Health { get; private set; } = 1000;
}