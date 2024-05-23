using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI textexperience;
    
    public MainGame game;

    private void Start()
    {
        
    }

    public void NewTextExperience(int experience)
    {
        game.ui.textexperience.text = "Experience :" + experience.ToString();
    }
}
