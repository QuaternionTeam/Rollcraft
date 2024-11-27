using Unity.VisualScripting;
using UnityEngine;

internal class AudioManager : MonoBehaviour
{
    public void PlayUISound(AudioClip clip)
    {
        AudioSource audioSource = PersistentGameObject.Instance.AddComponent<AudioSource>();
        audioSource.PlayOneShot(clip);
        Destroy(gameObject, clip.length);
    }
}
