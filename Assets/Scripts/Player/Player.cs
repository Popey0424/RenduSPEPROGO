using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public Vector2Int CellPosition => _cellPosition;

    public static Player instance;

    Vector2Int _cellPosition;

    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Left;
    public KeyCode Right;

    private MainGame _map;
    public PlayerStats _playerStats;

    [HideInInspector] public Vector2Int Offset;





    private void Start()
    {
    }


    private void Update()
    {


        if (Input.GetKeyDown(Up))
        {
            Offset = new Vector2Int(0, 1);
        }
        if (Input.GetKeyDown(Down))
        {
            Offset = new Vector2Int(0, -1);
        }
        if (Input.GetKeyDown(Left))
        {
            Offset = new Vector2Int(-1, 0);
        }
        if (Input.GetKeyDown(Right))
        {
            Offset = new Vector2Int(1, 0);
        }
        if (Offset.x != 0 || Offset.y != 0)
        {
            if (MainGame.Instance.IsWall(_cellPosition.x + Offset.x, _cellPosition.y + Offset.y) == false)
            {
                GameObject _enemy = MainGame.Instance.GetEnemie(_cellPosition.x + Offset.x, _cellPosition.y + Offset.y);


                GameObject _item = MainGame.Instance.GetItem(_cellPosition.x + Offset.x, _cellPosition.y + Offset.y);
                GameObject _pnj = MainGame.Instance.GetPNJ(_cellPosition.x + Offset.x, _cellPosition.y + Offset.y);
                if (_enemy != null)
                {
                    Fighting(_enemy);
                }
                else if (_item != null)
                {

                    if (_item.name == "GoldPrefab(Clone)")
                    {
                        Debug.Log("DELOR");

                        _playerStats.Gold += 10;
                        MainGame.Instance.ui.NewTextGold();

                    }
                    else if (_item.name == "HealthPotionPrefab(Clone)")
                    {
                        Debug.Log("DELavie");
                        _playerStats.LifePoints += 25;
                        MainGame.Instance.ui.UpdateLifeText(_playerStats.LifePoints);

                    }
                    Destroy(_item);

                }
                else if (_pnj != null)
                {
                    MainGame.Instance.pnj.StartImput();
                }
                else if (MainGame.Instance.isTeleport(_cellPosition.x + Offset.x, _cellPosition.y + Offset.y))
                {
                    Teleport();
                }
                else
                {

                    UpdateView();
                }

            }
            Offset = new Vector2Int(0, 0);

        }



    }




    private void Teleport()
    {
        _cellPosition = MainGame.Instance.TeleportDestination;
        UpdateView();
        Debug.Log("Téléporté à: " + _cellPosition);
    }













    public void UpdateView()
    {
        _cellPosition += Offset;
        transform.position = new Vector3(_cellPosition.x * 0.08f, _cellPosition.y * 0.08f, 0);
    }

    public void Fighting(GameObject enemy)
    {
        var StatsEnemie = enemy.GetComponent<Enemy>();
        Debug.Log("Le combat commence");


        int degatsInfliges = _playerStats.AttackPoints;
        if (StatsEnemie.EnemyArmorPoints > 0)
        {
            if (degatsInfliges > StatsEnemie.EnemyArmorPoints)
            {
                degatsInfliges -= StatsEnemie.EnemyArmorPoints;
                StatsEnemie.EnemyArmorPoints = 0;
                StatsEnemie.EnemyLifePoints -= degatsInfliges;
            }
            else
            {
                StatsEnemie.EnemyArmorPoints -= degatsInfliges;
            }
        }
        else
        {
            StatsEnemie.EnemyLifePoints -= degatsInfliges;
        }
        Debug.Log("Tu lui as infligé des dégâts: " + degatsInfliges);


        int degatsRecus = StatsEnemie.EnemyAttackPoints;
        if (_playerStats.ArmorPoints > 0)
        {
            if (degatsRecus > _playerStats.ArmorPoints)
            {
                degatsRecus -= _playerStats.ArmorPoints;
                _playerStats.ArmorPoints = 0;
                _playerStats.LifePoints -= degatsRecus;
            }
            else
            {
                _playerStats.ArmorPoints -= degatsRecus;
            }
        }
        else
        {
            _playerStats.LifePoints -= degatsRecus;
        }
        Debug.Log("Il t'a infligé des dégâts: " + degatsRecus);

        MainGame.Instance.ui.NewTextArmorLevel(_playerStats.ArmorPoints);
        MainGame.Instance.ui.UpdateLifeText(_playerStats.LifePoints);

        if (_playerStats.LifePoints <= 0)
        {
            _playerStats.PlayerDie();
        }

        if (StatsEnemie.EnemyLifePoints <= 0)
        {
            MainGame.Instance._PlayerStats.GainExperience(30);
            int ItemAleatoire = Random.Range(0, 100);
            if (ItemAleatoire < 60)
            {
                var Item = GameObject.Instantiate(StatsEnemie.goldPrefab, enemy.transform.position, Quaternion.identity);
                MainGame.Instance.AjoutItem(6, 10, Item);

            }
            else
            {

                GameObject Item = GameObject.Instantiate(StatsEnemie.healthPotionPrefab, enemy.transform.position, Quaternion.identity);
                MainGame.Instance.AjoutItem(6, 10, Item);
            }
            Destroy(enemy);
        }
    }
}

