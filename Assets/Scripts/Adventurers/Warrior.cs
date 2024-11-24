internal class Warrior : Adventurer
{
    public override int MaxHealthPoints => 8;
    public override string Image => "warrior";

    public override Dice Dice => new(new Face[]
    { 
        new WarriorBlue1(this),
        new WarriorBlue2(this),
        new WarriorBlue3(this),
        new WarriorViolet1(this),
        new WarriorViolet2(this),
        new WarriorGold1(this),
    });

    
}