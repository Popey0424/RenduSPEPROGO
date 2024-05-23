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

    public MainGame _map;
    

    public int AttackPoints = 10;
    private void Start()
    {
    }


    private void Update()
    {

        if (Input.GetKeyDown(Up))
        {
             if(MainGame.Instance.IsWall(_cellPosition.x, _cellPosition.y + 1) == false)
            {
                GameObject enemy = MainGame.Instance.GetEnemie(_cellPosition.x, _cellPosition.y + 1);
                if (enemy != null)
                {
                    enemy.GetComponent<Enemy>().Hit(AttackPoints);
                    if (MainGame.Instance.IsGold(_cellPosition.x, _cellPosition.y+1) == true)
                    {
                        Debug.Log("Tu est sur de largent");
                    }




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




}
//GameObject gold = MainGame.Instance.GetGold(_cellPosition.x, _cellPosition.y + 1);
//if (gold != null)
//{
//    Debug.Log("Argent");
//    gold.GetComponent<PlayerStats>().EarnCoin();
//}
