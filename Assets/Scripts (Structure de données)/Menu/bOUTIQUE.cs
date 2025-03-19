using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bOUTIQUE : MonoBehaviour
{

    void Start()
    {
        Grid(); // Remplit la grille au démarrage
    }
    void Grid()
    {
        for (int i = 0; i < 30; i++) // Par exemple, 33 trophées
        {
            // Instancier une carte
            GameObject card = Instantiate(cardPrefab, gridParent);

            // Modifier son apparence selon l'état verrouillé/déverrouillé
            Image cardImage = card.GetComponent<Image>();
            bool isUnlocked = CheckIfUnlocked(i); // Détermine si le trophée est déverrouillé
            cardImage.sprite = isUnlocked ? GetUnlockedSprite(i) : lockedSprite;


            int index = i; // Copie locale pour éviter des problèmes de portée
            card.GetComponent<Button>().onClick.AddListener(() => OnCardClicked(card, index));
        }
    }

}
