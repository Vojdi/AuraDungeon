using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] Texture2D customCursor;
    Vector2 hotspot = Vector2.zero; // Adjust if the "click point" isn't center

    void Start()
    {
        Cursor.SetCursor(customCursor, new Vector2(customCursor.width / 2, customCursor.height / 2), CursorMode.Auto);
    }
}
