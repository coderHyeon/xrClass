using System.Collections;
using UnityEngine;

public class ETCCube : MonoBehaviour
{
    [SerializeField] private Transform leftTr = null;
    [SerializeField] private Transform rightTr = null;
    private void Start()
    {
        StartCoroutine(PathCorutin());
    }
    private IEnumerator PathCorutin()
    {
        float t = 0f;
        while (true)
        {
            transform.position =
                Vector3.Lerp(leftTr.position, rightTr.position, t); //보간
            //t += Time.deltaTime; // 델타타임 1이면 1초 
            t += Time.deltaTime * 0.5f; // 델타타임 0.5이면 2초 
            if (t >= 1f) t = 0f; //
            yield return null; // 무한루프 안빠지게 양보하기
            //yield return new WaitForSeconds(0.1f); //0.1f만큼 천천히
        }
    }
}
