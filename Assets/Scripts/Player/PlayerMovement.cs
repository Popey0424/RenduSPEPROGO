using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2Int CellPosition => _cellPosition;
    public static  PlayerMovement instance;

    Vector2Int _cellPosition;

    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Left;
    public KeyCode Right;

    private MainGame _map;
    public PlayerStats _playerStats;
    
    
    

    private void Start()
    {
    }


    private void Update()
    {

        if (Input.GetKeyDown(Up))
        {
             if(MainGame.Instance.IsWall(_cellPosition.x, _cellPosition.y + 1) == false)
            {
                GameObject _enemy = MainGame.Instance.GetEnemie(_cellPosition.x, _cellPosition.y + 1);
                GameObject _gold = MainGame.Instance.GetGold(_cellPosition.x, _cellPosition.y+1);
                if (_enemy != null)
                {
                    Fighting(_enemy);
                    




                }
                else if (_gold != null && _gold.name == "GoldPrefab(Clone)")
                {
                    Debug.Log("trouve gold");
                    MainGame.Instance.PlayerStats.GainGold(5);
                    
                    Destroy(_gold);
                }
                else
                {

                    _cellPosition.y++;

                    UpdateView();
                }
            }
        }
        
            
        
        if (Input.GetKeyDown(Down))
        {

            if (MainGame.Instance.IsWall(_cellPosition.x, _cellPosition.y - 1) == false)
            {
                GameObject enemy = MainGame.Instance.GetEnemie(_cellPosition.x, _cellPosition.y - 1);
                if (enemy != null)
                {
                    Debug.Log("Enemy");
                }
                else
                {
                    _cellPosition.y--;

                    UpdateView();
                }
            }
         
        }
        if (Input.GetKeyDown(Left)) 
        {
            if(MainGame.Instance.IsWall(_cellPosition.x - 1, _cellPosition.y) == false)
            {
                GameObject enemy = MainGame.Instance.GetEnemie(_cellPosition.x - 1, _cellPosition.y);
                if (enemy != null)
                {
                    Debug.Log("Enemy");
                }
                else
                {
                    _cellPosition.x--;

                    UpdateView();
                }
            }
           
        }
        if(Input.GetKeyDown(Right))
        {
            if (MainGame.Instance.IsWall(_cellPosition.x + 1, _cellPosition.y) == false)
            {
                GameObject enemy = MainGame.Instance.GetEnemie(_cellPosition.x + 1, _cellPosition.y);
                if (enemy != null)
                {
                    Debug.Log("Enemy");
                }
                else
                {
                    _cellPosition.x++;

                    UpdateView();
                }
            }

        }



    }
    private void UpdateView()
    {
        transform.position = new Vector3(_cellPosition.x * 0.08f, _cellPosition.y * 0.08f, 0);
    }

    public void Fighting(GameObject enemy)
    {
        var StatsEnemie = enemy.GetComponent<Enemy>();
        StatsEnemie.EnemyLifePoints -= (_playerStats.AttackPoints - StatsEnemie.EnemyArmorPoints);
        _playerStats.LifePoints -= (StatsEnemie.EnemyAttackPoints - _playerStats.ArmorPoints);

        if(StatsEnemie.EnemyLifePoints <= 0)
        {
            StatsEnemie.Die();
        }
    }



}
//GameObject gold = MainGame.Instance.GetGold(_cellPosition.x, _cellPosition.y + 1);
//if (gold != null)
//{
//    Debug.Log("Argent");
//    gold.GetComponent<PlayerStats>().EarnCoin();
//}



