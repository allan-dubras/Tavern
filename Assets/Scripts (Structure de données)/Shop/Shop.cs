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

    public bool triggerActive;

    void Start()
    {
        text.enabled = false;
        for (int i = 0; i < 9; i++) 
        {
            posDesItemsPossable[i] = items[i].transform.position;
        }
    }



    //Shop

    //Faire un historique d'achat (pile)
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
                Time.timeScale = 0f;  
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                text.enabled=false;
                barreIventaire.SetActive(false);
                shop.SetActive(true);
            }
        }
    }
}
