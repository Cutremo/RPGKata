namespace RPGCombat;

public class Character
{
    int health;
    readonly IList<Faction> factions = new List<Faction>();

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

    bool CanPerformHeal(Character target, int healAmount) => CanPerformActionTo(target) && IsAlliedTo(target);
    public void Heal(Character target, int healAmount)
    {
        if(!CanPerformHeal(target, healAmount))
            throw new ArgumentException("Invalid heal cast");

        target.Health += healAmount;
    }

    public void GainLevels(int amount)
    {
        if(amount < 0)
            throw new ArgumentException("Levels is negative");
        Level += amount;
    }

    public bool IsInAttackRange(Meters distance)
    {
        return AttackRange >= distance;
    }

    bool CanPerformActionTo(Character target) => this.Alive && target.Alive;
    bool CanPerformActionTo(Prop target) => this.Alive && !target.Destroyed;
    bool IsValidAttack(Character target, int damage, Meters distance) => CanPerformActionTo(target) && IsInAttackRange(distance) && IsEnemyOf(target) && damage > 0;
    bool IsValidAttack(Prop target, int damage, Meters distance) => CanPerformActionTo(target) && IsInAttackRange(distance) && damage > 0;

    public void PerformAttack(Character target, int damage, Meters distance = default)
    {
        if(!IsValidAttack(target, damage, distance))
            throw new InvalidOperationException("Invalid attack");

        if(this.Level - target.Level >= 5)
            damage = (int)(damage * 1.5f);

        if(target.Level - this.Level >= 5)
            damage = (int)(damage * 0.5f);

        target.Health -= damage;
    }
    
    public void PerformAttack(Prop target, int damage, Meters distance = default)
    {
        if (!IsValidAttack(target, damage, distance))
            throw new InvalidOperationException("Invalid attack");
        
        target.TakeDamage(damage);
    }

    public bool HasAllegianceToAnyFaction() => factions.Any();

    public void EnrollInFaction(Faction faction)
    {
        if(faction.Equals(Faction.None))
            throw new ArgumentException("Cannot enroll in Null faction");

        factions.Add(faction);
    }

    public bool HasAllegianceTo(Faction faction)
    {
        if(faction.Equals(Faction.None))
            throw new ArgumentException("Cannot compare to Null faction");

        return factions.Contains(faction);
    }

    public bool IsAlliedTo(Character other)
    {
        return other == this || factions.Any(other.HasAllegianceTo);
    }

    public bool IsEnemyOf(Character other) => !IsAlliedTo(other);
}