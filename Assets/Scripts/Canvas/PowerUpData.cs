using UnityEngine;

public class PowerUpData
{
    public string powerUpType;
    public float powerUpValue;
    public Sprite powerUpSprite;
    public string powerUpDescription;

    public PowerUpData(string powerUpType, float powerUpValue, Sprite powerUpImage, string powerUpDescription)
    {
        this.powerUpType = powerUpType;
        this.powerUpValue = powerUpValue;
        this.powerUpSprite = powerUpImage;
        this.powerUpDescription = powerUpDescription;
    }
}
