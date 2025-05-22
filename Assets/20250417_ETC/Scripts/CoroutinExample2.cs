using System.Collections;
using UnityEngine;

public class CoroutinExample2 : MonoBehaviour
{
    //���콺�� ������ ���� ����ϵ���
    private class WaitForMouseClick : CustomYieldInstruction
    {
        //�������� ������������ �����ε� �Ҳ�����
        public override bool keepWaiting
        {
            get
            {
                return !Input.GetMouseButtonDown(0);
            }
        }
    }
    public WaitForSeconds wait1Sec = new WaitForSeconds(1f);//�����ΰ���

    //private void Start()
    //{
        

    //    StartCoroutine(NumberCoroutine());
    //}
    private IEnumerator Start()
    {
        Debug.Log("Start 1");
        yield return wait1Sec; 
        Debug.Log("Start 2");
        yield return wait1Sec; 
        Debug.Log("Start 3");
        yield return wait1Sec;
        Debug.Log("Go!");
        yield return wait1Sec;

        StartCoroutine(NumberCoroutine());
    }

    private IEnumerator NumberCoroutine()
    {
        Debug.Log("1");
        yield return wait1Sec;

        Debug.Log("2");
        yield return wait1Sec;

        Debug.Log("3");
        yield return AlphabetCoroutine();

        Debug.Log("4");
        yield return new WaitForSeconds(1f);//0.5.�ʸ� �����Ҵ����� �����ϱ� 
                                              //�������� ����� ����
    }
    //yield �Ҷ� �ٸ� �ڸ�ƾ�� �־��ټ� ����
    private IEnumerator AlphabetCoroutine()
    {
        Debug.Log("A");
        yield return wait1Sec;

        Debug.Log("B");
        yield return new WaitForMouseClick();

        Debug.Log("C");
        yield return wait1Sec;

    }
}
