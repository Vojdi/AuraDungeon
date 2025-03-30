

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    [SerializeField] List<GameObject> rooms;

    public GameObject currentRoom;
    GameObject previousRoom;

    Vector3[] possibleGeneratingValues = new Vector3[] { new Vector3(50, 0, 0), new Vector3(0, 0, -50) };
    Vector3[] roomCornerValues = new Vector3[] { new Vector3(20, 0, 20), new Vector3(20, 0, -20), new Vector3(-20, 0, -20), new Vector3(-20, 0, 20) };
    int currentRoomCornerIndex = 0;

    [SerializeField] List<EnemyStats> possibleEnemiesToGenerate;
    List<EnemyStats> currentRoomEnemiesToSpawn = new List<EnemyStats>();
    List<GameObject> currentSpawnedEnemies = new List<GameObject>();

    int roomCount;
    int danger = 2;
    bool destroyRoom = false;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 0;
        LoadFirstRoom();

    }
    void Start()
    {
        roomCount = -1;
        GenerateNextRoom();
    }
    private void LoadFirstRoom()
    {
        var instantiatedRoom = Instantiate(rooms[1], new Vector3(0, 0, 0), Quaternion.identity);
        instantiatedRoom.GetComponentInChildren<Collider>().enabled = false;
        currentRoom = instantiatedRoom;
        Time.timeScale = 1;
        instantiatedRoom.GetComponentInChildren<WallsHandler>().DeactivateWalls();
    }
    private void GenerateNextRoom()
    {
        roomCount++;
        previousRoom = currentRoom;
        GameObject roomType = rooms[Random.Range(0, rooms.Count)];
        //Vector3 loc = currentRoom.transform.position + possibleGeneratingValues[Random.Range(0, 2)];//
        //loc.y += 50;//
        //var instantiatedRoomType = Instantiate(roomType, loc, Quaternion.identity);//
        //instantiatedRoomType.GetComponent<Animator>().Play("drop");//
        var instantiatedRoomType = Instantiate(roomType, currentRoom.transform.position + possibleGeneratingValues[Random.Range(0, 2)], Quaternion.identity);
        currentRoom = instantiatedRoomType;
        CalculateSpawnEnemies();
    }
    private void CalculateSpawnEnemies()
    {
        int currentDanger = 0;
        for (; ; )
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
                currentRoomEnemiesToSpawn.Add(potentialEnemy);
            }
        }
    }
    public void DropPrevRoom()
    {
        Destroy(previousRoom);
        //previousRoom.GetComponent<Animator>().Play("drop");//
        //destroyRoom = true;
    }
    /*public void DestroyIfNecessary()
    {
        if (destroyRoom) { 
            Destroy(previousRoom);
            destroyRoom = false;
        }
    }*/
    public void EnemyDied(GameObject enemy)
    {
        currentSpawnedEnemies.Remove(enemy);
        if (currentSpawnedEnemies.Count == 0)
        {
            currentRoom.GetComponentInChildren<WallsHandler>().DeactivateWalls();
            danger++;
            PowerUp();
            GenerateNextRoom();
        }
    }
    public void SpawnEnemies()
    {
        StartCoroutine(SpawnRoomEnemy());
    }
    private IEnumerator SpawnRoomEnemy()
    {
        for (int i = 0; i < currentRoomEnemiesToSpawn.Count; i++)
        {
            int indexOfClosest = getIndexOfClosestRoomCorner();
            if (currentRoomCornerIndex == indexOfClosest)
            {
                currentRoomCornerIndex++;
                if (currentRoomCornerIndex >= roomCornerValues.Length)
                {
                    currentRoomCornerIndex = 0;
                }
            }
            else
            {
                if (currentRoomCornerIndex >= roomCornerValues.Length)
                {
                    currentRoomCornerIndex = 0;
                }
            }
            Vector3 spawnPosition = currentRoom.transform.position + roomCornerValues[currentRoomCornerIndex];
            spawnPosition.y = 1;
            var en = Instantiate(currentRoomEnemiesToSpawn[i].gameObject, spawnPosition, Quaternion.identity);
            currentSpawnedEnemies.Add(en);
            currentRoomCornerIndex++;
            yield return new WaitForSeconds(1);
        }
        currentRoomEnemiesToSpawn.Clear();
    }
    private int getIndexOfClosestRoomCorner()
    {
        List<float> cornerDistances = new List<float>();
        for (int i = 0; i < roomCornerValues.Length; i++)
        {
            float cornerDistance = Vector3.Distance(PlayerMovement.PlayerPosition, roomCornerValues[i]);
            cornerDistances.Add(cornerDistance);
        }
        return cornerDistances.IndexOf(cornerDistances.Min());
    }
    public void GameOver()
    {
       
        GameOverScreen.Instance.Enable(roomCount);
    }
    private void PowerUp()
    {
        PowerUpScreen.Instance.Enable();
    }
}
