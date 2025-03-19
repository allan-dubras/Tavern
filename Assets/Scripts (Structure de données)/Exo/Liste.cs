using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Liste : MonoBehaviour
{
    //Déclaration 
    List<string> dialogues;
    List<GameObject> ennemies;
    public TextMeshProUGUI dialoguePlace;
    public Texture Image1;
    public Texture Image2;
    public Texture Image3;
    public GameObject rawimage;

    void Start()
    {
        //Instantiation
        dialogues = new List<string>();
        dialogues.Add("MAN VS FATE ");
        dialogues.Add("NIHILISM");
        dialogues.Add("Existentialism");
        dialogues.Add("MAN VS FAITH ");
        dialogues.Add("SURHOMME");
        dialogues.Add("LIBERTY");
        dialogues.Add("FALSE LIBERTY");
        dialogues.Add("GOD COMPLEXE ");
        dialogues.Add("ACCEPTANCE");
        dialogues.Add("SACRIFICE");
        ennemies = new List<GameObject>();
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        for (int i = 0; i < dialogues.Count; i++)
        {
            if (i == 0)
            {
                rawimage.GetComponent<RawImage>().texture = Image1;
            }
            if (i == 3)
            {
                rawimage.GetComponent<RawImage>().texture = Image2;
            }
            if (i == 7)
            {
                rawimage.GetComponent<RawImage>().texture = Image3;
            } 
            dialoguePlace.text = dialogues[i];
            yield return new WaitForSeconds(3f);
            if (i == 9)
            {
                StartCoroutine(wait());
            }
        }
    }
}
