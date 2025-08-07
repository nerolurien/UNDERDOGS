using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Replace "GameScene" with your actual game scene name
        SceneManager.LoadScene("game1");
    }
    
    public void OpenOptions()
    {
        // You can either load an options scene or show/hide a panel
        SceneManager.LoadScene("OptionsScene");
    }
    
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}