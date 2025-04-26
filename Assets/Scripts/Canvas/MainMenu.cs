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

    // Your color settings
    Color selectedColor = new Color32(0xF5, 0xF5, 0xF5, 0xFF);   // #F5F5F5
    Color deselectedColor = new Color32(0x6B, 0x6A, 0x6A, 0xFF); // #6B6A6A

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
        // Clear all selection text labels
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].text = "";
        }

        // Set selected label
        texts[buttonId].text = "Selected";
        PlayerPrefs.SetInt("charId", buttonId);
        Chosen = true;
        beginButtonText.text = "Begin";

        // Update button colors manually
        for (int i = 0; i < buttons.Length; i++)
        {
            var colors = buttons[i].colors;
            colors.normalColor = (i == buttonId) ? selectedColor : deselectedColor;
            buttons[i].colors = colors;
        }
    }
}
