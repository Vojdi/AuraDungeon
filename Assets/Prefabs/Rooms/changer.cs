using UnityEngine;
using UnityEditor;

[ExecuteInEditMode] // Ensures script runs in Edit Mode
public class Changer : MonoBehaviour
{
    [SerializeField] private Material material1;
    [SerializeField] private Material material2;
    [SerializeField] private GameObject parrentG;

    private void Start()
    {
        

        

       

        // Change materials in all children
        foreach (Transform child in parrentG.transform)
        {
            Renderer childRenderer = child.GetComponent<Renderer>();
            if (childRenderer != null && childRenderer.sharedMaterial == material1)
            {
                childRenderer.sharedMaterial = material2;
                Debug.Log($"✅ Changed material in: {child.name}");
            }
        }

#if UNITY_EDITOR
        if (!Application.isPlaying)
        {
            SavePrefab(transform.gameObject);
        }
        else
        {
            Debug.LogWarning("⚠ Prefab modifications should be done in Edit Mode, not Play Mode.");
        }
#endif
    }

#if UNITY_EDITOR
    private void SavePrefab(GameObject prefabInstance)
    {
        GameObject prefabAsset = PrefabUtility.GetCorrespondingObjectFromSource(prefabInstance);
        Debug.Log($"🔍 Prefab Asset: {prefabAsset}");

        if (prefabAsset == null)
        {
            Debug.LogWarning("⚠ transform.gameObject is not a prefab instance.");
            return;
        }

        string prefabPath = AssetDatabase.GetAssetPath(prefabAsset);
        Debug.Log($"📂 Prefab Path: {prefabPath}");

        if (!string.IsNullOrEmpty(prefabPath))
        {
            PrefabUtility.SaveAsPrefabAssetAndConnect(prefabInstance, prefabPath, InteractionMode.UserAction);
            Debug.Log("✅ Prefab saved successfully at: " + prefabPath);
        }
        else
        {
            Debug.LogWarning("⚠ Failed to get prefab path. Make sure transform.gameObject is a prefab.");
        }
    }
#endif
}

