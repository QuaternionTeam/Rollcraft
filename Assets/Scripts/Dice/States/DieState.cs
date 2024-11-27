internal class DieState
{
    protected readonly Die die;

    internal DieState(Die die)
    {
        this.die = die;
    }

    internal virtual void Roll() { }

    internal virtual void Update() { }
    internal virtual void Enter() { }
    internal virtual void Exit() { }
}