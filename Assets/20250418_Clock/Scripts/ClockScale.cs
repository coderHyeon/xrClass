using UnityEngine;
using System.Collections.Generic;

public class ClockScale : MonoBehaviour
{


}
//private void SpawnItem(EItemType _itemType)
//{
//    GameObject prefab = potionPrefabs[(int)_itemType];

//    GameObject potionGo = Instantiate(prefab);

//    float theta = Random.Range(0f, 360f);
//    float distance = 3f;
//    Vector3 potionPos = new Vector3(
//        Mathf.Cos(theta), 0f, Mathf.Sin(theta)
//        ) * distance;

//    potionGo.transform.position =
//        transform.position + potionPos;
//}

//private void CloseMenuCallback()
//{
//    videoPlayer.Stop();
//}

//using UnityEngine;

//public class MyClass : MonoBehaviour
//{
//    public GameObject prefab;
//    public Transform parent;
//    // Start is called before the first frame update
//    void Start()
//    {
//        GameObject myInstance = Instantiate(prefab); // 부모 지정 X
//                                                     //GameObject myInstance = Instantiate(prefab, parent); // 부모 지정
//    }
//}