using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        // Replace "SampleScene" with the exact name of your main game scene
        SceneManager.LoadScene("SampleScene");
    }
}