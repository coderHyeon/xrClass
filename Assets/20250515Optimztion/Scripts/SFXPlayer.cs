//using UnityEngine;

//public class SFXPlayer : MonoBehaviour
//{
//    private AudioSource audioSource = null;
//    public bool IsActive {
//        get { return gameObject.activeSelf; }
//     }
//    private void Awake()
//    {
//        audioSource = GetComponent<AudioSource>();
//    }
//    public void Play(AudioClip _clip)
//    {
//        gameObject.SetActive(true);

//        audioSource.clip = _clip;
//        audioSource.Play();



//    }
//    private void Deactivate()
//    {
//        gameObject.SetActive(false);
//    }
//}

using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    private AudioSource audioSource = null;

    public bool IsActive
    {
        get { return gameObject.activeSelf; }
    }


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Play(AudioClip _clip)
    {
        gameObject.SetActive(true);

        audioSource.clip = _clip;
        audioSource.Play();

        Invoke("Deactivate", audioSource.clip.length);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}