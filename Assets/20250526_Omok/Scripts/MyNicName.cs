using UnityEngine;
using TMPro;
using Photon.Pun;

public class MyNickNameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nickNameText;
    [SerializeField] private Transform target;

    private void Start()
    {
        if (nickNameText == null)
        {
            nickNameText = GetComponentInChildren<TextMeshProUGUI>();
        }

        nickNameText.text = PhotonNetwork.NickName;
    }

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position);
        transform.position = screenPos + new Vector3(0f, 60f, 0f); // ¸Ó¸® À§
    }

    public void SetTarget(Transform t)
    {
        target = t;
    }
}