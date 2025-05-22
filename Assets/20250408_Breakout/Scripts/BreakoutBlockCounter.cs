using UnityEngine;
using TMPro;

public class BreakoutBlockCounter : MonoBehaviour
{
    private TextMeshProUGUI[] textCounts = null;
    //������Ʈ �������¹���� �迭�� 
    private void Awake()
    {
        //GetComponentsInChildren �ڽ� ����
        textCounts = GetComponentsInChildren<TextMeshProUGUI> ();
        Debug.Log("textCounts: " + textCounts.Length);

        //GetComponentsInChildren �ڽİ� �θ����� ��� : 4
        //RectTransform[] trs = GetComponentsInChildren<RectTransform>();
        //Debug.Log("trs: " + trs.Length);
    }

    // ui ������
    // ����ȿ��� ���� �ٲٸ� �ȵ� ��
    public void SetBlockCount(int _count, int _total)
    {
        textCounts[0].text = _count.ToString();
        textCounts[2].text = _total.ToString();
    }
}
