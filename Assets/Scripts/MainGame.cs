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
    public GameObject Vortex1Prefab;
    public GameObject Vortex2Prefab;
    public static MainGame Instance;
    public PlayerStats _PlayerStats;
    public UI ui;
    public Player player;
    public PNJ pnj;
   

    [Header("Tiles")]
    public List<Tile> Tuiles = new List<Tile>();
    public List<Vector2Int> TeleportPostionsDepart = new List<Vector2Int>();
    public Vector2Int TeleportDestination;
    

    

    bool[,] _map;
    GameObject[,] _pnj;
    GameObject[,] _enemies;
    GameObject[,] _items;

    

    private void Awake()
    {
        Instance = this;
    }


    private void Start()
    {
        _map = new bool[20,20];
        _enemies = new GameObject[20,20];
        _items = new GameObject[20,20];
        _pnj = new GameObject[20,20];

        for(int y = 0; y < 20; y++)
        {
            for(int x = 0; x < 20; x++)
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
        Vector3 Vortex1position = Grid.CellToWorld(new Vector3Int(6, 3, 0));
        GameObject vortex1 = GameObject.Instantiate(Vortex1Prefab, Vortex1position, Quaternion.identity);
        TeleportPostionsDepart.Add(new Vector2Int(6, 3));

        Vector3 Vortex2position = Grid.CellToWorld(new Vector3Int(8, 16, 0));
        GameObject Vortex2 = GameObject.Instantiate(Vortex2Prefab, Vortex2position, Quaternion.identity);
        TeleportDestination = new Vector2Int(8, 16);


        //Instantiate Player
        Vector3 position = Grid.CellToWorld(new Vector3Int(0,0,0));
        GameObject player = GameObject.Instantiate(PrefabPlayer, position, Quaternion.identity);

        //Instantiate Enemy 1
        Vector3 enemyposition = Grid.CellToWorld(new Vector3Int(6,10,0));
        GameObject Enemy = GameObject.Instantiate(PrefabEnemy, enemyposition, Quaternion.identity);

        _enemies[6,10] = Enemy;

       


        //Instantiate pnj
        Vector3 pnjposition = Grid.CellToWorld(new Vector3Int(3, 6, 0));
        GameObject pnj = GameObject.Instantiate(PrefabPNJ, pnjposition, Quaternion.identity);

        _pnj[3, 6] = pnj;


    }

    public void AjoutItem(int x, int y, GameObject gameobject)
    {
        _items[x, y] = gameobject; 
    }


    public bool IsWall(int x, int y)
    {
        return _map[x, y];
    }

    public GameObject GetEnemie(int x, int y)
    {
        return _enemies[x, y];
    }

    public GameObject GetItem(int x, int y) 
    {
        return _items[x, y];
    }
    public GameObject GetPNJ(int x, int y)
    {
        return _pnj[x, y];
    }

    public bool isTeleport(int  x, int y)
    {
        return TeleportPostionsDepart.Contains(new Vector2Int(x, y));
    }
}










