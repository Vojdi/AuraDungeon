using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenuGj;
    [SerializeField] GameObject mainMenuOtherGraphicsGj;

    [SerializeField] GameObject characterSelectionScreenGj;

    [SerializeField] TMPro.TMP_Text[] texts;
    [SerializeField] TMPro.TMP_Text beginButtonText;
    [SerializeField] Button[] buttons;

    bool Chosen = false;
    public void StartGame()
    {
        if (Chosen)
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void GoToCharacterSelection()
    {
        mainMenuGj.SetActive(false);
        mainMenuOtherGraphicsGj.SetActive(false);
        characterSelectionScreenGj.SetActive(true);
        foreach (var button in texts)
        {
            button.text = "";
        }
        Chosen = false;
        beginButtonText.text = "Choose your Character first!";
    }
    public void ReturnToMainMenu()
    {
        mainMenuGj.SetActive(true);
        mainMenuOtherGraphicsGj.SetActive(true);
        characterSelectionScreenGj.SetActive(false);
    }
    public void ChooseButtonClicked(int buttonId)
    {
        
            
        
        foreach (var text in texts) {
            text.text = "";
        }
        texts[buttonId].text = "Selected";
        PlayerPrefs.SetInt("charId", buttonId);
        Chosen = true;
        beginButtonText.text = "Begin";
        buttons[buttonId].Select();
    }

}
