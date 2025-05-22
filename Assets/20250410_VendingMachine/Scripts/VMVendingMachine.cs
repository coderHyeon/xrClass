////using UnityEditor;
////using UnityEngine;
////using static VMPlayer;

////public class VMVendingMachine : MonoBehaviour
////{
////    public enum EItemType { RedPotion, BulePotion, YelloPotion, PurpplePtion }
////    //��ǰ��, ��ǰ���, ��ǰ���� -> ����ü

////    [System.Serializable]
////    public struct SItem
////    {
////        public EItemType itemType;
////        public int price;
////        public int stock;
////        //����ü�� �������� ��ü�� �����ʿ� ����
////        //��ƿ��Ƽ �Լ� ��ƿ��Ƽ �޼ҵ�
////        public static string TypeToString(EItemType _itemType)
////        {
////            switch (_itemType)
////                {
////                case EItemType.RedPotion: return "������";
////                case EItemType.BulePotion: return "�Ķ���";
////                case EItemType.YelloPotion: return "�����";
////                case EItemType.PurpplePtion: return "qhfkdir";
////            }
////            return "����";
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
//                case EItemType.RedPotion: return "������";
//                case EItemType.BluePotion: return "�Ķ���";
//                case EItemType.YellowPotion: return "�����";
//                case EItemType.PurplePotion: return "�����";
//            }

//            return "����";
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
//        float theta = Random.Range(0f, 360f); // ��Ÿ
//        float distance = 2f;
//        Vector3 potionPos = new Vector3(
//            Mathf.Cos(theta), 0f, Mathf.Sin(theta)
//            ) * distance;//�ﰢ�Լ��� ������ ����? �Ǳ��̸� 1�� �������� �������
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
                case EItemType.RedPotion: return "������";
                case EItemType.BluePotion: return "�Ķ���";
                case EItemType.YellowPotion: return "�����";
                case EItemType.PurplePotion: return "�����";
            }

            return "����";
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