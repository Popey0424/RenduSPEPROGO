using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI TextExperience;
    public TextMeshProUGUI TextGold;
    
    public MainGame game;

    private void Start()
    {

        NewTextExperience(0);
        NewTextGold(0);
    }

    public void NewTextGold(int gold)
    {
        game.ui.TextGold.text = "Gold :" + gold.ToString();
    }

    public void NewTextExperience(int experience)
    {
        game.ui.TextExperience.text = "Experience :" + experience.ToString();
    }
}
