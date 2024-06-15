namespace data
{



public class Item
{
    public string name;
    public int Damage;
    public int Hits;
    public bool Damaging;
    public bool MultiHit;
    public Item(int dmg, int hits,bool damaging,string n, bool mh = true)
    {
        MultiHit = mh;
        Damage = dmg;
        Hits = hits;
        Damaging = damaging;
        name = n;
    }
}

public struct Enemy
{
    
    public string Name;
    public int HP;
    public Item[]? Immunities;
    public Item[] dropsItems;
    public float[] dropChances;
    public Enemy(Item[] di, float[] dc,  string n,Item[]? I = null, int H = 0)
    {
        Immunities = I;
        HP = H;
        dropsItems = di;
        dropChances = dc;
        Name = n;
    }

    
}

public class Room
{   
    public int Ind = 0;
    public Enemy[] Enemies;
    
    
    public Room(int num, Enemy[] e)
    {
        this.Ind = num;
        Enemies = e;
    }
}

public static class Data
{
    public static List<Item> MBItems = new List<Item>{
     Items.FireBurst,
     Items.IceStorm, 
     Items.ThunderRage, 
     Items.ShootingStar, 
     Items.POWBlock,
     Items.BlockBlock,
     Items.Filler,
     Items.HotSauce,
     Items.Filler,
     Items.ShellShock,
     Items.GhostShroom,
     Items.Filler,
     Items.Filler,
     Items.Filler,
     Items.Filler,
     Items.Filler,
     Items.Filler,
     Items.CatchCard,
     Items.CatchCardSP
       };
    public static Room[] Rooms = new Room[100];

    public static class Items
    {
        public static Item FireBurst;
        public static Item ShootingStar;
        public static Item ShellShock;
        public static Item IceStorm;
        public static Item HotSauce;
        public static Item LifeShroom;
        public static Item CatchCard;
        public static Item ThunderRage;
        public static Item GhostShroom;
        public static Item BlockBlock;
        public static Item MysteryBox;
        public static Item POWBlock;
        public static Item Filler;
        public static Item CatchCardSP;
        
        static Items()
        {
            Items.BlockBlock = new Item(0,0,false,n:"Block Block");
            Items.CatchCard = new Item(0,0,true,mh:false,n:"Catch Card");
            Items.FireBurst = new Item(5,5,true,n:"Fire Burst");
            Items.GhostShroom = new Item(100000,0,true,n:"Ghost Shroom");
            Items.HotSauce = new Item(0,0,false,n:"Hot Sauce");
            Items.IceStorm = new Item(8,4,true,n:"Ice Storm");
            Items.LifeShroom = new Item(0,0,false,n:"Life Shroom");
            Items.MysteryBox = new Item(0,0,false,n:"Mystery Box");
            Items.POWBlock = new Item(15,0,true,n:"POW Block");
            Items.ShellShock = new Item(10000,0,true,n:"Shell Shock");
            Items.ShootingStar = new Item(20,5,true,n:"Shooting Star");
            Items.ThunderRage = new Item(12,1,true,n:"Thunder Rage");
            Items.Filler = new Item(0,0,false,"Filler Item");
            Items.CatchCardSP = new Item(0,0,true,mh:false,n:"Catch Card SP");

        }
    }
    static Data()
    {
        //Dont look down here youll get eye cancer
        Items.BlockBlock = new Item(0,0,false,n:"Block Block");
        Items.CatchCard = new Item(0,0,true,mh:false,n:"CatchCard");
        Items.FireBurst = new Item(5,5,true,n:"Fire Burst");
        Items.GhostShroom = new Item(100000,0,true,n:"Ghost Shroom");
        Items.HotSauce = new Item(0,0,false,n:"Hot Sauce");
        Items.IceStorm = new Item(8,4,true,n:"Ice Storm");
        Items.LifeShroom = new Item(0,0,false,n:"Life Shroom");
        Items.MysteryBox = new Item(0,0,false,n:"Mystery Box");
        Items.POWBlock = new Item(15,0,true,n:"POW Block");
        Items.ShellShock = new Item(10000,0,true,n:"Shell Shock");
        Items.ShootingStar = new Item(20,5,true,n:"Shooting Star");
        Items.ThunderRage = new Item(12,1,true,n:"Thunder Rage");





        Enemy Goomba = new Enemy(new Item[1] {Items.CatchCard},new float[1] {0.00307f},"Goomba");
        Enemy Squiglet = new Enemy(new Item[2] {Items.CatchCard,Items.FireBurst},new float[2] {0.00176470f,0.0141176470f},"Squiglet");
        Enemy Squig = new Enemy(new Item[3] {Items.CatchCard,Items.HotSauce,Items.IceStorm},new float[3] {0.001764f,0.0035294f,0.01411764f},"Squig");
        Enemy Sproing_Oing = new Enemy(new Item[1] {Items.CatchCard},new float[1] {0.002941176f},"Sproing-Oing");
        Enemy Gloomba = new Enemy(new Item[1] {Items.CatchCard},new float[1] {0.00307f},"Gloomba");
        Enemy Cherbil = new Enemy(new Item[1] {Items.CatchCard},new float[1] {0.0025f},"Cherbil");
        Enemy Boomerang_Bro = new Enemy(new Item[2] {Items.CatchCard,Items.FireBurst},new float[2] {0.00294117647058823f,0.023529411764705f},"Boomerang Bro");    
        Enemy Fire_Bro = new Enemy(new Item[2] {Items.CatchCard,Items.FireBurst},new float[2] {0.002f,0.032f}, "Fire Bro");
        Enemy Poison_Cherbil = new Enemy(new Item[1] {Items.CatchCard},new float[1] {0.02985f},"Poison Cherbil"); 
        Enemy Koopa = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.0081818f},"Koopa");
        Enemy ParaKoopa = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.0027272f}, "Paratroopa");
        Enemy ParaGoomba = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.002307692307f}, "Paragoomba");
        Enemy BaldCleft = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.0016f}, "Bald Cleft");
        Enemy MoonCleft = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.0016f}, "Moon Cleft");
        Enemy Boomboxer = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.00176470588f}, "Boomboxer");
        Enemy TileoidG = new Enemy(new Item[2]{Items.CatchCard,Items.BlockBlock},new float[2]{0.0009f,0.007272f}, "Tileoid G");
        Enemy TileoidB = new Enemy(new Item[2]{Items.CatchCard,Items.BlockBlock},new float[2]{0.0009f,0.007272f}, "Tileoid B");
        Enemy TileoidY = new Enemy(new Item[2]{Items.CatchCard,Items.BlockBlock},new float[2]{0.0012f,0.0096f}, "Tileoid Y");
        Enemy TileoidR = new Enemy(new Item[2]{Items.CatchCard,Items.BlockBlock},new float[2]{0.0012f,0.0096f}, "Tileoid R");
        Enemy KoopatrolPH = new Enemy(new Item[2]{Items.CatchCard,Items.ThunderRage},new float[2]{0.0027272f,0.0357142857142857142857f},"Koopatrol");
        Enemy HGoomba = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.00230769230769230769230769230769f}, "Headbonk Goomba");
        Enemy Ninjoe = new Enemy(new Item[2]{Items.CatchCard,Items.ThunderRage},new float[2]{0.00396226f,0.01320754716f},"Ninjoe");
        Enemy Ninjohn = new Enemy(new Item[2]{Items.CatchCard,Items.ThunderRage},new float[2]{0.004528301f,0.01509433962f},"Ninjohn");
        Enemy Ninjerry = new Enemy(new Item[2]{Items.CatchCard,Items.ThunderRage},new float[2]{0.0050943396226f,0.033962264150f},"Ninjerry");
        Enemy Skellobit = new Enemy(new Item[3]{Items.CatchCard,Items.IceStorm,Items.GhostShroom},new float[3]{0.00176470588235f,0.010588235294117647058f,0.003529411f}, "Headbonk Goomba");
        Enemy Boo = new Enemy(new Item[2]{Items.CatchCard,Items.GhostShroom},new float[2]{0.0016f,0.0128f},"Boo");
        Enemy DBoo = new Enemy(new Item[2]{Items.CatchCard,Items.GhostShroom},new float[2]{0.00121212121f,0.0193939393f},"Dark Boo");
        Enemy Squoinker = new Enemy(new Item[2]{Items.CatchCard,Items.ShootingStar},new float[2]{0.0017647058f,0.0141176470588f},"Squoinker");
        Enemy Clubba = new Enemy(new Item[2]{Items.CatchCard,Items.FireBurst},new float[2]{0.0012f,0.0192f},"Clubba");
        Enemy Longator = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.0012f},"Longator");
        Enemy Longadile = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.0012f},"Longadile");
        Enemy Fuzzy = new Enemy(new Item[2]{Items.CatchCard,Items.LifeShroom},new float[2]{0.00176470588235294f,0.014117647058823529f},"Fuzzy");
        Enemy PinkFuzzy = new Enemy(new Item[2]{Items.CatchCard,Items.LifeShroom},new float[2]{0.0003703703f,0.0148148148f},"Pink Fuzzy");
        Enemy Squog = new Enemy(new Item[3]{Items.CatchCard,Items.HotSauce,Items.ThunderRage},new float[3]{0.001764705f,0.0035294f,0.01411764705f},"Squag");
        Enemy BBeetle = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.0012f},"Buzzy Beetle");
        Enemy Boing_Oing = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.00294117647f},"Boing-Oing");
        Enemy Rawbus = new Enemy(new Item[4]{Items.CatchCard,Items.ThunderRage,Items.IceStorm,Items.FireBurst},new float[4]{0.009f,0.03f,0.03f,0.03f},"Buzzy Beetle");
        Enemy CrazeeDayzee = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.0136363f},"Crazee Dayzee");
        Enemy HammerBro = new Enemy(new Item[2]{Items.CatchCard,Items.FireBurst},new float[2]{0.002941176f,0.02352941176f},"Hammer Bro"); 
        Enemy Choppa = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.00176470588f}, "Choppa");
        Enemy Growmeba = new Enemy(new Item[0]{},new float[0]{}, "Growmeba");
        Enemy Blowmeba = new Enemy(new Item[0]{},new float[0]{}, "Blowmeba");
        Enemy Chromeba = new Enemy(new Item[0]{},new float[0]{}, "Chromeba");
        Enemy StoneBeetle = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.0012f}, "StoneBeetle");
        Enemy SpikeTopPH = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.0012f}, "Spike Top");
        Enemy Magikoopa = new Enemy(new Item[4]{Items.CatchCard,Items.ThunderRage,Items.IceStorm,Items.FireBurst},new float[4]{0.01f,0.01f,0.01f,0.01f},"Buzzy Beetle");
        Enemy KStriker = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.004545454f}, "KStriker");
        Enemy IceCherbil = new Enemy(new Item[2]{Items.CatchCard,Items.IceStorm},new float[2]{0.0025f,0.0125f},"Ice Cherbil");
        Enemy RuffPuff = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.0012f},"Ruff Puff");
        Enemy Pigarithm = new Enemy(new Item[4]{Items.CatchCard,Items.MysteryBox,Items.ShellShock,Items.ThunderRage},new float[4]{0.002f,0.008f,0.008f,0.008f},"Pigarithm"); 
        Enemy Hooligon = new Enemy(new Item[3]{Items.CatchCard,Items.HotSauce,Items.BlockBlock},new float[3]{0.002f,0.004f,0.032f},"Squag");
        Enemy ZoingOing = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.00294117647f},"Zoing-Oing");
        Enemy MagiblotR = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.032f}, "MagiblotR");
        Enemy MagiblotB = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.03f}, "MagiblotB");
        Enemy MagiblotY = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.0266666f}, "MagiblotY");
        Enemy AmazyDayzee = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.04375f},"Amazy Dayzee");
        Enemy SStriker = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.003125f},"Soopa Striker");
        Enemy Blastboxer = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.00176470588f}, "Blastboxer");
        Enemy Bleepboxer = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.00176470588f}, "Bleepboxer");
        Enemy Jawbus = new Enemy(new Item[4]{Items.CatchCard,Items.ThunderRage,Items.IceStorm,Items.FireBurst},new float[4]{0.004761f,0.015873f,0.03169f,0.047543f},"Jawbus");
        Enemy Gawbus = new Enemy(new Item[4]{Items.CatchCard,Items.ThunderRage,Items.IceStorm,Items.FireBurst},new float[4]{0.004761f,0.047543f,0.03169f,0.015873f},"Gawbus");
        Enemy Copta = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.00176470588f}, "Copta");
        Enemy SpikedGoomba = new Enemy(new Item[2]{Items.CatchCard,Items.HotSauce},new float[2]{0.00230769f,0.00461f}, "Spiked Goomba",H:1,I:new Item[0]{});
        Enemy Shlurp = new Enemy(new Item[4]{Items.CatchCard,Items.HotSauce,Items.POWBlock,Items.FireBurst},new float[4]{0.0012f,0.0024f,0.0096f,0.0096f}, "Shlurp",H:999,I:new Item[7]{Items.FireBurst,Items.ThunderRage,Items.POWBlock,Items.GhostShroom,Items.ShellShock,Items.ShootingStar,Items.IceStorm});
        Enemy Spiny = new Enemy(new Item[2]{Items.CatchCard,Items.HotSauce},new float[2]{0.0012f,0.0192f}, "Spiny",H:4,I:new Item[0]{});
        Enemy ChainChomp = new Enemy(new Item[2]{Items.CatchCard,Items.ThunderRage},new float[2]{0.003488372f,0.02325581395f}, "Chain Chomp");
        Enemy RedChomp = new Enemy(new Item[2]{Items.CatchCard,Items.POWBlock},new float[2]{0.003488372f,0.02325581395f}, "Red Chomp");
        Enemy Cursya = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.00909f}, "Cursya",H:1,I:new Item[0]{});
        Enemy Spania = new Enemy(new Item[2]{Items.CatchCard,Items.MysteryBox},new float[2]{0.0012f,0.0192f}, "Spania",H:6,I:new Item[0]{});
        Enemy Pokey = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.002727f}, "Pokey",H:6,I:new Item[0]{});
        Enemy PoisonPokey = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.04f}, "Poison Pokey",H:12,I:new Item[0]{});
        Enemy DryBones = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.0012f}, "Dry Bones",H:10,I:new Item[3]{Items.GhostShroom,Items.ShellShock,Items.POWBlock});
        Enemy DullBones = new Enemy(new Item[1]{Items.CatchCard},new float[1]{0.0012f}, "Dull Bones",H:15,I:new Item[3]{Items.GhostShroom,Items.ShellShock,Items.POWBlock});
        Enemy Hogarithm = new Enemy(new Item[5]{Items.CatchCard,Items.HotSauce,Items.GhostShroom,Items.BlockBlock,Items.ShootingStar},new float[5]{0.002f,0.008f,0.008f,0.008f,0.008f},"Hogarithm"); 
        Enemy Koopatrol = new Enemy(new Item[2]{Items.CatchCard,Items.ThunderRage},new float[2]{0.0027272f,0.0357142857142857142857f},"Koopatrol",H:15,I:new Item[0]{});
        Enemy Shlorp = new Enemy(new Item[4]{Items.CatchCard,Items.HotSauce,Items.POWBlock,Items.FireBurst},new float[4]{0.000909f,0.001818f,0.01454545f,0.00727272f}, "Shlorp",H:999,I:new Item[7]{Items.FireBurst,Items.ThunderRage,Items.POWBlock,Items.GhostShroom,Items.ShellShock,Items.ShootingStar,Items.IceStorm});
        Enemy SSkellobit = new Enemy(new Item[3]{Items.CatchCard,Items.GhostShroom,Items.POWBlock},new float[3]{0.0029411f,0.00588235f,0.01764705882f}, "Spiky Skellobit",H:15,I:new Item[1]{Items.IceStorm});
      


        Rooms[0] = new Room(1,new Enemy[4]{Squiglet,Squiglet,Squiglet,Squiglet});
        Rooms[1] = new Room(2,new Enemy[5]{Goomba,Goomba,Goomba,Goomba,Goomba});
        Rooms[2] = new Room(3,new Enemy[4]{Squiglet,Squiglet,Squig,Squig});
        Rooms[3] = new Room(4,new Enemy[4]{Sproing_Oing,Sproing_Oing,Sproing_Oing,Sproing_Oing});
        Rooms[4] = new Room(5,new Enemy[4]{Goomba,Goomba,Gloomba,Gloomba});
        Rooms[5] = new Room(6,new Enemy[3]{Cherbil,Cherbil,Cherbil});
        Rooms[6] = new Room(7,new Enemy[4]{Squig,Squig,Sproing_Oing,Sproing_Oing});
        Rooms[7] = new Room(8,new Enemy[6]{Squiglet,Squiglet,Squiglet,Squig,Squig,Squig});
        Rooms[8] = new Room(9,new Enemy[6]{Gloomba,Gloomba,Gloomba,Gloomba,Poison_Cherbil,Poison_Cherbil});
        Rooms[9] = new Room(10,new Enemy[1]{Blowmeba});
        Rooms[10] = new Room(11,new Enemy[4]{Koopa,Koopa,ParaKoopa,ParaKoopa});
        Rooms[11] = new Room(12,new Enemy[6]{ParaGoomba,ParaGoomba,ParaGoomba,ParaGoomba,SpikedGoomba,SpikedGoomba});
        Rooms[12] = new Room(13,new Enemy[7]{Shlurp,Shlurp,Shlurp,BaldCleft,BaldCleft,BaldCleft,BaldCleft});
        Rooms[13] = new Room(14,new Enemy[7]{Koopa,Koopa,Goomba,Goomba,Goomba,Goomba,Goomba});
        Rooms[14] = new Room(15,new Enemy[6]{Shlurp,Shlurp,Boomboxer,Boomboxer,Boomboxer,Boomboxer});
        Rooms[15] = new Room(16,new Enemy[7]{TileoidG,TileoidG,TileoidG,TileoidG,Koopa,Koopa,Koopa});
        Rooms[16] = new Room(17,new Enemy[4]{Koopa,Koopa,Koopa,Koopa});
        Rooms[17] = new Room(18,new Enemy[7]{Squig,Squig,Squig,BBeetle,BBeetle,BBeetle,BBeetle});
        Rooms[18] = new Room(19,new Enemy[5]{KoopatrolPH,Koopa,Koopa,Squiglet,Squiglet});
        Rooms[19] = new Room(20,new Enemy[1]{Blowmeba});
        Rooms[20] = new Room(21,new Enemy[6]{Spiny,Spiny,Spiny,Spiny,Spiny,Spiny});
        Rooms[21] = new Room(22,new Enemy[10]{Gloomba,Gloomba,Boo,Boo,Boo,Boo,Boo,Boo,Boo,Boo});
        Rooms[22] = new Room(23,new Enemy[7]{Cherbil,Cherbil,Cherbil,Fuzzy,Fuzzy,Fuzzy,Fuzzy});
        Rooms[23] = new Room(24,new Enemy[5]{Boing_Oing,Boing_Oing,Boing_Oing,Sproing_Oing,Sproing_Oing});
        Rooms[24] = new Room(25,new Enemy[1]{ChainChomp});
        Rooms[25] = new Room(26,new Enemy[7]{ParaGoomba,ParaGoomba,ParaGoomba,ParaGoomba,CrazeeDayzee,CrazeeDayzee,CrazeeDayzee});
        Rooms[26] = new Room(27,new Enemy[10]{Squiglet,Squiglet,Squiglet,Squiglet,Squiglet,Squiglet,Squiglet,Squiglet,Squiglet,Squiglet});
        Rooms[27] = new Room(28,new Enemy[6]{HammerBro,HammerBro,Koopa,Koopa,Koopa,Koopa});
        Rooms[28] = new Room(29,new Enemy[2]{Rawbus,Rawbus});
        Rooms[29] = new Room(30,new Enemy[1]{Blowmeba});
        Rooms[30] = new Room(31,new Enemy[8]{TileoidG,TileoidG,TileoidG,TileoidG,TileoidB,TileoidB,TileoidB,TileoidB});
        Rooms[31] = new Room(32,new Enemy[8]{Longator,Longator,Longator,Longator,Longator,Longator,Longator,Longator});
        Rooms[32] = new Room(33,new Enemy[5]{Squig,Squig,Growmeba,Cursya,Cursya});
        Rooms[33] = new Room(34,new Enemy[9]{BaldCleft,BaldCleft,BaldCleft,BaldCleft,BaldCleft,StoneBeetle,StoneBeetle,StoneBeetle,StoneBeetle});
        Rooms[34] = new Room(35,new Enemy[9]{Squig,Squig,Squig,Squig,Choppa,Choppa,Choppa,Choppa,Choppa});
        Rooms[35] = new Room(36,new Enemy[6]{Ninjoe,Ninjoe,Ninjoe,Ninjoe,Ninjoe,Ninjoe});
        Rooms[36] = new Room(37,new Enemy[8]{Squig,Squig,Squig,Squig,BBeetle,BBeetle,SpikeTopPH,SpikeTopPH});
        Rooms[37] = new Room(38,new Enemy[8]{Magikoopa,Magikoopa,Magikoopa,Magikoopa,SpikedGoomba,SpikedGoomba,SpikedGoomba,SpikedGoomba});
        Rooms[38] = new Room(39,new Enemy[6]{TileoidG,TileoidG,TileoidG,TileoidG,Fire_Bro,Fire_Bro});
        Rooms[39] = new Room(40,new Enemy[1]{Blowmeba});
        Rooms[40] = new Room(41,new Enemy[10]{Squiglet,Squiglet,Squiglet,Squiglet,Clubba,Clubba,Clubba,Clubba,Clubba,Clubba});
        Rooms[41] = new Room(42,new Enemy[8]{Pokey,Pokey,Pokey,Pokey,Gloomba,Gloomba,Gloomba,Gloomba});
        Rooms[42] = new Room(43,new Enemy[4]{KStriker,KStriker,KStriker,KStriker});
        Rooms[43] = new Room(44,new Enemy[9]{Cursya,Squog,Squog,Squog,Squog,Squig,Squig,Squig,Squig});
        Rooms[44] = new Room(45,new Enemy[8]{TileoidR,TileoidR,TileoidR,TileoidR,TileoidB,TileoidB,TileoidB,TileoidB});
        Rooms[45] = new Room(46,new Enemy[9]{ParaKoopa,ParaKoopa,ParaKoopa,ParaKoopa,Goomba,Goomba,Goomba,Goomba,Goomba});
        Rooms[46] = new Room(47,new Enemy[6]{Poison_Cherbil,Poison_Cherbil,IceCherbil,IceCherbil,Cherbil,Cherbil});
        Rooms[47] = new Room(48,new Enemy[8]{Magikoopa,Magikoopa,Magikoopa,Magikoopa,Clubba,Clubba,Clubba,Clubba});
        Rooms[48] = new Room(49,new Enemy[10]{Squog,Squog,Squog,Squog,Squog,Squog,Squog,Squog,Squog,Squog});
        Rooms[49] = new Room(50,new Enemy[1]{Blowmeba});
        Rooms[50] = new Room(51,new Enemy[8]{BBeetle,BBeetle,Spiny,Spiny,Spiny,Spiny,Spiny,Spiny});
        Rooms[51] = new Room(52,new Enemy[4]{Pigarithm,Pigarithm,Pigarithm,Pigarithm});
        Rooms[52] = new Room(53,new Enemy[9]{TileoidB,TileoidB,TileoidB,TileoidB,Spania,Spania,Spania,Spania,Spania});
        Rooms[53] = new Room(54,new Enemy[8]{DryBones,DryBones,DryBones,DryBones,Clubba,Clubba,Clubba,Clubba});
        Rooms[54] = new Room(55,new Enemy[3]{Hooligon,Hooligon,Hooligon});
        Rooms[55] = new Room(56,new Enemy[5]{DBoo,DBoo,DBoo,DBoo,Cursya});
        Rooms[56] = new Room(57,new Enemy[6]{IceCherbil,IceCherbil,IceCherbil,ZoingOing,ZoingOing,ZoingOing});
        Rooms[57] = new Room(58,new Enemy[9]{AmazyDayzee,CrazeeDayzee,CrazeeDayzee,CrazeeDayzee,CrazeeDayzee,CrazeeDayzee,CrazeeDayzee,CrazeeDayzee,CrazeeDayzee});
        Rooms[58] = new Room(59,new Enemy[7]{Squig,Squig,Squig,Squig,MagiblotY,MagiblotY,MagiblotY});
        Rooms[59] = new Room(60,new Enemy[1]{Blowmeba});
        Rooms[60] = new Room(61,new Enemy[7]{Cursya,Cursya,Bleepboxer,Bleepboxer,Bleepboxer,Bleepboxer,Bleepboxer});
        Rooms[61] = new Room(62,new Enemy[8]{DullBones,DullBones,DullBones,DullBones,DBoo,DBoo,DBoo,DBoo});
        Rooms[62] = new Room(63,new Enemy[7]{Boomerang_Bro,Boomerang_Bro,Boomerang_Bro,Clubba,Clubba,Clubba,Clubba});
        Rooms[63] = new Room(64,new Enemy[8]{TileoidR,TileoidR,TileoidR,TileoidR,TileoidY,TileoidY,TileoidY,TileoidY});
        Rooms[64] = new Room(65,new Enemy[2]{Growmeba,Blowmeba});
        Rooms[65] = new Room(66,new Enemy[7]{Ninjoe,Ninjoe,Ninjoe,Skellobit,Skellobit,Skellobit,Skellobit});
        Rooms[66] = new Room(67,new Enemy[10]{Longator,Longator,Longator,Longator,Longadile,Longadile,Longadile,Longadile,Longadile,Longadile});
        Rooms[67] = new Room(68,new Enemy[9]{HammerBro,HammerBro,Squoinker,Squoinker,Squoinker,Squog,Squog,Squog,Squog});
        Rooms[68] = new Room(69,new Enemy[7]{SStriker,SStriker,SStriker,SStriker,SStriker,SStriker,SStriker});
        Rooms[69] = new Room(70,new Enemy[1]{Blowmeba});
        Rooms[70] = new Room(71,new Enemy[9]{BaldCleft,BaldCleft,BaldCleft,BaldCleft,MoonCleft,MoonCleft,MoonCleft,MoonCleft,MoonCleft});
        Rooms[71] = new Room(72,new Enemy[2]{Jawbus,Jawbus});
        Rooms[72] = new Room(73,new Enemy[8]{Cursya,Cursya,Cursya,Cursya,Cursya,Cursya,Cursya,Cursya});
        Rooms[73] = new Room(74,new Enemy[6]{Copta,Copta,Copta,Copta,Copta,Copta});
        Rooms[74] = new Room(75,new Enemy[10]{RuffPuff,RuffPuff,RuffPuff,RuffPuff,RuffPuff,RuffPuff,RuffPuff,RuffPuff,RuffPuff,RuffPuff});
        Rooms[75] = new Room(76,new Enemy[9]{Blastboxer,Blastboxer,Blastboxer,Bleepboxer,Bleepboxer,Bleepboxer,Boomboxer,Boomboxer,Boomboxer});
        Rooms[76] = new Room(77,new Enemy[7]{Squog,Squog,Squog,MagiblotB,MagiblotB,MagiblotB,MagiblotB});
        Rooms[77] = new Room(78,new Enemy[2]{Chromeba,Blowmeba});
        Rooms[78] = new Room(79,new Enemy[7]{SSkellobit,SSkellobit,Skellobit,Skellobit,Skellobit,Skellobit,Skellobit});
        Rooms[79] = new Room(80,new Enemy[1]{Blowmeba});
        Rooms[80] = new Room(81,new Enemy[7]{Hogarithm,Hogarithm,Hogarithm,TileoidY,TileoidY,TileoidY,TileoidY});
        Rooms[81] = new Room(82,new Enemy[7]{Squoinker,Squoinker,MagiblotR,MagiblotR,MagiblotR,MagiblotR,MagiblotR});
        Rooms[82] = new Room(83,new Enemy[8]{Cherbil,Cherbil,Cherbil,PinkFuzzy,PinkFuzzy,PinkFuzzy,PinkFuzzy,PinkFuzzy});
        Rooms[83] = new Room(84,new Enemy[7]{Shlorp,Shlorp,Shlorp,Spania,Spania,Spania,Spania});
        Rooms[84] = new Room(85,new Enemy[10]{DBoo,DBoo,DBoo,DBoo,DBoo,DBoo,PoisonPokey,PoisonPokey,PoisonPokey,PoisonPokey});
        Rooms[85] = new Room(86,new Enemy[9]{Magikoopa,Magikoopa,Magikoopa,Magikoopa,Koopatrol,Koopatrol,Koopatrol,Koopatrol,Koopatrol});
        Rooms[86] = new Room(87,new Enemy[7]{Chromeba,Copta,Copta,Copta,Copta,Cursya,Cursya});
        Rooms[87] = new Room(88,new Enemy[7]{Ninjohn,Ninjohn,Ninjohn,Ninjoe,Ninjoe,Ninjoe,Ninjoe});
        Rooms[88] = new Room(89,new Enemy[29]{HGoomba,HGoomba,HGoomba,HGoomba,HGoomba,HGoomba,HGoomba,HGoomba,HGoomba,HGoomba,HGoomba,HGoomba,HGoomba,HGoomba,HGoomba,HGoomba,HGoomba,HGoomba,HGoomba,HGoomba,HGoomba,HGoomba,HGoomba,HGoomba,HGoomba,HGoomba,HGoomba,HGoomba,HGoomba});
        Rooms[89] = new Room(90,new Enemy[1]{Blowmeba});
        Rooms[90] = new Room(91,new Enemy[2]{Gawbus,Gawbus});
        Rooms[91] = new Room(92,new Enemy[7]{Ninjerry,Ninjohn,Ninjohn,Ninjohn,Ninjoe,Ninjoe,Ninjoe});
        Rooms[92] = new Room(93,new Enemy[10]{Ninjerry,Ninjerry,Ninjerry,Skellobit,Cursya,Cursya,Skellobit,Skellobit,Skellobit,Skellobit});
        Rooms[93] = new Room(94,new Enemy[7]{Fire_Bro,Fire_Bro,Fire_Bro,Fire_Bro,Squoinker,Squoinker,Squoinker});
        Rooms[94] = new Room(95,new Enemy[13]{Skellobit,Skellobit,Skellobit,Skellobit,Skellobit,Skellobit,Skellobit,Skellobit,Skellobit,SSkellobit,SSkellobit,SSkellobit,SSkellobit});
        Rooms[95] = new Room(96,new Enemy[4]{Boomerang_Bro,Boomerang_Bro,Fire_Bro,Fire_Bro});
        Rooms[96] = new Room(97,new Enemy[1]{Squiglet});
        Rooms[97] = new Room(98,new Enemy[4]{RedChomp,RedChomp,RedChomp,RedChomp});
        Rooms[98] = new Room(99,new Enemy[9]{MagiblotY,MagiblotY,MagiblotY,MagiblotB,MagiblotB,MagiblotB,MagiblotR,MagiblotR,MagiblotR});
        Rooms[99] = new Room(100,new Enemy[0]{});



       

    }
}
}