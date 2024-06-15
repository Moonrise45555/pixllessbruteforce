using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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

    public static Item MysteryBoxCalc()
    {
        List<Item> RArray = new List<Item>{};
        for (int i = 0; i < Data.MBItems.Count; i++)
        {
            for (int j = 0; j < Data.MBWeights[i]; j++)
            {
                RArray.Add(Data.MBItems[i]);
            }
        }

        for (int i = 0; i < 100; i++)
        {
            int swapone = r.Next(RArray.Count);
            int swaptwo = r.Next(RArray.Count);
            while (swapone == swaptwo)
            {
                swaptwo = r.Next(RArray.Count);
                
            }
            
            Item temp = RArray[swapone];
            RArray[swapone] = RArray[swaptwo];
            RArray[swaptwo] = temp;
        }
            return RArray[r.Next(20)];
        

    
    }
    public static List<Item> FlimmSale()
    {
        List<Item> RArray = new List<Item>{};
        for (int i = 0; i < Data.FlimmItems.Count; i++)
        {
            RArray.Add(Data.FlimmItems[i]);
            
        }
        for (int i = 0; i < 100; i++)
        {
            int swapone = r.Next(RArray.Count);
            int swaptwo = r.Next(RArray.Count);
            while (swapone == swaptwo)
            {
                swaptwo = r.Next(RArray.Count);
                
            }
        }
        return new List<Item>{RArray[0],RArray[2],RArray[3],RArray[4],RArray[5],RArray[6],RArray[7],RArray[1]};

    }
   
}
}