using System.Collections;
using UnityEngine;

public class ETCSphere : MonoBehaviour
{
    [SerializeField] private Transform leftTr = null;
    [SerializeField] private Transform rightTr = null;

    private void Start()
    {
        StartCoroutine(PathCorutin());
    }
    private IEnumerator PathCorutin()
    {
        transform.position = leftTr.position;
        while (true)
        {
            transform.position = Vector3.Lerp(transform.position,
                                                   rightTr.position,
                                                   Time.deltaTime);//0.01666666왼쪽과 오른쪽의 비율만큼
                                                                   //옮기는것임 점점적은 칸이 할당되는것임

            yield return null;
        }
    }
}
