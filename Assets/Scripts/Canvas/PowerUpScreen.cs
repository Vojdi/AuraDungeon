using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpScreen : MonoBehaviour
{
    private static PowerUpScreen instance;
    public static PowerUpScreen Instance => instance;
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject[] unnecessary;
    [SerializeField] List<Sprite> spriteList;
    [SerializeField] List<PowerUp> currentPowerUps;

    List<PowerUpData> currentPowerUpsToChoose = new List<PowerUpData>();
    List<PowerUpData> powerUpsDatas;
   
    

    private void Start()
    {
        instance = this;
        powerUpsDatas = new List<PowerUpData>() { 
            new PowerUpData("attackSpeed", 10, spriteList[0], "+10% ATK SPD"),  new PowerUpData("attackSpeed", 10, spriteList[0], "+10% ATK SPD"),  new PowerUpData("attackSpeed", 10, spriteList[0], "+10% ATK SPD"),  new PowerUpData("attackSpeed", 10, spriteList[0], "+10% ATK SPD"),  new PowerUpData("attackSpeed", 10, spriteList[0], "+10% ATK SPD"),
            new PowerUpData("attackDamage", 10, spriteList[1], "+10% ATK DMG"), new PowerUpData("attackDamage", 10, spriteList[1], "+10% ATK DMG"), new PowerUpData("attackDamage", 10, spriteList[1], "+10% ATK DMG"), new PowerUpData("attackDamage", 10, spriteList[1], "+10% ATK DMG"), new PowerUpData("attackDamage", 10, spriteList[1], "+10% ATK DMG"),
            new PowerUpData("attackRange", 10, spriteList[2], "+10% ATK RANGE"), new PowerUpData("attackRange", 10, spriteList[2], "+10% ATK RANGE"), new PowerUpData("attackRange", 10, spriteList[2], "+10% ATK RANGE"), new PowerUpData("attackRange", 10, spriteList[2], "+10% ATK RANGE"), new PowerUpData("attackRange", 10, spriteList[2], "+10% ATK RANGE"),
            new PowerUpData("movementSpeed", 10, spriteList[3],"+10% SPD"),new PowerUpData("movementSpeed", 10, spriteList[3],"+10% SPD"),new PowerUpData("movementSpeed", 10, spriteList[3],"+10% SPD"),new PowerUpData("movementSpeed", 10, spriteList[3],"+10% SPD"),new PowerUpData("movementSpeed", 10, spriteList[3],"+10% SPD"),
            new PowerUpData("projectileSpeed", 10, spriteList[4],"+10% PROJ SPD"), new PowerUpData("projectileSpeed", 10, spriteList[4],"+10% PROJ SPD"), new PowerUpData("projectileSpeed", 10, spriteList[4],"+10% PROJ SPD"), new PowerUpData("projectileSpeed", 10, spriteList[4],"+10% PROJ SPD"), new PowerUpData("projectileSpeed", 10, spriteList[4],"+10% PROJ SPD"),
            new PowerUpData("maxHp", 10, spriteList[5], "+10% MAX HP"),  new PowerUpData("maxHp", 10, spriteList[5], "+10% MAX HP"), new PowerUpData("maxHp", 10, spriteList[5], "+10% MAX HP"), new PowerUpData("maxHp", 10, spriteList[5], "+10% MAX HP"), new PowerUpData("maxHp", 10, spriteList[5], "+10% MAX HP"),

            new PowerUpData("attackSpeed", 20, spriteList[6], "+20% ATK SPD"),new PowerUpData("attackSpeed", 20, spriteList[6], "+20% ATK SPD"),new PowerUpData("attackSpeed", 20, spriteList[6], "+20% ATK SPD"),
            new PowerUpData("attackDamage", 20, spriteList[7], "+20% ATK DMG"),new PowerUpData("attackDamage", 20, spriteList[7], "+20% ATK DMG"),new PowerUpData("attackDamage", 20, spriteList[7], "+20% ATK DMG"),
            new PowerUpData("attackRange", 20, spriteList[8], "+20% ATK RANGE"), new PowerUpData("attackRange", 20, spriteList[8], "+20% ATK RANGE"), new PowerUpData("attackRange", 20, spriteList[8], "+20% ATK RANGE"),
            new PowerUpData("movementSpeed", 20, spriteList[9],"+20% SPD"), new PowerUpData("movementSpeed", 20, spriteList[9],"+20% SPD"), new PowerUpData("movementSpeed", 20, spriteList[9],"+20% SPD"),
            new PowerUpData("projectileSpeed", 20, spriteList[10],"+20% PROJ SPD"), new PowerUpData("projectileSpeed", 20, spriteList[10],"+20% PROJ SPD"),new PowerUpData("projectileSpeed", 20, spriteList[10],"+20% PROJ SPD"),
            new PowerUpData("maxHp", 20, spriteList[11], "+20% MAX HP"), new PowerUpData("maxHp", 20, spriteList[11], "+20% MAX HP"), new PowerUpData("maxHp", 20, spriteList[11], "+20% MAX HP"),

            new PowerUpData("attackSpeed", 30, spriteList[12], "+30% ATK SPD"),
            new PowerUpData("attackDamage", 30, spriteList[13], "+30% ATK DMG"),
            new PowerUpData("attackRange", 30, spriteList[14], "+30% ATK RANGE"),
            new PowerUpData("movementSpeed", 30, spriteList[15],"+30% SPD"),
            new PowerUpData("projectileSpeed", 30, spriteList[16],"+30% PROJ SPD"),
            new PowerUpData("maxHp", 30, spriteList[17], "+30% MAX HP"),
        };
    }
    public void Enable()
    {
        Time.timeScale = 0;
        mainPanel.SetActive(true);
        foreach(var u in unnecessary)
        {
            u.SetActive(false);
        }
        currentPowerUpsToChoose.Clear();    
        foreach (var currentPowerUp in currentPowerUps) {
            currentPowerUp.SetUp();
        }
    }
    public PowerUpData GetPowerUp()
    {
        int randomIndex;
        bool foundNew = false; 
        while (!foundNew)
        {
            randomIndex = Random.Range(0, powerUpsDatas.Count);
            foundNew = true;

            foreach (PowerUpData currentPowerUpToChoose in currentPowerUpsToChoose)
            {
                if (currentPowerUpToChoose.powerUpType == powerUpsDatas[randomIndex].powerUpType)
                {
                    foundNew = false; 
                    break; 
                }
            }
            if (foundNew)
            {
                currentPowerUpsToChoose.Add(powerUpsDatas[randomIndex]);
                return powerUpsDatas[randomIndex];
            }
        }
        return null;
    }
    public void SetChosenPowerUp(string type, float value)
    {
        mainPanel.SetActive(false);
        if(type == "attackSpeed")
        {
            PlayerStats.Instance.PowerUpAttackSpeed(value);
        }else if(type == "attackDamage")
        {
            PlayerStats.Instance.PowerUpAttackDamage(value);
        }else if(type == "attackRange")
        {
            PlayerStats.Instance.PowerUpAttackRange(value);
        }else if(type == "movementSpeed")
        {
            PlayerStats.Instance.PowerUpMovementSpeed(value);
        }else if(type == "projectileSpeed")
        {
            PlayerStats.Instance.PowerUpProjectileSpeed(value); 
        }else if(type == "maxHp")
        {
            PlayerStats.Instance.PowerUpMaxHp(value);
        }
        foreach(var u in unnecessary)
        {
            u.SetActive(true);
        }
        Time.timeScale = 1;
    }
}
