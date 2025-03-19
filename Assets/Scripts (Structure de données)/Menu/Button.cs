using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Shop shop;
    public void ExitButton()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        shop.text.enabled = true;
        shop.barreIventaire.SetActive(true);
        shop.shop.SetActive(false);
    }
}
