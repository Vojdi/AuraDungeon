
using UnityEngine;

public class MiscInfoUpdate : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text roomCounter;
    [SerializeField] TMPro.TMP_Text enhanceCounter;
    static MiscInfoUpdate instance;
    public static MiscInfoUpdate Instance => instance;

    private void Awake()
    {
        instance = this;       
    }
    public void UpdateRoomCount(int roomCount)
    {
        roomCounter.text = $"Rooms survived: {roomCount}";
    }
    public void UpdateEnhanceCount(int enhanceCount)
    {
        enhanceCounter.text = $"Enemies Enhanced: {enhanceCount}x";
    }
}
