using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public int EnemyLifePoints = 100;
    public int EnemyAttackPoints = 20;
    public int EnemyArmorPoints = 10;

    public GameObject healthPotionPrefab;
    public GameObject goldPrefab;

    //private PlayerStats player;
    //private PlayerMovement playerposition;
    //private  MainGame maingame;

    private void Start()
    {
    }

   
    //public void Hit(int Damage)
    //{
        
    //    EnemyLifePoints -= Damage;
        
    //    if (EnemyLifePoints <= 0)
    //    {
    //        Die();
    //    }
    //    else
    //    {

    //    }
    //}

    public void Die()
    {
        
        GameObject.Destroy(gameObject);
        MainGame.Instance.PlayerStats.GainExperience(10);
        DropLoot(transform.position); 
    }

    public void DropLoot(Vector2 position)
    {
        float ItemAleatoire = Random.Range(0f, 1f);
        if (ItemAleatoire < 0.3f)
        {
            Instantiate(healthPotionPrefab, position, Quaternion.identity);
        }
        else if (ItemAleatoire < 0.9f)
        {
            Instantiate(goldPrefab, position, Quaternion.identity);

        }
    }

    //public void CheckForGold()
    //{
    //    Vector2Int goldPosition = maingame.
    //    if(playerposition.CellPosition == )
    //}

    
}
