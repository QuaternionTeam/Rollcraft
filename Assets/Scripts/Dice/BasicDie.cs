internal class BasicDie: Die
{
    internal override void Awake()
    {
        base.Awake();

        Faces = new[]
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