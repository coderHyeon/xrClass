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
        //���ӸŴ����� ����۽�������� AddListener -> ����Ƽ�� ��������Ʈ Action
        btnRestart.onClick.AddListener(_callback);
    }
}
