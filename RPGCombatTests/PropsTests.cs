using FluentAssertions;
using static RPGCombatTests.Prop;
using static RPGCombatTests.TestApi;

namespace RPGCombatTests;

public class PropsTests
{
    [Test]
    public void lskdlksdkls()
    {
        var sut = SomeCharacter;
        var doc = Tree;
        sut.PerformAttack(doc, 1000);
        
        doc.MaxHealth.Should().Be(1000);
    }

    [Test]
    public void ksldklasldklk()
    {
        var sut = SomeCharacter;
        var doc = Tree;
        sut.PerformAttack(doc, 2000);
        
        doc.MaxHealth.Should().Be(0);
    }

    [Test]
    public void sjkdjsjdsk()
    {
        var sut = SomeCharacter;
        var doc = Tree;
        sut.PerformAttack(doc, 3000);
        
        doc.MaxHealth.Should().Be(0);
    }

    [Test]
    public void kslkdlskdlskl()
    {
        Tree
            .Destroyed
            .Should().BeFalse();
    }

    [Test]
    public void lskdlksldsl()
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