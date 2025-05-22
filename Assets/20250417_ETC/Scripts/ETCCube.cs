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
                Vector3.Lerp(leftTr.position, rightTr.position, t); //����
            //t += Time.deltaTime; // ��ŸŸ�� 1�̸� 1�� 
            t += Time.deltaTime * 0.5f; // ��ŸŸ�� 0.5�̸� 2�� 
            if (t >= 1f) t = 0f; //
            yield return null; // ���ѷ��� �Ⱥ����� �纸�ϱ�
            //yield return new WaitForSeconds(0.1f); //0.1f��ŭ õõ��
        }
    }
}
