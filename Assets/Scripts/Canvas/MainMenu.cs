using NUnit.Framework;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenuGj;
    [SerializeField] GameObject mainMenuOtherGraphicsGj;

    [SerializeField] GameObject characterSelectionScreenGj;
    [SerializeField] TMPro.TMP_Text[] texts;
    [SerializeField] TMPro.TMP_Text checkBoxText;

    [SerializeField] Toggle immortalityCheckBox;
    [SerializeField] TMPro.TMP_Text beginButtonText;
    [SerializeField] Button beginButton;
    
    [SerializeField] Button[] buttons;

    [SerializeField] GameObject shopGj;
    [SerializeField] TMPro.TMP_Text auronsText;
    [SerializeField] TMPro.TMP_Text[] shopButtons;
    [SerializeField] GameObject[] miscStuff;
    [SerializeField] TMPro.TMP_Text mostRoomsText;

    string lettersPressed = "";
    string lettersNeeded = "skibidi";
    


    int money;
    bool chosen = false;

    // Your color settings
    Color selectedColor = new Color32(0xF5, 0xF5, 0xF5, 0xFF);   // #F5F5F5
    Color deselectedColor = new Color32(0x6B, 0x6A, 0x6A, 0xFF); // #6B6A6A
    private void Awake()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 1;
        Time.timeScale = 1;

        int mostRoomsCount = PlayerPrefs.GetInt("MostRooms");
        mostRoomsText.text = $"Highest room: {mostRoomsCount}";
    }

    void Update()
    {
        foreach (char c in lettersNeeded)
        {
            if (Input.GetKeyDown(c.ToString()))
            {
                lettersPressed += c;

                if (lettersPressed.Length > lettersNeeded.Length)
                {
                    lettersPressed = lettersPressed.Substring(lettersPressed.Length - lettersNeeded.Length);
                }

                if (lettersPressed == lettersNeeded)
                {
                    TriggerCombo();
                    lettersPressed = ""; 
                }

                break; 
            }
        }
    }

    private void TriggerCombo()
    {
        money = PlayerPrefs.GetInt("Money");
        money += 200;
        PlayerPrefs.SetInt("Money", money);
        auronsText.text = money.ToString();
    }

    public void StartGame()
    {
        if (chosen)
        {
            if(immortalityCheckBox.isOn == true)
            {
                PlayerPrefs.SetString("Immortality", "true");
            }
            else
            {
                PlayerPrefs.SetString("Immortality", "false");
            }
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoToCharacterSelection()
    {

        foreach (var button in buttons)
        {
            var colors = button.colors; // copy the full struct first
            colors.normalColor = deselectedColor; // modify the copy
            button.colors = colors; // assign the modified struct back
        }

        mainMenuGj.SetActive(false);
        mainMenuOtherGraphicsGj.SetActive(false);
        characterSelectionScreenGj.SetActive(true);
        foreach (var button in texts)
        {
            button.text = "";
        }
       
        chosen = false;
        beginButtonText.text = "Choose your Character first!";
        beginButton.interactable = false;
        
        if(PlayerPrefs.GetString("Thief") != "true")
        {
            buttons[1].interactable = false;
            texts[1].text = "Locked";
        }
        else
        {
            buttons[1].interactable = true;
        }
        if (PlayerPrefs.GetString("Heavy") != "true")
        {
            buttons[2].interactable = false;
            texts[2].text = "Locked";
        }
        else
        {
            buttons[2].interactable = true;
        }
        if(PlayerPrefs.GetString("ImmortalityOwned") != "true")
        {
            checkBoxText.text = "Locked";
            immortalityCheckBox.gameObject.SetActive(false);
        }
        else
        {
            checkBoxText.text = "immortality";
            immortalityCheckBox.gameObject.SetActive(true);
        }
    }

    public void ReturnToMainMenu()
    {
        mainMenuGj.SetActive(true);
        mainMenuOtherGraphicsGj.SetActive(true);
        characterSelectionScreenGj.SetActive(false);
        shopGj.SetActive(false);
    }

    public void ChooseButtonClicked(int buttonId)
    {
        beginButton.interactable = true;
        for (int i = 0; i < texts.Length; i++)
        {
            if(texts[i].text != "Locked")
            {
                texts[i].text = "";
            }
        }

        // Set selected label
        texts[buttonId].text = "Selected";
        PlayerPrefs.SetInt("charId", buttonId);
        chosen = true;
        beginButtonText.text = "Begin";

        // Update button colors manually
        for (int i = 0; i < buttons.Length; i++)
        {
            var colors = buttons[i].colors;
            colors.normalColor = (i == buttonId) ? selectedColor : deselectedColor;
            buttons[i].colors = colors;
        }
    }
    public void GoToShop()
    {
        
        mainMenuGj.SetActive(false);
        mainMenuOtherGraphicsGj.SetActive(false);
        shopGj.SetActive(true);
        money = PlayerPrefs.GetInt("Money");
        auronsText.text = money.ToString();
        if (PlayerPrefs.GetString("Thief") == "true")
        {
            shopButtons[0].text = "Owned";
            miscStuff[0].SetActive(false);
            shopButtons[0].GetComponent<Button>().interactable = false;
        }
        if (PlayerPrefs.GetString("Heavy") == "true")
        {
            shopButtons[1].text = "Owned";
            miscStuff[1].SetActive(false);
            shopButtons[1].GetComponent<Button>().interactable = false;
        }
        if (PlayerPrefs.GetString("ImmortalityOwned") == "true")
        {
            shopButtons[2].text = "Owned";
            miscStuff[2].SetActive(false);
            shopButtons[2].GetComponent<Button>().interactable = false;
        }
    }
    public void BuyThief()
    {
        if(money >= 20)
        {
            money -= 20;
            auronsText.text = money.ToString();
            PlayerPrefs.SetInt("Money", money);
            PlayerPrefs.SetString("Thief", "true");
            shopButtons[0].text = "Owned";
            miscStuff[0].SetActive(false);
            shopButtons[0].GetComponent<Button>().interactable = false;
        }
    }
    public void BuyHeavy()
    {
        if (money >= 20)
        {
            money -= 20;
            auronsText.text = money.ToString();
            PlayerPrefs.SetInt("Money", money);
            PlayerPrefs.SetString("Heavy", "true");
            shopButtons[1].text = "Owned";
            miscStuff[1].SetActive(false);
            shopButtons[1].GetComponent<Button>().interactable = false;
        }
    }
    public void BuyImmortality()
    {
        if (money >= 50)
        {
            money -= 50;
            auronsText.text = money.ToString();
            PlayerPrefs.SetInt("Money", money);
            PlayerPrefs.SetString("ImmortalityOwned", "true");
            shopButtons[2].text = "Owned";
            miscStuff[2].SetActive(false);
            shopButtons[2].GetComponent<Button>().interactable = false;
        }
    }
}
