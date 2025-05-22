using UnityEngine;
using TMPro;

public class BreakoutBlockCounter : MonoBehaviour
{
    private TextMeshProUGUI[] textCounts = null;
    //컴포넌트 가져오는방법중 배열로 
    private void Awake()
    {
        //GetComponentsInChildren 자식 전부
        textCounts = GetComponentsInChildren<TextMeshProUGUI> ();
        Debug.Log("textCounts: " + textCounts.Length);

        //GetComponentsInChildren 자식과 부모포함 결과 : 4
        //RectTransform[] trs = GetComponentsInChildren<RectTransform>();
        //Debug.Log("trs: " + trs.Length);
    }

    // ui 주의점
    // 여기안에서 값을 바꾸면 안됨 ㅑ
    public void SetBlockCount(int _count, int _total)
    {
        textCounts[0].text = _count.ToString();
        textCounts[2].text = _total.ToString();
    }
}
