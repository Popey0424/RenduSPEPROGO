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
    
    public MainGame game;
    

    private void Start()
    {
        
        NewTextExperience(0);
        NewTextGold();
        NewTextLevelUp();
        UpdateLifeText(game._PlayerStats.LifePoints);
    }
    private void Update()
    {
        game.ui.TextGold.text = "Gold :" + game._PlayerStats.Gold.ToString();
    }

    public void NewTextGold()
    {
        
    }

    public void NewTextExperience(int experience)
    {
        game.ui.TextExperience.text = "Experience :" + experience.ToString();
    }

    public void NewTextLevelUp()
    {
        game.ui.TextLevel.text = "Level :" + game._PlayerStats.Level.ToString();
    }

    public void UpdateLifeText(int Life)
    {
        TextHealth.text =   Life.ToString();
    }
}
