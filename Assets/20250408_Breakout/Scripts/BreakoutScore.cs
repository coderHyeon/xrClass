using TMPro;
using UnityEngine;

public class BreakoutScore : MonoBehaviour
{
    private TextMeshProUGUI textScore = null;

    private void Awake()
    {
        textScore = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetScore(int _score)
    {
        textScore.text = string.Format("Score: {0}", _score);
    }

    public void ResetScore()
    {
        textScore.text = "Score: 0";// 상수만들기
    }
}
