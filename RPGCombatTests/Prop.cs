namespace RPGCombatTests;

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