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
}

public class Prop
{
    Prop(int health)
    {
    }

    public static Prop Tree => new(2000);
    public int Health => 1000;
}