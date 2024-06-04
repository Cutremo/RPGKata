namespace RPGCombatTests;

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