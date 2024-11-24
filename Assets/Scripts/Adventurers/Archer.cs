internal class Archer : Adventurer
{
    public override int MaxHealthPoints => 7;
    public override string Image => "archer";

    public override Dice Dice => new(new Face[]
    { 
        new ArcherBlue1(this),
        new ArcherBlue2(this),
        new ArcherBlue3(this),
        new ArcherViolet1(this),
        new ArcherViolet2(this),
        new ArcherGold1(this),
    });

    
}