using data;
namespace RandomNumberGenerator

{
public static class RNG
{
    public static Random r;
    public static bool DropChance(float chance)
    {
        return r.NextDouble() < chance;
    }
    static RNG()
    {
        r = new Random();
    }
   
}
}