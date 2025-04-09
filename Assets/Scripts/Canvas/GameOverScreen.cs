using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] GameObject healthBarGraphics;
    [SerializeField] GameObject auraBarGraphics;
    [SerializeField] GameObject mainPanel;
    [SerializeField] TMPro.TMP_Text roomCountPanel;
    private static GameOverScreen instance;
    public static GameOverScreen Instance => instance;

    void Start()
    {
        instance = this;
    }
    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu"); 
    }
    public void Enable(int roomCount)
    {
       
        Time.timeScale = 0;
        healthBarGraphics.SetActive(false);
        auraBarGraphics.SetActive(false);
        mainPanel.SetActive(true);
        roomCountPanel.text = $"You have successfully survived {roomCount.ToString()} rooms";
    }
    
}
