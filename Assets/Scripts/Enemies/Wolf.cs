internal class Wolf : Enemy
{
    public override int MaxHealthPoints => 5;
    public override string Image => "wolf";

    public override Dice Dice => new(new Face[]
    { 
        new WolfFace1(this),
        new WolfFace1(this),
        new WolfFace2(this),
        new WolfFace2(this),
        new WolfFace3(this),
        new WolfFace3(this),
    });

    
}