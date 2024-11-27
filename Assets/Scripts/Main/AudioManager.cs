using Unity.VisualScripting;
using UnityEngine;

internal class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    internal static AudioManager Instance { get { return instance; } private set { instance = value; } }

    [SerializeField] private AudioClip clickSound;

    private void Awake()
    {
        instance = this;
    }

    private void PlayUISound(AudioClip clip)
    {
        AudioSource audioSource = PersistentGameObject.Instance.AddComponent<AudioSource>();
        audioSource.PlayOneShot(clip);
        Destroy(gameObject, clip.length);
    }

    public void PlayClickSound() => PlayUISound(clickSound);
}
