using UnityEngine;

public class RoomDropAnimationEvent : MonoBehaviour
{
    public void OnRoomDropEventEntered()
    {
        GameManager.Instance.DestroyIfNecessary();
    }
}
