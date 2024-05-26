using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PNJ : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public Button ButtonAccpet;
    public Button ButtonExit;
    public TextMeshProUGUI TextComponent;
    public TextMeshProUGUI TextComponent2;
    public Image ImageText;

    private int index;
    public string[] lines;
    public float TextSpeed;

    public void StartImput()
    {
        
        ImageText.gameObject.SetActive(true);
        TextComponent.gameObject.SetActive(true);

        TextComponent.text = string.Empty;
        TextComponent2.text = string.Empty;
        StartDialogue();
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
        
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            TextComponent.text += c;
            yield return new WaitForSeconds(TextSpeed);
            
        }
        ButtonAccpet.gameObject.SetActive(true);
        ButtonExit.gameObject.SetActive(true);
    }

    public void OnClickAccpet()
    {
        if(MainGame.Instance._PlayerStats.Gold >= 5)
        {
            MainGame.Instance._PlayerStats.Gold -= 5;
            Debug.Log("Tu a acheter la potion");
        }
        else
        {
            TextComponent.gameObject.SetActive(false);
            Debug.Log("Ta pas assez de thune");
            index =1;
            TextComponent2.gameObject.SetActive(true);
            StartCoroutine (TypeLine2());
        }
        
        ButtonAccpet.gameObject.SetActive(false);
        


    }

    IEnumerator TypeLine2()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            TextComponent2.text += c;
            yield return new WaitForSeconds(TextSpeed);

        }
        
        ButtonExit.gameObject.SetActive(true);
    }

    public void OnClickExit()
    {
        ImageText.gameObject.SetActive(false);
        TextComponent.gameObject.SetActive(false);
        ButtonExit.gameObject.SetActive(false); 
        ButtonAccpet.gameObject.SetActive(false);
        TextComponent2.gameObject.SetActive(false);
    }
}
