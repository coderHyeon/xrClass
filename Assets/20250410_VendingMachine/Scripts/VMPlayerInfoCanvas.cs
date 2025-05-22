using UnityEngine;
using TMPro;
using System.Text;
using static VMPlayer;

public class VMPlayerInfoCanvas : MonoBehaviour
{
    private readonly string formatHp = "HP: {0}";

    private TextMeshProUGUI[] textInfos = null;
    private StringBuilder sb = new StringBuilder();


    private void Awake()
    {
        textInfos = GetComponentsInChildren<TextMeshProUGUI>();
    }

    public void SetInfo(VMPlayer.SInfo _info)
    {
        Debug.Log("정보"+_info);
        Debug.Log("텍스트정보" + textInfos[0] + textInfos[1] + textInfos[2] + textInfos[3] + textInfos[4] + textInfos[5]);
        textInfos[0].text = _info.money + " won";

        textInfos[1].text = string.Format(formatHp, _info.hp);

        sb.Append("ATK: ");
        sb.Append(_info.atk);
        textInfos[2].text = sb.ToString();
        sb.Clear();

        textInfos[3].text = "DEF: " + _info.def;
        textInfos[4].text = "AGI: " + _info.agi;
        textInfos[5].text = "DEX: " + _info.dex;
    }
}