using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{

    public int LifePoints = 100;
    public int AttackPoints =25;
    public int ArmorPoints = 50;
    public int Experience = 0;
    public int Level =1;
    public int ExperienceForNextLevel =20;
    public int MaxLevel = 5;
    public int Gold = 0;




    private void Start()
    {
        LifePoints = 100;
        AttackPoints = 25;
        ArmorPoints = 50;
        Experience = 0;
        Level = 1;
        ExperienceForNextLevel = 20;
        MaxLevel = 5;
         Gold = 0;

}

    public void GainExperience(int amount)
    {
        Experience += amount;

        MainGame.Instance.ui.NewTextExperience(amount);    
        if (Experience >= ExperienceForNextLevel && Level < MaxLevel)
        {
            Debug.Log("J'ai assez D'XP pour up de niveau");
            LevelUp();
            
        }
    }

    
    private void LevelUp()
    {
        Experience -= ExperienceForNextLevel;
        Level++;
        ExperienceForNextLevel += 10; 
        MainGame.Instance.ui.NewTextExperience(Experience);
        Debug.Log($"Niveau atteint: {Level}");
        MainGame.Instance.ui.NewTextLevelUp();

        if (Level >= MaxLevel)
        {
            Experience = ExperienceForNextLevel - 1; 
            Debug.Log("Niveau maximum atteint");
        }
    }

    

    public void PlayerDie()
    {
        print("Mort");
        Application.Quit();
    }
    




}
