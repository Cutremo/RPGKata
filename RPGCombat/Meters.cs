namespace RPGCombat;

public struct Meters
{
    readonly int value = 0;
    public Meters(int value) => this.value = value;
    
    public static Meters None => new(0);
    public static implicit operator int(Meters meters) => meters.value;
    public static implicit operator Meters(int meters) => new(meters);
}