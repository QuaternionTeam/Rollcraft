using UnityEngine;

internal class PersistentGameObject : MonoBehaviour
{
    private static PersistentGameObject instance;
    internal static PersistentGameObject Instance { get { return instance != null ? instance : Instantiate(); } private set { instance = value; } }

    private static PersistentGameObject Instantiate()
    {
        PersistentGameObject persistenGameObject = new GameObject("PersistentGameObject").AddComponent<PersistentGameObject>();
        instance = persistenGameObject;
        return persistenGameObject;
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
