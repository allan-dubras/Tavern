using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public Shop shop;
    public Inventaire inventaire;
    public void ExitButton()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        shop.text.enabled = true;
        shop.barreIventaire.SetActive(true);
        shop.shop.SetActive(false);
        inventaire.panelMoney.SetActive(true);
    }
    public void allerDroite()
    {
        shop.page1.SetActive(false);
        shop.page2.SetActive(true);
        shop.buttongauche.SetActive(true);
        shop.buttondroite.SetActive(false);
    }
    public void allerGauche() 
    {
        shop.page1.SetActive(true);
        shop.page2.SetActive(false);
        shop.buttondroite.SetActive(true);
        shop.buttongauche.SetActive(false) ;
    }
    public void Buy() 
    {

    }
}
