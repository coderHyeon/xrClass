//using System.Collections.Generic;
//using UnityEngine;

//public class AudioController : MonoBehaviour
//{
//    [SerializeField] private GameObject sfxPlayerPrefab = null;
//    [SerializeField] private AudioClip[] sfxList = null;

//    private AudioSource audioSource = null;

//    //OBject Pooling Ǯ���ٰ� ������ �����ΰ� ��ٰ� ���ٰ� �ؼ� �����ϰų� �ı��ϴ� ����� ����
//    private List<SFXPlayer> sfxPlayerPool = new List<SFXPlayer>();

//    private void Awake()
//    {
//        audioSource = GetComponent<AudioSource>();
//    }
//    private void Update()
//    {
//        if (Input.GetMouseButtonDown(0))
//            {
//            //audioSource.PlayOneShot(sfxList[Random.Range(0, sfxList.Length - 1)]); //������ �̳Ѹ��� ���� �� �ȴ� �Ҹ������� �ѽ� �ѼҸ�������
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