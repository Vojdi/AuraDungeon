using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] GameObject healthBarGraphics;
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
        mainPanel.SetActive(true);
        healthBarGraphics.SetActive(false);
        roomCountPanel.text = $"You have survived {roomCount.ToString()} rooms";
    }
    private void UpdateRoomCount()
    {
        
    }
}
