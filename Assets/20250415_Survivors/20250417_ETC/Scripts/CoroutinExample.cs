using UnityEngine;
using System.Collections;

public class CoroutinExample : MonoBehaviour
{
    public Coroutine example = null;
    private void Start()
    {
        Example();// 단독으로 안들고 StartCorutin
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            example = StartCoroutine(Example());
        
        if (Input.GetKeyDown(KeyCode.Q))
            StopCoroutine(example);//정지됨
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine("Example");
            StartCoroutine("Example");
        }
      
        if(Input.GetKeyDown(KeyCode.S))
            //StopCoroutine(Example()); //정지안됨
            StopCoroutine("Example");//정지됨
        //if (Input.GetKeyDown(KeyCode.D))
        //    StopAllCoroutines(Example());
        
    }
    //코루틴은 동시에 동작함
    private IEnumerator Example()//IEnumerator enum 반환하게 되어있음  한개이상있어야 에러가 안뜸
    {
        Debug.Log("Example 1");
        //양보, null한번을 쉬는거임 
        yield return null;
        Debug.Log("Example 2");
        yield return new WaitForSeconds(1f);
        while(true)// 무한 반복
        {
        Debug.Log("Exmple 3");
            yield return new WaitForSeconds(1f);
        }
    }
}
