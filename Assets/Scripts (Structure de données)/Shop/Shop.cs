using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject barreIventaire;
    public GameObject shop;
    public TextMeshProUGUI text;
    //Génération des items
    [SerializeField]
    private Vector3[] posDesItemsPossable;
    [SerializeField]
    private GameObject[] items;

    List<Queue<GameObject>> Stock;

    //Pages
    public GameObject page1;
    public GameObject page2;
    public GameObject buttondroite;
    public GameObject buttongauche;


    //Argent
    [SerializeField]
    private TextMeshProUGUI money;
    public bool triggerActive;

    public int arg;

    [SerializeField]
    private GameObject Player;



    void Start()
    {
        Stock = new List<Queue<GameObject>>();
        text.enabled = false;
        for (int i = 0; i < 9; i++) 
        {
            posDesItemsPossable[i] = items[i].transform.position;
        }
        for (int i = 0; i < 9; i++)
        {
            Queue<GameObject> Create = new Queue<GameObject>();
            Stock.Add(Create);
            Create.Enqueue(items[i]);
            
        }


    }



    //Shop
    public void Shopping(GameObject itemname)
    {
       GameObject newobjet = Instantiate(itemname);
        // Item 1
        String[] nom = itemname.name.Split(" ");
        int indice=Int32.Parse(nom[1]);
        int compte = Stock[indice - 1].Count;
        if (compte == 0)
        {
            //position 
            newobjet.transform.position = posDesItemsPossable[indice - 1];
        }
        if (compte > 0) 
        {
            newobjet.transform.position = posDesItemsPossable[indice - 1];
            newobjet.transform.position = newobjet.transform.position + new Vector3(compte*2,0,0);

        }
        Stock[indice-1].Enqueue(newobjet);
    }

    //Faire un historique d'achat (pile)


    //Gestion Menu / Interaction
    private void OnTriggerEnter(Collider other)
    {
        triggerActive = true;
        if (other.CompareTag("Player"))
        {
            text.enabled = true;
            text.text = "Appuyer sur O pour Ouvrir La Boutique";
        }

    }
    private void OnTriggerExit(Collider other)
    {
        triggerActive = false;
        text.text = "";
    }
    void Update()
    {
        if (triggerActive) 
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                arg = Player.GetComponent<Inventaire>().argent;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                Player.GetComponent<Inventaire>().panelMoney.SetActive(false);
                shop.SetActive(true);
                text.enabled=false;
                barreIventaire.SetActive(false);
                money.text =  arg.ToString();
            }
        }
    }



}
