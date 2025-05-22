using UnityEngine;
using System.Collections;

public class CoroutinExample : MonoBehaviour
{
    public Coroutine example = null;
    private void Start()
    {
        Example();// �ܵ����� �ȵ�� StartCorutin
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            example = StartCoroutine(Example());
        
        if (Input.GetKeyDown(KeyCode.Q))
            StopCoroutine(example);//������
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine("Example");
            StartCoroutine("Example");
        }
      
        if(Input.GetKeyDown(KeyCode.S))
            //StopCoroutine(Example()); //�����ȵ�
            StopCoroutine("Example");//������
        //if (Input.GetKeyDown(KeyCode.D))
        //    StopAllCoroutines(Example());
        
    }
    //�ڷ�ƾ�� ���ÿ� ������
    private IEnumerator Example()//IEnumerator enum ��ȯ�ϰ� �Ǿ�����  �Ѱ��̻��־�� ������ �ȶ�
    {
        Debug.Log("Example 1");
        //�纸, null�ѹ��� ���°��� 
        yield return null;
        Debug.Log("Example 2");
        yield return new WaitForSeconds(1f);
        while(true)// ���� �ݺ�
        {
        Debug.Log("Exmple 3");
            yield return new WaitForSeconds(1f);
        }
    }
}
