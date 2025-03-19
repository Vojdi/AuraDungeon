
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]List<GameObject> rooms;

    GameObject currentRoom;
    Vector3[] possibleGeneratingValues = new Vector3[] {new Vector3(50,0,0),new Vector3(0,0,-50) };

    [SerializeField]List<EnemyStats> possibleEnemiesToGenerate;
    List<EnemyStats> currentRoomEnemies = new List<EnemyStats>();
    
    int danger = 2;
   
    private void Awake()
    {
        Time.timeScale = 0;
        LoadFirstRoom();

    }
    void Start()
    {
        GenerateNextRoom();   
    }

    

    private void LoadFirstRoom()
    {
        GameObject firstRoom = rooms[1];
        Instantiate(firstRoom, new Vector3(0, 0, 0), Quaternion.identity);
        currentRoom = firstRoom;
        Time.timeScale = 1;
    }
    private void GenerateNextRoom()
    {
        GameObject roomType = rooms[Random.Range(0, rooms.Count)];
        Instantiate(roomType, currentRoom.transform.position + possibleGeneratingValues[Random.Range(0, 2)],Quaternion.identity);
        currentRoom = roomType;
        CalculateSpawnEnemies();

    }
    private void CalculateSpawnEnemies()
    {
        int currentDanger = 0;
        for (int i = 0;i < 10;i++ )
        {
            EnemyStats potentialEnemy = possibleEnemiesToGenerate[Random.Range(0, possibleEnemiesToGenerate.Count)];
            int potentialDanger = potentialEnemy.DangerValue + currentDanger;
            if (currentDanger == danger)
            {
                break;
            }
            else if (potentialDanger <= danger)
            {
                currentDanger += potentialEnemy.DangerValue;
                currentRoomEnemies.Add(potentialEnemy);
            }
        }
    }
}
