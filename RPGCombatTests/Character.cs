namespace RPGCombatTests;

public class Character
{
    int health;
    public int Health
    {
        get => health;
        private set => health = Math.Clamp(value, 0, MaxHealth);
    }

    public bool Alive => Health > 0;
    public bool Dead => !Alive;
    public int Level { get; private set; } = 1;
    public static Character MeleeFighter => new() { AttackRange = 2 };
    public Meters AttackRange { get; private init; }
    public static Character RangedFighter => new() { AttackRange = 20 };
    int MaxHealth => 1000;

    Character()
    {
        Health = MaxHealth;
    }
    public void Heal(int healAmount)
    {
        if(Dead)
            throw new ArgumentException("Cannot heal a dead character");

        Health += healAmount;
    }

    public void GainLevels(int amount)
    {
        Level += amount;
    }

    public bool IsInAttackRange(Meters distance)
    {
        return AttackRange >= distance;
    }

    public void DealDamageTo(Character target, int damage, Meters distance = default)
    {
        if(target == this)
            throw new ArgumentException("Cannot attack itself");

        if(!IsInAttackRange(distance))
            throw new ArgumentException("Target is out of range");

        if(this.Level - target.Level >= 5)
            damage = (int)(damage * 1.5f);

        if(target.Level - this.Level >= 5)
            damage = (int)(damage * 0.5f);

        target.Health -= damage;
    }

    public bool IsEnrolledInAnyFaction()
    {
        return false;
    }
}