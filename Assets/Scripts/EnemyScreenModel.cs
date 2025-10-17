using System.Collections.Generic;
using UnityEngine;
public class EnemyScreenModel
{
    private List<EnemyModel> enemies;
    private GameModel game;

    public EnemyScreenModel(GameModel game)
    {
        New(game);
    }

    private void New(GameModel game)
    {
        this.game = game;
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
        //int num = 0;
        //for (int i = 0; i < enemies.Count; i++)
        //{
        //    if (enemies[i].isAlive) num++;
        //}
        return enemies.Count;
    }

    public void SelectEnemy(int index)
    {
        enemies[index].selected = true;
    }

    public EnemyModel GetRandomEnemy()
    {
        int index = Random.Range(0, enemies.Count);
        return enemies[index];
    }

    public void AOEDamage(int dmg)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            EnemyModel enemy = enemies[i];
            enemy.TakeDamage(dmg);
        }
    }

}
