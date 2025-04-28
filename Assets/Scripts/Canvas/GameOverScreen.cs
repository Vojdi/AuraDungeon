using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] GameObject[] unnecessary;
    [SerializeField] GameObject mainPanel;
    [SerializeField] TMPro.TMP_Text roomCountPanel;
    [SerializeField] TMPro.TMP_Text auronCountPanel;
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
        foreach (var u in unnecessary) {
            u.SetActive(false); 
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
