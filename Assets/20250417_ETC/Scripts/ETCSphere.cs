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
                                                   Time.deltaTime);//0.01666666���ʰ� �������� ������ŭ
                                                                   //�ű�°��� �������� ĭ�� �Ҵ�Ǵ°���

            yield return null;
        }
    }
}
