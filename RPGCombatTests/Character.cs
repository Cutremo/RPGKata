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
    public int Level { get; private set; } = 1;

    public void Heal(int healAmount)
    {
        if (Dead)
            throw new ArgumentException("Cannot heal a dead character");
        
        Health = Math.Min(1000, Health + healAmount);
    }

    public void GainLevels(int amount)
    {
        Level += amount;
    }
}
