using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Recette : MonoBehaviour
{
    public TextMeshProUGUI text;
    public bool inR;
    public GameObject Recettpanel;
    public Sprite Items1;
    public Sprite Items2;
    public Sprite Items3;
    public Sprite Items4;
    public Sprite Items5;
    public Sprite Items6;
    public Sprite Items7;
    public Sprite Items8;
    public Sprite Items9;

    public List<GameObject> ItemsList;

    public GameObject PrefabUi;
    public Transform GridParent;

    Dictionary<string, List<Sprite>> ItemsRecette = new Dictionary<string, List<Sprite>>();
    

    void Start()
    {
        //Exclu C#  new List<Sprite>(){ Items1,Items2,Items3,Items6,Items7 }
        ItemsRecette.Add("Bloc", new List<Sprite>(){ Items1,Items2,Items3,Items6,Items7 });
        ItemsRecette.Add("Item", new List<Sprite>() { Items4,Items5,Items8,Items9 });

        ItemsList = new List<GameObject>();

    }
    private void OnTriggerStay(Collider other)
    {
        text.enabled = true;
        text.text = "Appuyer sur E pour Regarder le livre ";
        inR = true; 
    }
    private void OnTriggerExit(Collider other)
    {
        text.text = "";
        inR = false;
    }
    private void Update()
    {
        if (inR) 
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                text.enabled = false;
                Recettpanel.SetActive(true);

            }
        }
    }
    public void ResetUi()
    {
        foreach(GameObject itemlist in ItemsList)
        {
            Destroy(itemlist);
        }
    }
    public void GridBloc()
    {
        foreach(Sprite sprite in ItemsRecette["Bloc"]) 
        {
            GameObject card = Instantiate(PrefabUi,GridParent);
            Image cardImage = card.GetComponent<Image>();
            cardImage.sprite = sprite;
            ItemsList.Add(card);
        }
    }
    public void GridItem()
    {
        foreach (Sprite sprite in ItemsRecette["Item"])
        {
            GameObject card = Instantiate(PrefabUi, GridParent);
            Image cardImage = card.GetComponent<Image>();
            cardImage.sprite = sprite;
            ItemsList.Add(card);
        }
    }

}
