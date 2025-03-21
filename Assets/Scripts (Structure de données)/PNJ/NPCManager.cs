using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class NPCManager : MonoBehaviour
{
    [SerializeField]
    private GameObject npcPrefab;
    [SerializeField]
    private Queue<GameObject> file;
    [SerializeField]
    private GameObject Spawner;
    [SerializeField]
    private GameObject goalposition;



    public GameObject stockM;
    public GameObject panelM;
    public TextMeshProUGUI textM;
    public Image imageM;
    public bool nextNPC;
    public GameObject player;

    public GameObject posbase;


    public GameObject nouvelleObjet;

    private Vector3 rot = new Vector3(0,180,0);

    private void Start()
    {
        //Instancier un objet 
        //GameObject nouvelleObjet=Instantiate(npcPrefab,Spawner.GetComponent<Transform>().position,Quaternion.Euler(rot));
        file=new Queue<GameObject>();

        for (int i = 0; i < 10; i++) 
        {
            nouvelleObjet = Instantiate(npcPrefab, Spawner.GetComponent<Transform>().position, Quaternion.Euler(rot));
            nouvelleObjet.name = "NPC"+i;
            Instancie(nouvelleObjet);
        }
        GameObject newObjet = file.Dequeue();
        newObjet.GetComponentInChildren<TargetNavMesh>().goal = goalposition;
    }
        void Instancie(GameObject nouvelleObjet)
        {
            nouvelleObjet.GetComponentInChildren<TargetNavMesh>().goal = posbase;
            nouvelleObjet.GetComponentInChildren<PNJ>().Joueur = player;
            nouvelleObjet.GetComponentInChildren<PNJ>().stock = stockM;
            nouvelleObjet.GetComponentInChildren<PNJ>().text = textM;
            nouvelleObjet.GetComponentInChildren<PNJ>().panel = panelM;
            nouvelleObjet.GetComponentInChildren<PNJ>().img = imageM;
            file.Enqueue(nouvelleObjet);
        }
    void auSuivant()
    {
        GameObject newObjet = file.Dequeue();
        newObjet.GetComponentInChildren<TargetNavMesh>().goal = goalposition;
    }
    public void Update()
    {

        if (nextNPC == true) 
        {
            auSuivant();
            nextNPC = false;
        }

    }
}
