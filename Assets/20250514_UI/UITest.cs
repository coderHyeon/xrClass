using UnityEngine;

public class UITest : MonoBehaviour
{
   public void OnCliToggel(bool _value)
    {
        Debug.Log("OnClickToggle: " + _value);
    }

    public void OnValueChagedWithSlider(float _value)
    {
        Debug.Log("OnValueChangedWithSlider: " + _value);
    }
}
