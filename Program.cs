using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Xml.XPath;
using RandomNumberGenerator;
using data;









public static class Simulation
{
    public static bool DEBUG = false;
    public static Item? DropSimu(Enemy e)
    {
        List<Item> ItemsEnemy = new List<Item>();
        for (int d = 0; d < e.dropChances.Length; d++)
        {

        
            if (RNG.DropChance(e.dropChances[d]))
            {
                //adds all of the items dropped by the enemy to a list, in the rare case multiple items would be dropped
                ItemsEnemy.Add(e.dropsItems[d]);
            }
        }
        //this is technically kind of unfair? but i dont really know how to fix it without completely butchering the system i made this far
        if (ItemsEnemy.Count != 0)
        {
            Item dropped = ItemsEnemy[RNG.r.Next(0,ItemsEnemy.Count)];

            return dropped;
        }
        return null;
    }

    public static Enemy[] UseItem(Item item, Enemy[] Enemies, int Target)
    {
        if(DEBUG)
        Console.WriteLine($"Used item {item.name} on {Enemies[Target].Name}");

        
        if (!item.Damaging)
        {
            if(item.name == "Block Block")
            {
                return Enemies;
            }   
            throw new Exception();
        }
        
        //takes an item, a group of enemies, and a target enemy, and uses the item. DOES NOT kill enemies under 1 HP, just returns them.
        if (!item.MultiHit)
        {
            if(RNG.r.Next(0,2) == 0 && item.name == "Catch Card SP")
            {
                
                Enemies[Target].HP = 0;
            }
            
            Enemies[Target].HP = Enemies[Target].HP - item.Damage;
            return Enemies;
        }
        else
        {
            if (item.name == "Mystery Box")
            {
                return UseItem(RNG.MysteryBoxCalc(),Enemies, Target);
            }
            else 
            {
                for (int i = 0; i < Enemies.Length; i++)
                {
                
                    if(!Enemies[i].Immunities.Contains(item))
                    {
                        Enemies[i].HP -= item.Damage;
                    }
                }

            }
               
            return Enemies;
        }

    }
    
    public static List<Item>? FullSimu(int Type = 0, bool IgnoreImmunities = false, List<Item>? StartingItems = null,int StartingRoom=1,bool SmartDescisions=false)
    {
        StartingItems ??= new List<Item>();
        /* Simulates a full pixlless pit run and returns the Items owned into room 100. Type 0 is always killing every enemy possible without items, Type 1 is only killing until you reach the key.*/
        List<Item> OwnedItems = StartingItems;
        int RoomNum = StartingRoom;
        while (RoomNum != 99)
        {
            if((RoomNum + 1) % 10 == 0 && RNG.r.Next(10) < 4)
            {
                int counter = 0;
                foreach (Item i in RNG.FlimmSale())
                {
                    if(i != Data.Items.Filler && counter != 2)
                    {
                        if (DEBUG) Console.WriteLine($"{i.name} bought from flimm in {RoomNum}");
                        OwnedItems.Add(i);
                        counter++;
                    }
                }
            }
            while(OwnedItems.Count > 10)
            {
                OwnedItems.RemoveAt(RNG.r.Next(OwnedItems.Count));
            }
            
            //determines the KeyEnemy
            List<Enemy> Enemies = Data.Rooms[RoomNum].Enemies.ToList();
            int KeyEnemy = RNG.r.Next(0,Enemies.Count);
            List<bool> KeyBits = new List<bool>();
            foreach (Enemy e in Enemies)
            {
                KeyBits.Add(false);
            }
            
            KeyBits[KeyEnemy] = true;
            //keyBits is an array of bools, where the enemy with the key will return True
            
            //iterate through every enemy to kill the ones that can be killed easily
            int Iterations = Enemies.Count;
            int ind = 0;
            for (int j = 0; j < Iterations; j++)
            {
                
                //immunity null means that it can be killed without items
                if (Enemies[ind].Immunities == null || IgnoreImmunities)
                {
                    if (KeyBits[ind])
                    {
                        if (Type == 1)
                        {
                        //if type 1, we have found the key, so abort everything immediatly and head to the next room
                            Enemies.RemoveAt(ind);
                            KeyBits.RemoveAt(ind);
                            break;
                        }
                        //if its not type 1, just remove the key enemy from the list of enemies
                        Enemies.RemoveAt(ind);
                        KeyBits.RemoveAt(ind);
                        continue;
                    }
                     //if it doesnt have they key, run the item drop algorithms
                    Item? d = DropSimu(Enemies[ind]);
                    
                    if (d != null)
                    {
                        if(DEBUG)
                        Console.WriteLine($"dropped {d.name} in room {RoomNum}");
                        OwnedItems.Add((Item)d);
                    }
                    Enemies.RemoveAt(ind);
                    KeyBits.RemoveAt(ind);
                }
                else
                {
                    ind++;
                }
            }
            if (!KeyBits.Contains(true))
            {
                //stops if we have the key
                RoomNum++;
                continue;
            }
            //continue using items until we have the key
            while(KeyBits.Contains(true))
            {
                Item Proposal;
                int Timer = 0;
                do
                {
                    Timer++;
                    if(Timer > 500)
                    {
                        return null;
                    }
                    if(OwnedItems.Count == 0)
                    {
                        if(DEBUG)
                        Console.WriteLine($"Softlocked vs {Enemies[0].Name} in {RoomNum}!");
                        if (DEBUG)
                        Console.WriteLine("------------------------------------------------------------");
                        //softlock if we have no items
                        return null;
                    }

                    bool hasDamaging = false;
                    foreach(Item it in OwnedItems)
                    {
                        if (it.Damaging)
                        {
                            hasDamaging = true;
                        }
                    }
                    if (hasDamaging == false)
                    {
                         if(DEBUG)
                        Console.WriteLine($"Softlocked vs {Enemies[0].Name} in {RoomNum}!");
                        if (DEBUG)
                        Console.WriteLine("------------------------------------------------------------");

                        return null;
                    }
                    
                    Proposal = OwnedItems[RNG.r.Next(0,OwnedItems.Count)];
                    if (SmartDescisions)
                        Descision(RoomNum,OwnedItems);
                } 
                while(!Proposal.Damaging || Enemies[RNG.r.Next(0,Enemies.Count)].Immunities.Contains(Proposal));
                //we now have a usable item
                OwnedItems.Remove(Proposal);
                //use the item we have chosen
                int l = RNG.r.Next(0,Enemies.Count);
                Enemies = UseItem(Proposal,Enemies.ToArray(),l).ToList<Enemy>();
                for (int i = 0; i < Enemies.Count; i = i + 1 - 1)
                {
                    //loop through every enemy to check if theyre dead, then run the standard death procedure
                    if (Enemies[i].HP <= 0)
                    {
                        if(DEBUG)
                        Console.WriteLine($"Mortal Damage dealt to {Enemies[i].Name}");
                        if(!KeyBits[i])
                        {
                            Item? d = DropSimu(Enemies[i]);
                    
                            if (d != null)
                            {
                                if(DEBUG)
                                Console.WriteLine($"dropped {d.name} in room {RoomNum}");
                                OwnedItems.Add((Item)d);
                            }

                        }
                        Enemies.RemoveAt(i);
                        KeyBits.RemoveAt(i);
                        continue;
                    }
                    i++;
                }


            }
            

            //
               

            
            RoomNum++;
            
        }
        if(DEBUG)
        Console.WriteLine("---------------------------------------");
        return OwnedItems;
        
        
    }

    public static int Descision(int RoomNum,List<Item> items)
    {
        float[] CurrentChances = RouteTest(items,false,10000,RoomNum);
        List<float[]> ModifiedChances = new List<float[]>();
        for (int i = 0; i < items.Count; i++)
        {
            Item buffer = items[i];
            items.RemoveAt(i);
            ModifiedChances.Add(RouteTest(items,false,5000,RoomNum + 1));
            items.Insert(i,buffer);

            
        }
        int MinChanceInd = 0;
        for (int i = 0; i < ModifiedChances.Count; i++)
        {
            if (CurrentChances[2] - ModifiedChances[i][2] < ModifiedChances[MinChanceInd][2])
            {
                MinChanceInd = i;

            }
            
        }
       
        return MinChanceInd;


    }

    public static  float[] RouteTest(List<Item> Route, bool SmartChoices=false,int simulations = 10000,int RoomNum=0)
    {
        float TotalSimus = 0;
        float ToRoom100 = 0;
        float SixHits = 0;
        float SixHitsLSJBB = 0;
        float TwoHits = 0;
        float TwoHitsLSJBB = 0;
        while (TotalSimus != simulations)
        {
            List<Item> RouteCopy = new List<Item>();
            foreach (Item i in Route)
            {
                RouteCopy.Add(i);
                
            }
            TotalSimus++;
            List<Item> result = Simulation.FullSimu(1,StartingItems:RouteCopy,StartingRoom:RoomNum,SmartDescisions:SmartChoices);
           
        
            if(result != null)
            {

            for (int i = 0; i < result.Count; i++)
            {
                if (result[i] == Data.Items.MysteryBox)
                {
                    result[i] = RNG.MysteryBoxCalc();
                }
            }
                
            

            ToRoom100++;
            int sumHits = 0;
            foreach(Item i in result)
            {
                sumHits += i.Hits;
                
            }
            if(sumHits >= 10)
            {
                TwoHits++;
                TwoHitsLSJBB++;
            }
            else
            {
                if(result.Contains(Data.Items.BlockBlock) || result.Contains(Data.Items.LifeShroom))
                {
                    TwoHitsLSJBB++;
                }
            }
            if(sumHits >= 30)
            {
                //THIS IS NOT ACCURATE FOR EDGE CASES WITH ICE STORMS
                //FIX SOON PLS
                SixHits++;
                SixHitsLSJBB++;

            }
            else
            {
                foreach (Item i in result)
                {
                    if(i == Data.Items.BlockBlock || i == Data.Items.LifeShroom)
                    {
                        sumHits += 10;
                    }

                    
                }
                if(sumHits >= 30)
                {
                    //THIS IS NOT ACCURATE FOR EDGE CASES WITH ICE STORMS
                    //FIX SOON PLS
                   
                    SixHitsLSJBB++;

                }
            }
            }
           
      
        }
        return new float[6]{TotalSimus,ToRoom100,TwoHits,TwoHitsLSJBB,SixHits,SixHitsLSJBB};
    }
    
}
public static class Program
{
    
    static void Main()
    {
        

        List<int> values = new List<int>();
        List<Item> SeaSpongesRoute = new List<Item>{Data.Items.ShellShock,Data.Items.FireBurst,Data.Items.FireBurst,Data.Items.CatchCard,Data.Items.CatchCard,Data.Items.CatchCard,Data.Items.ShootingStar,Data.Items.ShootingStar,Data.Items.ShootingStar,Data.Items.ShootingStar};
        List<Item> MohocRouteOne = new List<Item>{Data.Items.FireBurst,Data.Items.ShellShock};
        List<Item> MohocRouteTwo = new List<Item>{Data.Items.FireBurst,Data.Items.FireBurst,Data.Items.FireBurst, Data.Items.FireBurst,Data.Items.ShellShock,Data.Items.ShellShock,Data.Items.ShellShock,Data.Items.ShellShock,Data.Items.ShellShock,Data.Items.POWBlock};
        List<Item> SSS = new List<Item>{Data.Items.MysteryBox,Data.Items.MysteryBox,Data.Items.MysteryBox,Data.Items.MysteryBox,Data.Items.MysteryBox,Data.Items.MysteryBox,Data.Items.MysteryBox,Data.Items.MysteryBox,Data.Items.MysteryBox,Data.Items.MysteryBox};
       
        List<Item> randomRoute()
        {
            List<Item> ItemPool = new List<Item>{Data.Items.FireBurst,Data.Items.LifeShroom,Data.Items.POWBlock,Data.Items.ShellShock,Data.Items.IceStorm};
            return new List<Item>{ItemPool[RNG.r.Next(0,5)],ItemPool[RNG.r.Next(0,5)],ItemPool[RNG.r.Next(0,5)],ItemPool[RNG.r.Next(0,5)],ItemPool[RNG.r.Next(0,5)],ItemPool[RNG.r.Next(0,5)],ItemPool[RNG.r.Next(0,5)],ItemPool[RNG.r.Next(0,5)],ItemPool[RNG.r.Next(0,5)],ItemPool[RNG.r.Next(0,5)]};


        }
        float TotalSimus = 0;
        float ToRoom100 = 0;
        float SixHits = 0;
        float SixHitsLSJBB = 0;
        float TwoHits = 0;
        float TwoHitsLSJBB = 0;
        float maxChance = -1;
        while (true){
            List<Item> Route = new List<Item>{};
            Route = SSS;
            
            float[] result = Simulation.RouteTest(Route,simulations:500000,SmartChoices:false);
             TotalSimus += result[0];
             ToRoom100 += result[1];
             SixHits += result[4];
             SixHitsLSJBB += result[5];
             TwoHits += result[2];
             TwoHitsLSJBB += result[3];

            if (-1==-1)
            {
        
                string RouteString = "route : ";
                foreach (Item i in Route)
                {
                    RouteString = RouteString + i.name + " ";
            

            
                }
                Console.WriteLine("-----");
                Console.WriteLine(RouteString);
      
            
                Console.WriteLine($"simulations:         {TotalSimus}");
                
                Console.WriteLine($"getting to room 100: {(100 * (ToRoom100/TotalSimus)).ToString("N10")}%");

                Console.WriteLine($"without any buffs:   {(100 * (SixHits/TotalSimus)).ToString("N10")}%");

                Console.WriteLine($"Six hits with ls/BB: {(100 * (SixHitsLSJBB/TotalSimus)).ToString("N10")}%");
                Console.WriteLine($"two hits :           {(100 * (TwoHits/TotalSimus)).ToString("N10")}%");
                Console.WriteLine($"two hits with ls/BB: {(100 * (TwoHitsLSJBB/TotalSimus)).ToString("N10")}%");
                maxChance = TwoHits / TotalSimus;
            }
        }
      
        



        
         

    }

    
}