//using System.Collections.Generic;
//using UnityEngine;

//public class AudioController : MonoBehaviour
//{
//    [SerializeField] private GameObject sfxPlayerPrefab = null;
//    [SerializeField] private AudioClip[] sfxList = null;

//    private AudioSource audioSource = null;

//    //OBject Pooling 풀에다가 여러개 만들어두고 썼다가 껐다가 해서 생산하거나 파괴하는 비용을 줄임
//    private List<SFXPlayer> sfxPlayerPool = new List<SFXPlayer>();

//    private void Awake()
//    {
//        audioSource = GetComponent<AudioSource>();
//    }
//    private void Update()
//    {
//        if (Input.GetMouseButtonDown(0))
//            {
//            //audioSource.PlayOneShot(sfxList[Random.Range(0, sfxList.Length - 1)]); //원래는 이넘만들어서 걸을 때 걷는 소리나도록 총쏠때 총소리나도록
//            PlaySFX(sfxList[Random.Range(0, sfxList.Length - 1)]);
//            }
//    }

//    private void PlaySFX(AudioClip _clip)
//    {
//        SFXPlayer sfxPlayer = null;
//        if(sfxPlayerPool.Count == 0)
//        {
//            sfxPlayer = CreateSFXPlayer();
//            sfxPlayerPool.Add(sfxPlayer);
//        }
//        else
//        {
//            foreach (SFXPlayer sfx in sfxPlayerPool)
//            {
//                if (!sfx.IsActive)
//                {
//                    sfxPlayer = sfx;
//                    break;
//                }
//            }
//            if(sfxPlayer == null)
//            {
//                sfxPlayer = CreateSFXPlayer();
//                sfxPlayerPool.Add(sfxPlayer);
//            }
//        }
//            sfxPlayer.Play(_clip);

//    }
//    private SFXPlayer CreateSFXPlayer()
//    {
//        GameObject sfxGo =
//                Instantiate(sfxPlayerPrefab);
//        sfxGo.transform.SetParent(transform);
//        return sfxGo.GetComponent<SFXPlayer>();
//    }
//}
////////////////////////////////////////////////////////////////////////
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private GameObject sfxPlayerPrefab = null;
    [SerializeField] private AudioClip[] sfxList = null;

    private AudioSource audioSource = null;

    // Object Pooling
    private List<SFXPlayer> sfxPlayerPool =
        new List<SFXPlayer>();


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //audioSource.PlayOneShot(
            //    sfxList[Random.Range(0, sfxList.Length - 1)]);
            PlaySFX(
                sfxList[Random.Range(0, sfxList.Length - 1)]);
        }
    }

    private void PlaySFX(AudioClip _clip)
    {
        SFXPlayer sfxPlayer = null;
        if (sfxPlayerPool.Count == 0)
        {
            sfxPlayer = CreateSFXPlayer();
            sfxPlayerPool.Add(sfxPlayer);
        }
        else
        {
            foreach (SFXPlayer sfx in sfxPlayerPool)
            {
                if (!sfx.IsActive)
                {
                    sfxPlayer = sfx;
                    break;
                }
            }

            if (sfxPlayer == null)
            {
                sfxPlayer = CreateSFXPlayer();
                sfxPlayerPool.Add(sfxPlayer);
            }
        }

        sfxPlayer.Play(_clip);
    }

    private SFXPlayer CreateSFXPlayer()
    {
        GameObject sfxGo =
                Instantiate(sfxPlayerPrefab);
        sfxGo.transform.SetParent(transform);
        return sfxGo.GetComponent<SFXPlayer>();
    }
}