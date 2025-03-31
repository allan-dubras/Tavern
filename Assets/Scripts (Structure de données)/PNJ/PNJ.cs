using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Sockets;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class PNJ : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject panel;
    public Image img;
    public TextMeshProUGUI textUi;

    public NPCManager NPCManager;
    public GameObject sortieNPC;
    public GameObject stock;
    public GameObject Joueur;

    public GameObject bloc;

    public bool active;
    public bool triggerActive;

    void Start()
    {
        textUi = GameObject.Find("TextUi").GetComponent<TextMeshProUGUI>();
        active = true;
        sortieNPC = sortieNPC = GameObject.Find("Sortie");
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
            Destroy(this.GetComponent<Collider>());
            text.text = "";
            textUi.text = "";
            Joueur.GetComponent<Inventaire>().argent+=other.GetComponent<Item>().Money;
            panel.SetActive(false);
            GameObject.Find("NPCManager").GetComponent<NPCManager>().nextNPC = true;
            this.GetComponent<TargetNavMesh>().goal = sortieNPC;
            StartCoroutine(wait());
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject.transform.root.gameObject);
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
                text.text = "";
                active = false;
                panel.SetActive(true);
                List<GameObject> listobjet = Outils.GetAllChildren(GameObject.Find("item").transform);
                int randomisee = Random.Range(0, listobjet.Count);
                GameObject objectrandom = listobjet[randomisee];
                stock = listobjet[randomisee];
                img.sprite = objectrandom.GetComponent<Item>().icone;
                textUi.text= objectrandom.GetComponent<Item>().nom;
            }
        }
    }
}
