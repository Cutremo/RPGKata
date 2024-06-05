using FluentAssertions;
using static RPGCombatTests.TestApi;

namespace RPGCombatTests;

public class PropsTests
{
    [Test]
    public void lskdlksdkls()
    {
        var sut = SomeCharacter;
        var doc = Prop.Tree;
        sut.PerformAttack(doc, 1000);
        
        doc.Health.Should().Be(1000);
    }

    [Test]
    public void ksldklasldklk()
    {
        var sut = SomeCharacter;
        var doc = Prop.Tree;
        sut.PerformAttack(doc, 2000);
        
        doc.Health.Should().Be(0);
    }

    [Test]
    public void sjkdjsjdsk()
    {
        var sut = SomeCharacter;
        var doc = Prop.Tree;
        sut.PerformAttack(doc, 3000);
        
        doc.Health.Should().Be(0);
    }
}

public class Prop
{

    Prop(int health)
    {
        Health = health;
    }

    public static Prop Tree => new(2000);
    public int Health { get; private set; }
    
    public void TakeDamage(int amount)
    {
        Health = Math.Max(0, Health - amount);
    }
}