using System.Collections.Generic;
public class EnemyScreenModel
{
    private List<EnemyModel> enemies;

    public EnemyScreenModel()
    {
        New();
    }

    private void New()
    {
        enemies = new();
    }

    public void AddEnemy(EnemyModel enemy)
    {
        enemies.Add(enemy);
    }

    public EnemyModel GetEnemy(int index)
    {
        return enemies[index];
    }

    public int NumberOfEnemies()
    {
        int num = 0;
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].isAlive) num++;
        }
        return num;
    }

}
