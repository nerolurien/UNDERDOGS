namespace EJETAGame
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class InteractionTEST : MonoBehaviour, IInteractable
    {
        public KeyCode interactionKey = KeyCode.E;

        // Jumlah skor yang ditambahkan saat item diambil
        public static int currentScoreAmount = 0;

        public static bool pickedUp = false;

        public void Interact()
        {
            if (InteractionTrashCan.isTrashCanTaken)
            {
                Debug.Log("Tangan penuh! Tong sampah sudah diambil.");
                InteractionText.instance.SetText("Tangan penuh! Tong sampah sudah diambil.");
                return;
            }

            if (!pickedUp && Input.GetKeyDown(interactionKey))
            {
                pickedUp = true;
                Debug.Log("Item Picked Up");

                gameObject.SetActive(false);
                Destroy(this); // opsional
            }
            else if (pickedUp)
            {
                Debug.Log("Item already picked up");
            }
        }

        public void OnInteractEnter()
        {
            if (InteractionTrashCan.isTrashCanTaken)
            {
                InteractionText.instance.SetText("Tangan penuh! Tong sampah sudah diambil.");
            }
            else if (!pickedUp)
            {
                InteractionText.instance.SetText("Press " + interactionKey + " to pick up");
            }
            else
            {
                InteractionText.instance.SetText("Item already picked up");
            }
        }

        public void OnInteractExit()
        {
            InteractionText.instance.HideText();
            Debug.Log("Interaction Ended");
        }
    }
}
