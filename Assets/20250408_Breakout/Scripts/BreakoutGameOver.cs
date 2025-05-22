using UnityEngine;
using UnityEngine.UI;

public class BreakoutGameOver : MonoBehaviour
{
    private Button btnRestart = null;

    private void Awake()
    {
        btnRestart = GetComponentInChildren<Button>();
    }

    public void SetRestartButtonListener(UnityEngine.Events.UnityAction _callback)
    {
        //게임매니저가 재시작시켜줘야함 AddListener -> 유니티의 델리게이트 Action
        btnRestart.onClick.AddListener(_callback);
    }
}
