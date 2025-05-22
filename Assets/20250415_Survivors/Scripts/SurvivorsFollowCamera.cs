using UnityEngine;

public class SurvivorsFollowCamera : MonoBehaviour
{
    [SerializeField] private Transform targetTr = null;
    private Vector3 offset = Vector3.zero;

    private void Start()
    {
        offset = transform.position - targetTr.position;
    }
    private void Update()
    {
        transform.position = targetTr.position + offset;
    }
}


