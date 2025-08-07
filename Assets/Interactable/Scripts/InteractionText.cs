namespace EJETAGame
{
    using TMPro;
    using UnityEngine;

    public class InteractionText : MonoBehaviour
    {
        public static InteractionText instance { get; private set; }

        public TextMeshProUGUI textAppear;

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject); // destroy gameobject, bukan komponen saja
            }
            else
            {
                instance = this;
            }

            HideText(); // Sembunyikan saat awal
        }

        public void SetText(string text)
        {
            if (textAppear != null)
            {
                textAppear.SetText(text);
                textAppear.gameObject.SetActive(true);
            }
        }

        public void HideText()
        {
            if (textAppear != null)
            {
                textAppear.gameObject.SetActive(false);
            }
        }
    }
}
