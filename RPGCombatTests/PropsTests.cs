using FluentAssertions;
using static RPGCombatTests.Prop;
using static RPGCombatTests.TestApi;

namespace RPGCombatTests;

public class PropsTests
{
    [Test]
    public void DealSomeDamageToProps()
    {
        var sut = SomeCharacter;
        var doc = Tree;
        sut.PerformAttack(doc, 1000);
        
        doc.MaxHealth.Should().Be(1000);
    }

    [Test]
    public void DealMoreDamageToProps()
    {
        var sut = SomeCharacter;
        var doc = Tree;
        sut.PerformAttack(doc, 2000);
        
        doc.MaxHealth.Should().Be(0);
    }

    [Test]
    public void PropsHealthFloorsToZero()
    {
        var sut = SomeCharacter;
        var doc = Tree;
        sut.PerformAttack(doc, 3000);
        
        doc.MaxHealth.Should().Be(0);
    }

    [Test]
    public void PropsAreNotDestroyedByDefault()
    {
        Tree
            .Destroyed
            .Should().BeFalse();
    }

    [Test]
    public void DestroyProps()
    {
        var sut = SomeCharacter;
        var doc = Tree;
        
        sut.PerformAttack(doc, 3000);
        
        doc.Destroyed.Should().BeTrue();
    }
}

public class Prop
{

    Prop(int maxHealth)
    {
        if(maxHealth <= 0)
            throw new ArgumentOutOfRangeException(nameof(maxHealth),
                "maxHealth must be greater than or equal to zero.");
        MaxHealth = maxHealth;
    }

    public static Prop Tree => new(2000);
    public int MaxHealth { get; private set; }
    public bool Destroyed => MaxHealth == 0;

    public void TakeDamage(int amount)
    {
        MaxHealth = Math.Max(0, MaxHealth - amount);
    }
}