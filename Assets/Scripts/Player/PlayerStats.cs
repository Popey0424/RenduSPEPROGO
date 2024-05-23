using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int LifePoints = 100;
    public int AttackPoints = 1000;
    public int ArmorPoints = 50;
    public int Experience = 0;
    public int Level = 1;
    public int ExperienceForNextLevel = 20;
    public int MaxLevel = 5;
  //  public List<PlayerStats> Item = new List<PlayerStats>() ;
    public PlayerMovement player;
    public int Gold = 0;

   


    public void GainExperience(int amount)
    {
        Experience += amount;

        MainGame.Instance.ui.NewTextExperience(amount);    
        if (Experience >= ExperienceForNextLevel && Level < MaxLevel)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        Level++;
        Experience = 0;
        ExperienceForNextLevel += 100;
        AttackPoints += 5;
        LifePoints += 20;
    }

    public void EarnCoin()
    {
        Gold++;
        Debug.Log("GG TA gagne un gold");
    }



}
