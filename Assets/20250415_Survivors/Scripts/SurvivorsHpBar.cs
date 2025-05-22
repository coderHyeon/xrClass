using UnityEngine;
using UnityEngine.UI;
public class SurvivorsHpBar : MonoBehaviour
{
    private RectTransform tr = null;
    //private Image img = null;
    private RectTransform imgTr = null;
    private float oriImgWith = 0f;
    private void Awake()
    {
        tr = GetComponent<RectTransform>();
        Image[] imgs = GetComponentsInChildren<Image>();
        imgTr = imgs[1].GetComponent<RectTransform>();
        //imgTr = imgs[1];
        // °Ù ÄÄÆ÷³ÍÆ® ³¶ºñ imgWith = img.GetComponent<RectTransform>().sizeDelta.x;
        oriImgWith = imgTr.sizeDelta.x;
    }
    public void SetHP(int _maxHp, int _hp) 
    {
        float ratio  = (float)_hp / (float)_maxHp;
        imgTr.sizeDelta = new Vector2(
            oriImgWith * ratio,
            imgTr.sizeDelta.y
            );
    }
    public void UpdatePosition(Vector3 _worldPos)
    {
        Vector3 worldToScreen = 
            Camera.main.WorldToScreenPoint(_worldPos);
        worldToScreen.y += 50f;

        tr.position = worldToScreen;
    }

}
