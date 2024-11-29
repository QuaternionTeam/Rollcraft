internal class Adventurer : Unit 
{ 
    internal bool HasDie { get; set; }

    internal override void Awake()
    {
        base.Awake();

        var dieInstance = Instantiate(Die);
    
        Die = dieInstance.GetComponent<Die>();

        Die.gameObject.SetActive(false);
    }

    internal override void RollDie()
    {
        base.RollDie();
        Die.gameObject.SetActive(true);
    }

    internal override void ResolveDie()
    {
        base.ResolveDie();
        Die.gameObject.SetActive(false);
    }
}