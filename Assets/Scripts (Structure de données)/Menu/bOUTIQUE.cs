using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bOUTIQUE : MonoBehaviour
{

    void Start()
    {
        Grid(); // Remplit la grille au d�marrage
    }
    void Grid()
    {
        for (int i = 0; i < 30; i++) // Par exemple, 33 troph�es
        {
            // Instancier une carte
            GameObject card = Instantiate(cardPrefab, gridParent);

            // Modifier son apparence selon l'�tat verrouill�/d�verrouill�
            Image cardImage = card.GetComponent<Image>();
            bool isUnlocked = CheckIfUnlocked(i); // D�termine si le troph�e est d�verrouill�
            cardImage.sprite = isUnlocked ? GetUnlockedSprite(i) : lockedSprite;


            int index = i; // Copie locale pour �viter des probl�mes de port�e
            card.GetComponent<Button>().onClick.AddListener(() => OnCardClicked(card, index));
        }
    }

}
