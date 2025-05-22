using UnityEngine;

public class BreakoutBlock : MonoBehaviour
{
    public bool IsActive { get { return gameObject.activeSelf; } }

    public void SetActive(bool _isActive)
    {
        gameObject.SetActive(_isActive);
    }

}
