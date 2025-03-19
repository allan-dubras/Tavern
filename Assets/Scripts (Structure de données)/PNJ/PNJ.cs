using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PNJ : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject panel;
    public Image img;

    public GameObject stock;
    public GameObject Joueur;

    public bool active;
    public bool triggerActive;

    void Start()
    {
        active = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = true;
            text.text = "Appuyer sur A  pour avoir une quête";
        }
        if (other.GetComponent<Item>() != null && other.GetComponent<Item>().nom == stock.GetComponent<Item>().nom)
        {
            other.gameObject.SetActive(false);
            panel.SetActive(false);
            GameObject.Find("NPCManager").GetComponent<NPCManager>().nextNPC = true;
            Destroy(this.gameObject.transform.root.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        triggerActive = false;
        text.text = "";
    }

    void Update()
    {
        if (triggerActive == true)
        {
            if (Input.GetKeyDown(KeyCode.Q) && active == true)
            {
                text.enabled=false;
                text.text = "";
                active = false;
                panel.SetActive(true);
                List<GameObject> listobjet = Outils.GetAllChildren(GameObject.Find("item").transform);
                int randomisee = Random.Range(0, listobjet.Count);
                GameObject objectrandom = listobjet[randomisee];
                stock = listobjet[randomisee];
                img.sprite = objectrandom.GetComponent<Item>().icone;
            }
        }
    }
}
