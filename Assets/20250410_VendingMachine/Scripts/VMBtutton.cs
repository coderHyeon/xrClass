//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;

//public class VMButton : MonoBehaviour
//{
//    public enum ETextType { Name, Price, Stock }

//    private Button btn = null;
//    private TextMeshProUGUI[] texts = null;
//    private int itmeIndex = 0;

//    public int ItemIndex { get { return ItemIndex; } }

//    //private void Awake()
//    //{
//    //    btn = GetComponent<Button>();
//    //    texts = GetComponentsInChildren<TextMeshProUGUI>();
//    //}
//    //public void Init(VMMenu.OnClickButtonDelegate _onClickCallback,
//    //    string _name, int _price, int _stock)
//    //{
//    //    btn = GetComponent<Button>();
//    //    texts = GetComponentsInChildren<TextMeshProUGUI>();

//    //    btn.onClick.AddListener(() =>_onClickCallback(this));
//    //    texts[(int)ETextType.Name].text = _name;
//    //    texts[(int)ETextType.Price].text = _price.ToString();
//    //    UpdateStock(_stock);
//    //}
//    //public void UpdateStock(int _stock)
//    //{
//    //    texts[(int)ETextType.Stock].text = _stock.ToString();
//    //}

//    public void Init(
//       VMMenu.OnClickButtonDelegate _onClickCallback,
//       string _name, int _price, int _stock, int _itemIdx)
//    {
//        btn = GetComponent<Button>();
//        texts = GetComponentsInChildren<TextMeshProUGUI>();

//        btn.onClick.AddListener(() => _onClickCallback(this));
//        texts[(int)ETextType.Name].text = _name;
//        texts[(int)ETextType.Price].text = _price.ToString();
//        UpdateStock(_stock);
//        itmeIndex = _itemIdx;
//    }

//    public void UpdateStock(int _stock)
//    {
//        if(_stock <= 0)
//        {
//            SetInteractable(false);
//        }
//        texts[(int)ETextType.Stock].text = _stock.ToString();
//    }

//    public void SetInteractable(bool _interactable)
//    {
//        btn.interactable = _interactable;
//    }
//}
///////////////////////////////////////////////////////////////////////////
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VMButton : MonoBehaviour
{
    public enum ETextType { Name, Price, Stock }

    private Button btn = null;
    private TextMeshProUGUI[] texts = null;
    private int itemIndex = 0;


    public int ItemIndex { get { return itemIndex; } }


    //private void Awake()
    //{
    //    btn = GetComponent<Button>();
    //    texts = GetComponentsInChildren<TextMeshProUGUI>();
    //}

    public void Init(
        VMMenu.OnClickButtonDelegate _onClickCallback,
        string _name, int _price, int _stock,
        int _itemIdx)
    {
        btn = GetComponent<Button>();
        texts = GetComponentsInChildren<TextMeshProUGUI>();

        btn.onClick.AddListener(() => _onClickCallback(this));
        texts[(int)ETextType.Name].text = _name;
        texts[(int)ETextType.Price].text = _price.ToString();
        UpdateStock(_stock);

        itemIndex = _itemIdx;
    }

    public void UpdateStock(int _stock)
    {
        if (_stock <= 0)
        {
            _stock = 0;
            SetInteractable(false);
        }

        texts[(int)ETextType.Stock].text = _stock.ToString();
    }

    public void SetInteractable(bool _interactable)
    {
        btn.interactable = _interactable;
    }
}

//이거넣고 드디어 다른에러뜸