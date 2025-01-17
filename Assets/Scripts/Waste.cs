
using UnityEngine;

public class Waste : MonoBehaviour
{
    public static Waste Instance;
    private void Start()
    {
        Instance = this;
    }
}
