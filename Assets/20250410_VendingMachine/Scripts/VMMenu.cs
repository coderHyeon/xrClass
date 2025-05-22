using UnityEngine;



public class VMMenu : MonoBehaviour
{
    public delegate void OnClickButtonDelegate(VMButton _btn);

    [SerializeField] private RectTransform backTr = null;
    private GameObject btnPrefab = null;
    private OnClickButtonDelegate onClickButtonCallback = null;

    private void Awake()
    {        //�ҷ��� �ڷ� = Resources(����).Load<�ҷ��� �ڷ�>(���)
        //btnPrefab = Resources.Load<GameObject>("Prefabs\\P_VMButton");
        //if (btnPrefab == null)
        //    //Debug.Log("Log")
        //    //Debug.LogWarning("Warning);
        //    Debug.LogError("P_VMButton load failed!");
    }
    //public void Init(VMVendingMachine.SItem[] _items)
    //{
    //    if (transform.childCount > 0)//��ư�� ���鶧���� �ڽ��� ����
    //    {
    //        DestroyButtons();

    //        //transform �� 0�� �θ�� �θ���� ���ͼ� 
    //        float backWidth = backTr.sizeDelta.x;
    //        float backHeight = backTr.sizeDelta.y;


    //        //�����տ��� �ڵ忡 �ٲٴ°� ���ϴ°� ����
    //        //if(btnPrefab == null)
    //        //    btnPrefab = Resources.Load<GameObject>("Prefabs\\P_VMButton");
    //        //RectTransform btnTr = btnPrefab.GetComponent<RectTransform>();
    //        btnPrefab =
    //       Resources.Load<GameObject>("Prefabs\\P_VMButton");
    //        RectTransform btnTr = btnPrefab.GetComponent<RectTransform>();

    //        float btnWidth = btnTr.sizeDelta.x;
    //        float btnHeight = btnTr.sizeDelta.y;

    //        int rowCntMax = 3;
    //        int colCntMax = 3;
    //        float rowOffset = (backHeight - (btnHeight + rowCntMax) / (rowCntMax + 1));
    //        float colOffset =
    //            (backWidth - (btnWidth * colCntMax)) / (colCntMax + 1);

    //        float backWidhtHalf = backWidth * 0.5f;
    //        float backHeightHalf = backHeight * 0.5f;
    //        float btnWidthHalf = btnWidth * 0.5f;
    //        float btnHeightHalf = btnWidth * 0.5f;

    //        Vector3 startPos = new Vector3(
    //            -btnWidthHalf + colOffset + btnWidthHalf,
    //            backHeightHalf - rowOffset - btnHeightHalf,
    //            0f
    //            );
    //        // 0 1 2 => 1
    //        // 3 4 5 => 2
    //        // 6 7 8 => 3
    //        int rowCnt = ((_items.Length - 1) / rowCntMax)+1;
    //        // 0 1 2 => 1 2 3
    //        // 3 4 5 => 1 2 3
    //        // 6 7 8 => 1 2 3
    //        int colCnt = ((_items.Length - 1) % colCntMax) + 1;
    //        for (int row = 0; row < rowCntMax; ++row)
    //        {
    //            for (int col = 0; col < colCntMax; ++col)
    //            {
    //                Vector3 pos = startPos;
    //                pos.x += (btnWidth + colOffset) * col;
    //                pos.y -= (btnHeight + rowOffset) * row;
    //                GameObject btnGo =
    //                    Instantiate(
    //                        btnPrefab,
    //                        pos,
    //                        Quaternion.identity,
    //                        this.transform);
    //                //GameObject btnGo = Instantiate(btnPrefab);
    //                //btnGo.transform.SetParent(this.transform);
    //                btnGo.GetComponent<RectTransform>().localPosition = pos;
    //               VMButton btn = btnGo.GetComponent<VMButton>();

    //        VMVendingMachine.SItem item =
    //        _items[(rowCnt * colCnt) + col];
    //               // string itemName = VMVendingMachine.SItem.TypeToString(item.itemType);
    //        btn.Init(
    //            OnClickButton,
    //            VMVendingMachine.SItem.TypeToString(item.itemType),
    //            item.price,
    //            item.stock);
    //                btnGo.name = item.itemType.ToString();
    //            }
    //        }
    //    }
    //}
    public void Init(VMVendingMachine.SItem[] _items, int _money)
    {
        if (transform.childCount > 0)
            DestroyButtons();

        float backWidth = backTr.sizeDelta.x;
        float backHeight = backTr.sizeDelta.y;

        if (btnPrefab == null)
            btnPrefab =
                Resources.Load<GameObject>("Prefabs\\P_VMButton");
        RectTransform btnTr = btnPrefab.GetComponent<RectTransform>();

        float btnWidth = btnTr.sizeDelta.x;
        float btnHeight = btnTr.sizeDelta.y;

        int rowCntMax = 3;
        int colCntMax = 3;
        float rowOffset =
            (backHeight - (btnHeight * rowCntMax)) / (rowCntMax + 1);
        float colOffset =
            (backWidth - (btnWidth * colCntMax)) / (colCntMax + 1);
        //float colOffset3 =
        // (backWidth - (btnWidth * 2)) / (2 + 1);
        // Debug.Log("coloffset3_ : " + colOffset3);

        float backWidthHalf = backWidth * 0.5f;
        float backHeightHalf = backHeight * 0.5f;
        float btnWidthHalf = btnWidth * 0.5f;
        float btnHeightHalf = btnHeight * 0.5f;


        // 0 1 2 => 1
        // 3 4 5 => 2
        // 6 7 8 => 3
        int rowCnt = ((_items.Length - 1) / rowCntMax) + 1;
        // 0 1 2 => 1 2 3
        // 3 4 5 => 1 2 3
        // 6 7 8 => 1 2 3
        int colCnt = ((_items.Length - 1) % colCntMax) + 1;
        int colCnt2 = ((_items.Length - 1) / colCntMax) + 1;
        ;

        // [0,1,2,3] �� �ִٰ� ����
        // �����۰���(3)�� ���� �� ī���� �ƽ��� ..���� �򰪿� +1e �� �Ѵٸ�  �� 1���ݾ�,,, 
        // 
        // �� ������ 1�ۿ� �ȳ��� �׷��Ƿ� colCnt�� Ż�� ���� �ƴ�?
        // 
        // ���� ������ row 1��°������ col�� ������ �ִ� ���ڸ�ŭ ���ƾ���. �׷��� ���ؼ���
        // row�϶� ù��°�϶� �������� 
        int itemsLength = _items.Length - 1;
        Debug.Log(" : " + itemsLength);
        int itemsLengthCnt = 0;
        for (int row = 0; row < rowCnt; ++row)
        {

            for (int col = 0; col < colCntMax; ++col)
            {// �ݰ���Ʈ�� �ȿ� �־����
                if (itemsLengthCnt >= _items.Length) break;
             
                var colOffset2 =
                                (backWidth - (btnWidth * ((col < colCntMax && row == rowCnt - 1) || itemsLengthCnt==3 ? colCnt : 3))) / ((col + 1 < rowCntMax && row == rowCnt - 1 ? colCnt  : 3) + 1);
                int a = rowCnt - 1;

                //if (itemsLengthCnt == 3 )
                //{ colOffset2 = (backWidth - (btnWidth * 2 / 2 + 1)); }

                //Debug.Log("colOffset3" + colOffset3);
                //Debug.Log("colCnt_" + colCnt);
                //Debug.Log("colCnt2_" + colCnt2);
                //Debug.Log("rowCnt_" + rowCnt);
                //Debug.Log("col+1_" + (col + 1));


                //float rowOffset =
                //               (backHeight - (btnHeight * rowCntMax)) / (rowCntMax + 1);
                float rowOffset2 =
                                (backHeight - (btnHeight * (rowCnt < rowCntMax ? rowCnt : rowCntMax))) / ((rowCnt < rowCntMax ? rowCnt : rowCntMax) + 1);
                // colcnt �� �ȿ� �ִ°� �´°���
                Vector3 startPos = new Vector3(
                -backWidthHalf + colOffset2 + btnWidthHalf,
                backHeightHalf - rowOffset2 - btnHeightHalf,
                0f);
                Vector3 pos = startPos;
                pos.x += (btnWidth + colOffset2) * (col);
                pos.y -= (btnHeight + rowOffset2) * row;
                GameObject btnGo =
                    Instantiate(
                        btnPrefab,
                        pos,
                        Quaternion.identity,
                        this.transform);
                //GameObject btnGo = Instantiate(btnPrefab);
                //btnGo.transform.SetParent(this.transform);
                btnGo.GetComponent<RectTransform>().localPosition = pos;

                VMButton btn = btnGo.GetComponent<VMButton>();
                int colCnt4 = (colCnt2 == col && row == rowCnt - 1 ? col + 1 : colCnt);
                VMVendingMachine.SItem item =
                    _items[itemsLengthCnt];
                //Debug.Log(item.itemType);
                Debug.Log("itemsLengthCnt���� : " + itemsLengthCnt);
                Debug.Log("����index: " + itemsLength);
                btn.Init(
                    OnClickButton,
                    VMVendingMachine.SItem.TypeToString(item.itemType),
                    item.price,
                    item.stock,
                    itemsLengthCnt
                    );

                btnGo.name = item.itemType.ToString();
                //if (_money < item.price)
                //    btn.SetInteractable(false);//����°�� 
                btn.SetInteractable(_money >= item.price);//������ ���� �����Ѱ�츸 ������
                ++itemsLengthCnt;
                if (itemsLengthCnt - 1 == itemsLength) return;

            }
        }
    }


    //private void DestroyButtons()
    //{
    //    VMButton[] btns =
    //           GetComponentsInChildren<VMButton>();
    //    for (int i = 0; i < btns.Length; ++i)
    //        Destroy(btns[i].gameObject);
    //}
    //public void SetOnClickButtonCallback(
    //    OnClickButtonDelegate _onClickButtonCallback)
    //{
    //    onClickButtonCallback = _onClickButtonCallback;
    //}
    //private void OnClickButton(VMButton _btn)
    //{
    //    onClickButtonCallback?.Invoke(_btn);
    //}
    private void DestroyButtons()
    {
        VMButton[] btns =
                GetComponentsInChildren<VMButton>();
        for (int i = 0; i < btns.Length; ++i)
            Destroy(btns[i].gameObject);
    }
    public void SetOnClickButtonCallback(
       OnClickButtonDelegate _onClickButtonCallback)
    {
        onClickButtonCallback = _onClickButtonCallback;
    }

    private void OnClickButton(VMButton _btn)
    {
        onClickButtonCallback?.Invoke(_btn);
    }
}



//using UnityEngine;

//public class VMMenu : MonoBehaviour
//{
//    public delegate void OnClickButtonDelegate(VMButton _btn);


//    [SerializeField] private RectTransform backTr = null;

//    private GameObject btnPrefab = null;

//    private OnClickButtonDelegate onClickButtonCallback = null;


//    private void Awake()
//    {
//        //btnPrefab =
//        //    Resources.Load<GameObject>("Prefabs\\P_VMButton");
//        //if (btnPrefab == null)
//        //    //Debug.Log("Log");
//        //    //Debug.LogWarning("Warning");
//        //    Debug.LogError("P_VMButton load failed!");
//    }

//    public void Init(
//        VMVendingMachine.SItem[] _items,
//        int _money)
//    {
//        if (transform.childCount > 0)
//            DestroyButtons();

//        float backWidth = backTr.sizeDelta.x;
//        float backHeight = backTr.sizeDelta.y;

//        if (btnPrefab == null)
//            btnPrefab =
//                Resources.Load<GameObject>("Prefabs\\P_VMButton");
//        RectTransform btnTr = btnPrefab.GetComponent<RectTransform>();

//        float btnWidth = btnTr.sizeDelta.x;
//        float btnHeight = btnTr.sizeDelta.y;

//        int rowCntMax = 3;
//        int colCntMax = 3;
//        float rowOffset =
//            (backHeight - (btnHeight * rowCntMax)) / (rowCntMax + 1);
//        float colOffset =
//            (backWidth - (btnWidth * colCntMax)) / (colCntMax + 1);

//        float backWidthHalf = backWidth * 0.5f;
//        float backHeightHalf = backHeight * 0.5f;
//        float btnWidthHalf = btnWidth * 0.5f;
//        float btnHeightHalf = btnHeight * 0.5f;
//        Vector3 startPos = new Vector3(
//            -backWidthHalf + colOffset + btnWidthHalf,
//            backHeightHalf - rowOffset - btnHeightHalf,
//            0f);

//        // 0 1 2 => 1
//        // 3 4 5 => 2
//        // 6 7 8 => 3
//        int rowCnt = ((_items.Length - 1) / rowCntMax) + 1;
//        // 0 1 2 => 1 2 3
//        // 3 4 5 => 1 2 3
//        // 6 7 8 => 1 2 3
//        int colCnt = ((_items.Length - 1) % colCntMax) + 1;
//        int curItemIdx = 0;
//        for (int row = 0; row < rowCntMax; ++row)
//        {
//            for (int col = 0; col < colCntMax; ++col)
//            {
//                if (curItemIdx >= _items.Length) break;

//                Vector3 pos = startPos;
//                pos.x += (btnWidth + colOffset) * col;
//                pos.y -= (btnHeight + rowOffset) * row;

//                GameObject btnGo =
//                    Instantiate(
//                        btnPrefab,
//                        pos,
//                        Quaternion.identity,
//                        this.transform);
//                //GameObject btnGo = Instantiate(btnPrefab);
//                //btnGo.transform.SetParent(this.transform);
//                btnGo.GetComponent<RectTransform>().localPosition = pos;

//                VMButton btn = btnGo.GetComponent<VMButton>();
//                VMVendingMachine.SItem item =
//                    //_items[(row * colCnt) + col];
//                    _items[curItemIdx];
//                btn.Init(
//                    OnClickButton,
//                    VMVendingMachine.SItem.TypeToString(item.itemType),
//                    item.price,
//                    item.stock,
//                    //(row * colCnt) + col
//                    curItemIdx
//                    );

//                btnGo.name = item.itemType.ToString();

//                //if (_money < item.price)
//                //    btn.SetInteractable(false);
//                btn.SetInteractable(_money >= item.price);

//                ++curItemIdx;
//            }
//        }
//    }

//    private void DestroyButtons()
//    {
//        VMButton[] btns =
//                GetComponentsInChildren<VMButton>();
//        for (int i = 0; i < btns.Length; ++i)
//            Destroy(btns[i].gameObject);
//    }

//    public void SetOnClickButtonCallback(
//        OnClickButtonDelegate _onClickButtonCallback)
//    {
//        onClickButtonCallback = _onClickButtonCallback;
//    }

//    private void OnClickButton(VMButton _btn)
//    {
//        onClickButtonCallback?.Invoke(_btn);
//    }
//}
