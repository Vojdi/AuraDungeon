using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] GameObject[] unnecessary;
    [SerializeField] GameObject mainPanel;
    [SerializeField] TMPro.TMP_Text roomCountPanel;
    [SerializeField] TMPro.TMP_Text auronCountPanel;
    [SerializeField] GameObject newHighScore;
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
    public void Enable(int roomCount, int currencyEarned)
    {
        
        Time.timeScale = 0;
        AudioManager.Instance.GameOver();
        foreach (var u in unnecessary) {
            u.SetActive(false); 
        }
        if (PlayerPrefs.GetString("Immortality") != "true")
        {
            if (roomCount + 1 > PlayerPrefs.GetInt("MostRooms"))
            {
                PlayerPrefs.SetInt("MostRooms", roomCount + 1);
                newHighScore.SetActive(true);
            }
            else
            {
                newHighScore.SetActive(false);
            }
        }
        else
        {
            newHighScore.SetActive(false);
        }
        mainPanel.SetActive(true);
        roomCountPanel.text = $"You have successfully survived {roomCount.ToString()} rooms";
        if(currencyEarned == 1)
        {
            auronCountPanel.text = $"Killed {currencyEarned} boss => {currencyEarned}";
        }
        else
        {
            auronCountPanel.text = $"Killed {currencyEarned} bosses => {currencyEarned}";
        }
        int currentTotalMoney = PlayerPrefs.GetInt("Money");
        currentTotalMoney += currencyEarned;
        PlayerPrefs.SetInt("Money", currentTotalMoney);

       
    }
    
}
