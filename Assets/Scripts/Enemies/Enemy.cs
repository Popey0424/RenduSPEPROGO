using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public int LifePoints = 100;
    public int AttackPoints = 20;
    public int ArmorPoints = 10;

    public GameObject healthPotionPrefab;
    public GameObject goldPrefab;

    private void Start()
    {
    }


    public void Hit(int Damage)
    {
        
        LifePoints -= Damage;
        
        if (LifePoints <= 0)
        {
            Die();
        }
    }

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
}
