using System.Collections.Generic;
using System.Linq;

internal class TurnSystem
{
    private readonly List<Enemy> enemies;
    public List<Face> enemyFaces;
    //private readonly List<Adventurer> adventurer;
    
    public Face adventurerFace = null;
    public bool hasToSelectAdventurer = false;
    public bool hasToSelectTargets = false;

    internal TurnSystem(List<Adventurer> adventurer, List<Enemy> enemies)
    {
        //this.adventurer = adventurer;
        this.enemies = enemies;
    }

    internal void StartTurn()
    {
        enemyFaces = enemies.Select(enemy => enemy.Dice.Roll()).ToList();

        hasToSelectAdventurer = true;
    }

    public void EndTurn()
    {
        foreach(Face face in enemyFaces)
            face.ApplyEffect();
    }

    public void HasBeenClicked(Unit unit)
    {
        if(hasToSelectAdventurer && unit is Adventurer adventurer)
        {
            hasToSelectAdventurer = false;

            adventurerFace = adventurer.Dice.Roll();
            
            hasToSelectTargets = true;
        }

        if(hasToSelectTargets)
        {
            
        }


    }
}