using System.Collections;
using UnityEngine;

public class CoroutinExample2 : MonoBehaviour
{
    //마우스를 누를때 까지 대기하도록
    private class WaitForMouseClick : CustomYieldInstruction
    {
        //빨간줄이 나오는이유는 오버로딩 할께있음
        public override bool keepWaiting
        {
            get
            {
                return !Input.GetMouseButtonDown(0);
            }
        }
    }
    public WaitForSeconds wait1Sec = new WaitForSeconds(1f);//변수로가능

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
        yield return new WaitForSeconds(1f);//0.5.초를 동적할당으로 쉬게하기 
                                              //가비지가 생기고 있음
    }
    //yield 할때 다른 코르틴을 넣어줄수 있음
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
