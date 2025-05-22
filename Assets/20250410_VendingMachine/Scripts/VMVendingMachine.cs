////using UnityEditor;
////using UnityEngine;
////using static VMPlayer;

////public class VMVendingMachine : MonoBehaviour
////{
////    public enum EItemType { RedPotion, BulePotion, YelloPotion, PurpplePtion }
////    //상품명, 상품재고, 상품가격 -> 구조체

////    [System.Serializable]
////    public struct SItem
////    {
////        public EItemType itemType;
////        public int price;
////        public int stock;
////        //구조체에 들어가있으면 객체를 만들필요 없음
////        //유틸리티 함수 유틸리티 메소드
////        public static string TypeToString(EItemType _itemType)
////        {
////            switch (_itemType)
////                {
////                case EItemType.RedPotion: return "빨간약";
////                case EItemType.BulePotion: return "파란약";
////                case EItemType.YelloPotion: return "노란약";
////                case EItemType.PurpplePtion: return "qhfkdir";
////            }
////            return "고장";
////        }
////    }

////    [SerializeField] private SItem[] items = null;
////    [SerializeField] private VMMenuCanvas menuCanvas = null;

////    public void Interaction()
////    {
////        menuCanvas.Init(items, OnClickButton);
////        menuCanvas.SetActive(true);
////    }
////    //private void Start()
////    //{
////    //    menuCanvas.Init(items, OnClickButton);
////    //    // menuCanvas.SetOnClickButtonCallBack(OnclickButton);
////    //    menuCanvas.SetActive(true);
////    //}
////    private void OnClickButton(VMButton _btn)
////    {
////        Debug.Log(_btn.gameObject.name);
////    }

////}

//using UnityEngine;
//using UnityEngine.Video;


//public class VMVendingMachine : MonoBehaviour
//{
//    public enum EItemType
//    {
//        BluePotion, PurplePotion, RedPotion, YellowPotion,
//    }

//    [System.Serializable]
//    public struct SItem
//    {
//        public EItemType itemType;
//        public int price;
//        public int stock;

//        // Utility Function, Utility Method
//        public static string TypeToString(EItemType _itemType)
//        {
//            switch (_itemType)
//            {
//                case EItemType.RedPotion: return "빨간약";
//                case EItemType.BluePotion: return "파란약";
//                case EItemType.YellowPotion: return "노란약";
//                case EItemType.PurplePotion: return "보라약";
//            }

//            return "고장";
//        }
//    }
//    public delegate void OnClickButtonDelegate(int _price);

//    [SerializeField] private SItem[] items = null;
//    [SerializeField] private VMMenuCanvas menuCanvas = null;

//    private GameObject[] potionPrefabs = null;
//    private OnClickButtonDelegate onClickButtonCallback = null;



//    public void Awake()
//    {
//        potionPrefabs = Resources.LoadAll<GameObject>("PrefabS\\Potions");
//    }
//    public void Interaction(
//        int _money,
//        OnClickButtonDelegate _onClickButtonCallback
//        )
//    {
//        menuCanvas.Init(items, _money, OnClickButton);
//        menuCanvas.SetActive(true);

//        onClickButtonCallback = _onClickButtonCallback;
//    }

//    private void OnClickButton(VMButton _btn)
//    {
//        Debug.Log(_btn.gameObject.name);
//        onClickButtonCallback?.Invoke(items[_btn.ItemIndex].price);
//        --items[_btn.ItemIndex].stock;
//        _btn.UpdateStock(items[_btn.ItemIndex].stock);
//        //vm.Iteraction(Info.money, OnClickButton);
//        SpawnItem(items[_btn.ItemIndex].itemType);
//    }
//    private void SpawnItem(EItemType _itemType)
//    {
//        GameObject prefab = potionPrefabs[(int)_itemType];
//        //GameObject prefab = null
//        //switch (_itemType)
//        //{
//        //    case EItemType.RedPotion:
//        //        prefab = potionPrefabs[2];
//        //        break;
//        //    case 
//        //}
//        GameObject potionGo = Instantiate(prefab);
//        float theta = Random.Range(0f, 360f); // 세타
//        float distance = 2f;
//        Vector3 potionPos = new Vector3(
//            Mathf.Cos(theta), 0f, Mathf.Sin(theta)
//            ) * distance;//삼각함수의 정의중 윗변? 의길이를 1인 기준으로 만들어짐
//        potionGo.transform.position =
//            transform.position + potionPos;
//    }
//    //private void CloseMenuCallback()
//    //{
//    //    VideoPlayer.Stop();
//    //}

//}
///////////////////////////////////////////////////////////////////////
using UnityEngine;

using UnityEngine.Video;

public class VMVendingMachine : MonoBehaviour
{
    public enum EItemType
    {
        BluePotion, PurplePotion, RedPotion, YellowPotion
    }

    [System.Serializable]
    public struct SItem
    {
        public EItemType itemType;
        public int price;
        public int stock;

        // Utility Function, Utility Method
        public static string TypeToString(EItemType _itemType)
        {
            switch (_itemType)
            {
                case EItemType.RedPotion: return "빨간약";
                case EItemType.BluePotion: return "파란약";
                case EItemType.YellowPotion: return "노란약";
                case EItemType.PurplePotion: return "보라약";
            }

            return "고장";
        }
    }

    public delegate void OnClickButtonDelegate(int _price);


    [SerializeField] private SItem[] items = null;
    [SerializeField] private VMMenuCanvas menuCanvas = null;

    private GameObject[] potionPrefabs = null;
    private VideoPlayer videoPlayer = null;

    private OnClickButtonDelegate onClickButtonCallback = null;


    public void Awake()
    {
        potionPrefabs =
            Resources.LoadAll<GameObject>("Prefabs\\Potions");
        videoPlayer = GetComponentInChildren<VideoPlayer>();
    }

    public void Start()
    {
        menuCanvas.SetCloseCallback(CloseMenuCallback);
    }

    public void Interaction(
        int _money,
        OnClickButtonDelegate _onClickButtonCallback)
    {
        menuCanvas.Init(items, _money, OnClickButton);
        menuCanvas.SetActive(true);

        onClickButtonCallback = _onClickButtonCallback;

        videoPlayer.Play();
    }

    private void OnClickButton(VMButton _btn)
    {
        Debug.Log(_btn.gameObject.name);

        onClickButtonCallback?.Invoke(items[_btn.ItemIndex].price);
        --items[_btn.ItemIndex].stock;
        _btn.UpdateStock(items[_btn.ItemIndex].stock);

        SpawnItem(items[_btn.ItemIndex].itemType);
    }

    private void SpawnItem(EItemType _itemType)
    {
        GameObject prefab = potionPrefabs[(int)_itemType];
        //switch (_itemType)
        //{
        //    case EItemType.RedPotion:
        //        prefab = potionPrefabs[2];
        //        break;
        //    case EItemType.BluePotion:
        //        prefab = potionPrefabs[0];
        //        break;
        //}
        GameObject potionGo = Instantiate(prefab);

        float theta = Random.Range(0f, 360f);
        float distance = 3f;
        Vector3 potionPos = new Vector3(
            Mathf.Cos(theta), 0f, Mathf.Sin(theta)
            ) * distance;

        potionGo.transform.position =
            transform.position + potionPos;
    }

    private void CloseMenuCallback()
    {
        videoPlayer.Stop();
    }
}