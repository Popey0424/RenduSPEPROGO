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
        NewTextGold(0);
        NewTextLevel(1);
    }

    public void NewTextGold(int gold)
    {
        game.ui.TextGold.text = "Gold :" + gold.ToString();
    }

    public void NewTextExperience(int experience)
    {
        game.ui.TextExperience.text = "Experience :" + experience.ToString();
    }

    public void NewTextLevel(int level)
    {
        game.ui.TextLevel.text = "Level :" + level.ToString();
    }

    public void UpdateLifeText()
    {
        TextHealth.text = "Life :" + game.player._playerStats.LifePoints;
    }
}
