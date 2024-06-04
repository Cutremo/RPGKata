namespace RPGCombatTests;

public class Character
{
    public int Health { get; private set; }
    public bool Alive => Health > 0;
    public bool Dead => !Alive;
    public int Level { get; private set; } = 1;
    public static Character MeleeFighter => new() { AttackRange = 2 };
    public int AttackRange { get; private init; }
    public static Character RangedFighter => new() { AttackRange = 20 };
    int MaxHealth => 1000;

    private Character()
    {
        Health = MaxHealth;
    }
    public void Heal(int healAmount)
    {
        if(Dead)
            throw new ArgumentException("Cannot heal a dead character");

        Health = Math.Min(MaxHealth, Health + healAmount);
    }

    public void GainLevels(int amount)
    {
        Level += amount;
    }

    public bool IsInAttackRange(int distance)
    {
        return AttackRange >= distance;
    }

    public void DealDamageTo(Character target, int damage, int distance = 0)
    {
        if(target == this)
            throw new ArgumentException("Cannot attack itself");

        if(!IsInAttackRange(distance))
            throw new ArgumentException("Target is out of range");

        if(this.Level - target.Level >= 5)
            damage = (int)(damage * 1.5f);

        if(target.Level - this.Level >= 5)
            damage = (int)(damage * 0.5f);

        target.Health = Math.Max(0, target.Health - damage);
    }
}