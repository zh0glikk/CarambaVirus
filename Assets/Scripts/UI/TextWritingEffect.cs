using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextWritingEffect : MonoBehaviour
{

    public float delay;

    [TextArea]
    public string fullText1;
    [TextArea]
    public string fullText2;
    [TextArea]
    public string fullText3;
    [TextArea]
    public string fullText4;
    [TextArea]
    public string fullText5;

    private string fullText;
    private string currentText = "";
    
    void Start()
    {
        StartCoroutine(ShowText());
    }


    void Randomizer()
    {
        int rand = Random.Range(1, 6);
        if (rand == 1)
        {
            fullText = fullText1;
        }
        else if(rand == 2)
        {
            fullText = fullText2;
        }
        else if (rand == 3)
        {
            fullText = fullText3;
        }
        else if (rand == 4)
        {
            fullText = fullText4;
        }
        else if (rand == 5)
        {
            fullText = fullText5;
        }
        else
        {
            fullText = fullText1;
        }
    }

    IEnumerator ShowText()
    {
        while (true)
        {
            Randomizer();
            for (int i = 0; i <= fullText.Length; i++)
            {
                currentText = fullText.Substring(0, i);
                GetComponent<Text>().text = currentText;
                yield return new WaitForSeconds(delay);
            }
            yield return new WaitForSeconds(3f);
            for (int i = fullText.Length; i >= 0; i--)
            {
                currentText = fullText.Substring(0, i);
                GetComponent<Text>().text = currentText;
                yield return new WaitForSeconds(delay/2);
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
