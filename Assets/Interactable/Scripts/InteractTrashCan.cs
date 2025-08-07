using System.Collections;
using UnityEngine;

namespace EJETAGame
{
    public class InteractionTrashCan : MonoBehaviour, IInteractable
    {
        public KeyCode interactionKey = KeyCode.E;

        public int kapasitasSampah = 1;
        public int jumlahSampah = 0;

        public static bool isTrashCanTaken = false;
        private bool isDelivering = false;

        private void OnEnable()
        {
            jumlahSampah = 0;
            isDelivering = false;
            isTrashCanTaken = false;
        }

        public void HideTrashCan()
        {
            gameObject.SetActive(false);
        }

        public void Interact()
        {
            if (isDelivering) return;

            if (jumlahSampah >= kapasitasSampah)
            {
                if (InteractionTEST.pickedUp)
                {
                    Debug.Log("Tong sampah penuh!");
                    InteractionText.instance.SetText("Tong sampah penuh!");
                }
                else
                {
                    if (!isTrashCanTaken && Input.GetKeyDown(interactionKey))
                    {
                        Debug.Log("Ambil tong sampah!");
                        InteractionText.instance.SetText("Ambil tong sampah!");
                        isTrashCanTaken = true;
                        HideTrashCan();
                    }
                    else
                    {
                        InteractionText.instance.SetText("Ambil tong sampah!");
                    }
                }

                return;
            }

            if (InteractionTEST.pickedUp && Input.GetKeyDown(interactionKey))
            {
                Debug.Log("Item Delivered!");
                isDelivering = true;
                StartCoroutine(ReturnItem());
            }
            else if (!InteractionTEST.pickedUp)
            {
                Debug.Log("You don't have any item to deliver.");
                InteractionText.instance.SetText("You have nothing to deliver.");
            }
        }

        public void OnInteractEnter()
        {
            if (jumlahSampah >= kapasitasSampah)
            {
                if (InteractionTEST.pickedUp)
                {
                    InteractionText.instance.SetText("Tong sampah penuh!");
                }
                else
                {
                    InteractionText.instance.SetText("Ambil tong sampah!");
                }
            }
            else
            {
                if (InteractionTEST.pickedUp)
                {
                    InteractionText.instance.SetText("Press " + interactionKey + " to deliver item");
                }
                else
                {
                    InteractionText.instance.SetText("You have nothing to deliver");
                }
            }
        }

        public void OnInteractExit()
        {
            InteractionText.instance.HideText();
        }

        private IEnumerator ReturnItem()
        {
            yield return new WaitForSeconds(1f);

            jumlahSampah++;
            Debug.Log($"Sampah berhasil dikirim. Jumlah sekarang: {jumlahSampah}/{kapasitasSampah}");

            InteractionTEST.pickedUp = false;
            isDelivering = false;
        }
    }
}
