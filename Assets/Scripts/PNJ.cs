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
    public Image ImageText;

    private int index;
    public string[] lines;
    public float TextSpeed;

    public void StartImput()
    {
        
        ImageText.gameObject.SetActive(true);
        TextComponent.gameObject.SetActive(true);

        TextComponent.text = string.Empty;
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
}
