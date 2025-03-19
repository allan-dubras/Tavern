using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class Structure : MonoBehaviour
{
    //Déclaration du tableau en mettant sont type ici string en ouvre les crochet et les ferme pour dire que c'est un tableau et le nom du tableau.
    string[] dialogues;
    public TextMeshProUGUI dialogu1;
    public TextMeshProUGUI dialogu2;
    public Texture Image1;
    public Texture Image2;
    public Texture Image3;
    GameObject[] listeObjets;
    public GameObject panel;


    IEnumerator wait()
    {
        for (int i = 0; i < dialogues.Length; i++) 
        {
            if(i == 0)
            {
                panel.GetComponent<RawImage>().texture =Image1;
            }
            if (i == 3) 
            { 
                panel.GetComponent <RawImage>().texture =Image2;
            }
            if (i == 7)
            {
                panel.GetComponent<RawImage>().texture = Image3;
            }
            if (i == 0 || i == 2 || i == 4 || i == 6 || i == 8)
            {
                dialogu1.text = dialogues[i];
                dialogu2.text = null;
            }
            else 
            {
                dialogu2.text = dialogues[i];
                dialogu1.text = null;
            }
            yield return new WaitForSeconds(3f);
            if (i==9)
            {
                StartCoroutine(wait());
            }
        }
    }
    void Start()
    {
        //Instantiation
        dialogues = new string[10];
        dialogues[0] = "The House in Fata Morgana";
        dialogues[1] = "Crime et chatiment";
        dialogues[2] = "Les Frères Karamazov";
        dialogues[3] = "L'étranger";
        dialogues[4] = "Homunculus";
        dialogues[5] = "Ascension";
        dialogues[6] = "PEAK FICTION";
        dialogues[7] = "Masterpiece";
        dialogues[8] = "L'idiot";
        dialogues[9] = "Lord of the Rings";
        StartCoroutine(wait());
    }
    void Update()
    {

    }
}
