
//using UnityEngine;
//using UnityEngine.UI;

//public class VMMenuCanvas : MonoBehaviour 
//{
//    public delegate void CloseDelegate();

//    [SerializeField] private Button btnClose = null;
//    [SerializeField] private VMMenu menu = null;

//    private CloseDelegate closeCallback = null;
//    private void Awake()
//    {
//        btnClose.onClick.AddListener(() =>SetActive(false));
//       // menu = GetComponent<VMMenu>();
//    }
//    public void SetActive(bool _active)
//    {
//        gameObject.SetActive(_active);

//        if (_active == true) VMGameState.OpenUI();
//        else
//        {
//            VMGameState.Play();
//            closeCallback?.Invoke();
//        }
//    }

//    //public void Init(
//    //     VMVendingMachine.SItem[] _items,
//    //     VMMenu.OnClickButtonDelegate _onClickCallback)
//    //{
//    //    menu.Init(_items);
//    //    menu.SetOnClickButtonCallback(_onClickCallback);
//    //}
//    public void Init(
//        VMVendingMachine.SItem[] _items,
//        int _money,
//        VMMenu.OnClickButtonDelegate _onClickCallback)
//    {
//        menu.Init(_items, _money);
//        menu.SetOnClickButtonCallback(_onClickCallback);
//    }
//    //난중에 수정
//    public void SetCloseCallback(CloseDelegate _closeCallback)
//    {
//        closeCallback = _closeCallback;
//    }
//}
/////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public class VMMenuCanvas : MonoBehaviour
{
    public delegate void CloseDelegate();


    [SerializeField] private Button btnClose = null;
    [SerializeField] private VMMenu menu = null;

    private CloseDelegate closeCallback = null;


    private void Awake()
    {
        btnClose.onClick.AddListener(() => SetActive(false));

        //menu = GetComponentInChildren<VMMenu>();
    }

    public void SetActive(bool _active)
    {
        gameObject.SetActive(_active);

        if (_active == true) VMGameState.OpenUI();
        else
        {
            VMGameState.Play();
            closeCallback?.Invoke();
        }
    }

    public void Init(
        VMVendingMachine.SItem[] _items,
        int _money,
        VMMenu.OnClickButtonDelegate _onClickCallback)
    {
        menu.Init(_items, _money);
        menu.SetOnClickButtonCallback(_onClickCallback);
    }

    public void SetCloseCallback(CloseDelegate _closeCallback)
    {
        closeCallback = _closeCallback;
    }
}
