using FluentAssertions;
namespace RPGCombatTests;

public class Tests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void skajdkjskj()
    {
        var sut = new Character();
        var doc = new Character();

        sut.DealDamageTo(doc, 100);
        
        doc.Health.Should().Be(900);
    }
}

public class Character
{
    public void DealDamageTo(Character target, int amount)
    {
    }

    public int Health => 900;
}