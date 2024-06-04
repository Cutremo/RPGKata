using FluentAssertions;
using static RPGCombatTests.TestApi;

namespace RPGCombatTests;

public class FactionTests
{
    [Test]
    public void jskjdsjkjdsk()
    {
        SomeCharacter
            .IsEnrolledInAnyFaction()
            .Should().BeFalse();
    }
}