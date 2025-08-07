namespace EJETAGame
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;


   public class InteractionTruk : MonoBehaviour, IInteractable
{
    public KeyCode interactionKey = KeyCode.E;

    public GameObject trashCanObject; // Drag GameObject tong sampah langsung ke sini lewat Inspector
     public InteractionTrashCan trashCan;
    public void Interact()
{
    if (!InteractionTrashCan.isTrashCanTaken)
    {
        Debug.Log("Tidak ada tong sampah yang dibawa.");
        InteractionText.instance.SetText("Tidak ada tong sampah yang dibawa.");
        return;
    }

    if (Input.GetKeyDown(interactionKey))
    {
        Debug.Log("Tong sampah berhasil dikirim ke truk!");
        InteractionText.instance.SetText("Tong sampah berhasil dikirim!");

        // Reset status global
        InteractionTrashCan.isTrashCanTaken = false;

        // Tampilkan ulang objek tong sampah
        if (trashCanObject != null)
        {
            trashCanObject.SetActive(true);

            // Reset semua nilai dari InteractionTrashCan di sini
            trashCan.jumlahSampah = 0;
            trashCan.enabled = false; // aktifkan kembali kalau sempat dinonaktifkan
        }
    }
}


    public void OnInteractEnter()
    {
        if (InteractionTrashCan.isTrashCanTaken)
        {
            InteractionText.instance.SetText("Press " + interactionKey + " to deliver trash can");
        }
        else
        {
            InteractionText.instance.SetText("Tidak ada tong sampah yang dibawa");
        }
    }

    public void OnInteractExit()
    {
        InteractionText.instance.HideText();
    }
}
}