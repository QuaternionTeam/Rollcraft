internal class Mage : Adventurer
{
    public override int MaxHealthPoints => 6;
    public override string Image => "mage";

    public override Dice Dice => new(new Face[]
    { 
        new MageBlue1(this),
        new MageBlue2(this),
        new MageBlue3(this),
        new MageViolet1(this),
        new MageViolet2(this),
        new MageGold1(this),
    });

    
}