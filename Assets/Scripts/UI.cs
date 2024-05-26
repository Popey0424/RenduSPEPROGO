using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI TextExperience;
    public TextMeshProUGUI TextGold;
    public TextMeshProUGUI TextLevel;
    public TextMeshProUGUI TextDamage;
    public TextMeshProUGUI TextHealth;
    public TextMeshProUGUI TextArmor;
    
    public MainGame game;
    

    private void Start()
    {
        
        NewTextExperience(0);
        NewTextGold();
        NewTextLevelUp();
        UpdateLifeText(game._PlayerStats.LifePoints);
        NewTextArmorLevel(game._PlayerStats.ArmorPoints);
    }
    private void Update()
    {
        
    }

    public void NewTextGold()
    {
        game.ui.TextGold.text = "Gold :" + MainGame.Instance._PlayerStats.Gold.ToString();
    }

    public void NewTextExperience(int experience)
    {
        game.ui.TextExperience.text = "Experience :" + MainGame.Instance._PlayerStats.Experience.ToString();
    }

    public void NewTextLevelUp()
    {
        game.ui.TextLevel.text = "Level :" + game._PlayerStats.Level.ToString();
    }

    public void UpdateLifeText(int Life)
    {
        TextHealth.text =   Life.ToString();
    }

    public void NewTextArmorLevel(int Armor) 
    {
        TextArmor.text = "Armor : " + Armor.ToString();
    }
}
