using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;




public class Item : MonoBehaviour
{
    // id pour trouver l'item avec une valeur absolu
    private int id;
    [SerializeField]
    public string nom = "";
    [SerializeField]
    public string type = "";
    [SerializeField]
    private string description = "NYI";
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    public Sprite icone;
    [SerializeField]
    public int nombre;
    [SerializeField]
    public int Money;




    private Image Uicase;

    public void setUIcase(Image image)
    {
        this.Uicase = image;
    }
    public Image getUICase()
    {
        return this.Uicase;
    }
    public void setNombre(int value){ this.nombre = value; }
    public int getNombre() { return this.nombre; }

    public void grabItem()
    {
        this.gameObject.SetActive(false);
        Debug.Log("J'attrape cet item " + gameObject.name + " depuis le script Item");
    }
    public void dropItem(Vector3 pos, Vector3 dir)
    {
        Vector3 posY = new Vector3(pos.x, pos.y+0.5f, pos.z);
        this.gameObject.transform.position = posY+dir*1.5f;
        this.gameObject.SetActive(true);
        Debug.Log("Je dépose cet item " + gameObject.name + " depuis le script Item");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    
}
