using UnityEngine;

public class TrashPickup : MonoBehaviour, IInteractable
{
    private bool isPickedUp = false;

    public void Interact()
    {
        if (!isPickedUp)
        {
            isPickedUp = true;

            Debug.Log("Kamu mengambil sampah!");
            // Bisa tambahkan efek, suara, atau animasi di sini

            Destroy(gameObject); // Hapus item dari scene setelah diambil
        }
        else
        {
            Debug.Log("Sudah diambil.");
        }
    }
}
