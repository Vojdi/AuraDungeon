using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    [SerializeField] Image powerUpImageObject;
    [SerializeField] TMPro.TMP_Text powerUpDescriptionObject;

    private string powerUpType;
    private float powerUpValue;
    public void SetUp()
    {
        PowerUpData pu = PowerUpScreen.Instance.GetPowerUp();
        powerUpImageObject.sprite = pu.powerUpSprite;
        powerUpDescriptionObject.text = pu.powerUpDescription;
        powerUpType = pu.powerUpType;
        powerUpValue = pu.powerUpValue; 
    }
    public void PowerUpChosen()
    {
       PowerUpScreen.Instance.SetChosenPowerUp(powerUpType, powerUpValue);
    }
}
