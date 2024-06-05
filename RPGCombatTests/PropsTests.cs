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