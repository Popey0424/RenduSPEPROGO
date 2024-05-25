using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public int EnemyLifePoints;
    public int EnemyAttackPoints;
    public int EnemyArmorPoints;

    public GameObject healthPotionPrefab;
    public GameObject goldPrefab;

    

    public void Die()
    {
        
        GameObject.Destroy(gameObject);
        MainGame.Instance._PlayerStats.GainExperience(30);
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
