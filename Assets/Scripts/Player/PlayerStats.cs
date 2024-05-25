using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int LifePoints;
    public int AttackPoints;
    public int ArmorPoints;
    public int Experience;
    public int Level;
    public int ExperienceForNextLevel;
    public int MaxLevel;
    public int Gold;

   


    public void GainExperience(int amount)
    {
        Experience += amount;

        MainGame.Instance.ui.NewTextExperience(amount);    
        if (Experience >= ExperienceForNextLevel && Level < MaxLevel)
        {
            //LevelUp(1);
        }
    }

    public void GainGold(int money)
    {
        Gold += money;
        MainGame.Instance.ui.NewTextGold(money);
    }
    //public void LevelUp(int level)
    //{
    //    Level += level;
    //    Experience = 0;
    //    ExperienceForNextLevel += 20;
    //    AttackPoints += 5;
    //    LifePoints += 20;
    //    MainGame.Instance.ui.NewTextLevel(level);
    //}

    //public void EarnCoin()
    //{
    //    Gold++;
    //    Debug.Log("GG TA gagne un gold");
    //}



}
