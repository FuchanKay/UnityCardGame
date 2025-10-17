//i think this should be an abstract class with each specific enemy being a class but it might be too much work idk
using UnityEngine;
public enum EnemyId
{
    Skelly,
}


public abstract class EnemyModel
{

    public string name;
    public EnemyId id;

    public int maxHp;
    public int hpRange;
    public int hp;
    public bool isAlive;
    public string description;
    public bool selected = false;

    //if the enemy has a specific TakeDamage effect, override this method in the class
    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            hp = 0;
            isAlive = false;
        }
    }
    public void GenerateMaxHp()
    {
        int difference = Random.Range(-hpRange, hpRange + 1);
        maxHp -= difference;
    }
}

public class SkellyEnemy : EnemyModel
{
    public SkellyEnemy(int num = 0)
    {
        maxHp = 20;
        hpRange = 2;

        GenerateMaxHp();

        hp = maxHp;

        isAlive = true;

        if (num == 0) name = "Skelly";
        else name = string.Concat("Skelly ", num);

        id = EnemyId.Skelly;
    }
}
