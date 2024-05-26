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
    public int MaxLevel = 5;
    public int Gold;

    void Start()
    {
        
        Level = 1;
        Experience = 0;
        ExperienceForNextLevel = 10; 
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
        ExperienceForNextLevel += 10; // Exemple d'incr�ment, ajustez selon votre syst�me de progression
        MainGame.Instance.ui.NewTextExperience(Experience);
        Debug.Log($"Niveau atteint: {Level}");
        MainGame.Instance.ui.NewTextLevelUp();

        if (Level >= MaxLevel)
        {
            Experience = ExperienceForNextLevel - 1; // Emp�cher l'XP d'aller au-del� du n�cessaire pour le dernier niveau
            Debug.Log("Niveau maximum atteint");
        }
    }

    

    public void PlayerDie()
    {

    }
    




}
