using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class MainGame : MonoBehaviour
{
    public Tilemap Tilemap;
    public GridLayout Grid;
    public GameObject PrefabPlayer;
    public GameObject PrefabEnemy;
    public GameObject PrefabPNJ;
    public static MainGame Instance;
    public PlayerStats _PlayerStats;
    public UI ui;
    public PlayerMovement player;
    public PNJ pnj;

    [Header("Tiles")]
    public List<Tile> Tuiles = new List<Tile>();
    //public Tile WaterBoardArround;
    //public Tile WaterBoard;
    //public Tile Water;
    //public Tile Wall;

    

    bool[,] _map;
    GameObject[,] _pnj;
    GameObject[,] _enemies;
    GameObject[,] _gold;

    //public bool[,] Map => _map;

    private void Awake()
    {
        Instance = this;
    }


    private void Start()
    {
        _map = new bool[80,80];
        _enemies = new GameObject[20,20];
        _gold = new GameObject[20,20];
        _pnj = new GameObject[20,20];

        for(int y = 0; y < 80; y++)
        {
            for(int x = 0; x < 80; x++)
            {
                
                var tile = Tilemap.GetTile(new Vector3Int (x, y, 0));

                for (int i = 0; i < Tuiles.Count; i++)
                {
                    if (tile != null && tile.name.Replace(" (UnityEngine.Tilemaps.Tile)", "") == Tuiles[i].name)

                    {
                        _map[x, y] = true;
                    }
                }
               


                




            }

            
        }

        //Instantiate Player
        Vector3 position = Grid.CellToWorld(new Vector3Int(1,0,0));
        GameObject player = GameObject.Instantiate(PrefabPlayer, position, Quaternion.identity);

        //Instantiate Enemy 1
        Vector3 enemypostion = Grid.CellToWorld(new Vector3Int(0,4,0));
        GameObject Enemy = GameObject.Instantiate(PrefabEnemy, enemypostion, Quaternion.identity);

        _enemies[0,4] = Enemy;

        //Instantiate pnj
        Vector3 pnjposition = Grid.CellToWorld(new Vector3Int(6, 4, 0));
        GameObject pnj = GameObject.Instantiate(PrefabPNJ, pnjposition, Quaternion.identity);

        _pnj[6, 4] = pnj;
    }

    //public bool CheckForHealthPotion(Vector2Int position, PlayerMovement player)
    //{
    //    //if (healthPotions.ContainsKey(position))
    //    //{
    //    //    HealthPotion potion = healthPotions[position];
    //    //    player.Heal(potion.healthAmount);
    //    //    healthPotions.Remove(position);
    //    //    Destroy(potion.gameObject); // D�truit l'objet potion
    //    //    return true;
    //    //}
    //    //return false;
    //}


    public bool IsWall(int x, int y)
    {
        return _map[x, y];
    }

    public GameObject GetEnemie(int x, int y)
    {
        return _enemies[x, y];
    }

    public GameObject GetGold(int x, int y) 
    {
        return _gold[x, y];
    }
    public GameObject GetPNJ(int x, int y)
    {
        return _pnj[x, y];
    }


}


