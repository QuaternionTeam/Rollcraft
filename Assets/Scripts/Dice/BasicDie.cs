internal class BasicDie: Die
{
    internal override void Awake()
    {
        base.Awake();

        faces = new[]
        {
            new Face(),
            new Face(),
            new Face(),
            new Face(),
            new Face(),
            new Face(),  
        };
    }
}