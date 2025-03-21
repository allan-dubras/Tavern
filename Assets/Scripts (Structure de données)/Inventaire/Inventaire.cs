using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG;
using DG.Tweening;
using Unity.VisualScripting;
using System.Data.SqlTypes;


public class Inventaire : MonoBehaviour
{
    List<Item> ListeItems;

    public Item vide;
    public List<Item> listeItems ;

    public int? swap;

    public List<Image> ListeItemUI ;


    public List<TextMeshProUGUI> nombre;

    public bool finish = true;

    public Sprite caseVide;

    public GameObject panelMoney;
    public TextMeshProUGUI money;
    public int argent;

    void Start()
    {
        argent = 50;
    }


    //Récupérez la liste des items 
    public List<Item> getListeItems()
    {
        return listeItems;
    }

    //Écrasez la liste avec la nouvelle listeItem2
    public void setListeItems(List<Item> listeItems2)
    {
        ListeItems = listeItems2;

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger" + other.gameObject.name);
        GameObject gameObjectCollider = other.gameObject;
        Item item = gameObjectCollider.GetComponent<Item>();

        if (item != null)
        {
            AddItem(item);
        }
    }

    public Image getCaseUIVide()
    {
        foreach (Image image in ListeItemUI)
        {
            if (image.sprite == caseVide) return image;
        }
        return null;
    }


    public void AddItem(Item item)
    {
        item.grabItem();
        listeItems.Add(item);
        //on veux ajouter l'icon de l'item à la source image de notre case
        item.setUIcase(getCaseUIVide());
        item.getUICase().sprite=item.icone;
        item.getUICase().GetComponentInChildren<TextMeshProUGUI>().text =""+item.getNombre();
    }
    public void RemoveItem(Item item)
    {
        item.dropItem(this.gameObject.transform.position, this.gameObject.transform.forward);
        item.getUICase().sprite=caseVide;
        listeItems.Remove(item);
        item.getUICase().GetComponentInChildren<TextMeshProUGUI>().text =""+ 0;

    }
    IEnumerator wait()
    {
        finish=false;
        ListeItemUI[swap.Value].transform.DOPunchScale(Vector2.up, 1f);
        yield return new WaitForSeconds(1f);
        finish = true;
    }
    void Update()
    {
        money.text=argent.ToString();
        if (Input.GetKeyDown(KeyCode.E) && listeItems.Count != 0)
        {
            RemoveItem(listeItems[swap.Value]);
            swap = null;
        }
        else {
            Debug.Log("a");
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            swap = 0;
            if (finish == true) 
            { 
                StartCoroutine(wait());
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            swap = 1;
            if (finish == true)
            {
                StartCoroutine(wait());
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            swap = 2;
            if (finish == true)
            {
                StartCoroutine(wait());
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            swap = 3;
            if (finish == true)
            {
                StartCoroutine(wait());
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            swap = 4;
            if (finish == true)
            {
                StartCoroutine(wait());
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            swap = 5;
            if (finish == true)
            {
                StartCoroutine(wait());
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            swap = 6;
            if (finish == true)
            {
                StartCoroutine(wait());
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            swap = 7;
            if (finish == true)
            {
                StartCoroutine(wait());
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            swap = 8;
            if (finish == true)
            {
                StartCoroutine(wait());
            }

        }

    }
}
