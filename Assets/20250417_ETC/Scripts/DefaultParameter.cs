using UnityEngine;

public class DefaultParameter : MonoBehaviour
{
    private void Start()
    {
        Func();
        Foo(3);//����Ʈ�Ű������� ������ 
    }
    private void Func(int _val=7)// �Ű������� �⺻���� �����ϴ°� DefaultParameter
    {
        Debug.Log("Func int: " + _val);
    }

    private void Foo(int _val = 7)
    {
        Debug.LogFormat("Func int: " + _val);
    }
    private void Foo(int _lhs=5, int _rhs=3)//����Ʈ�Ű������� ���ڸ����͸� ���� ���ڸ� �Ѱ��� �ȵ�
                                            //���Ǿ��ɽ�Ʈ�� �Ű����� 3�� �־��µ� �����δ� 7���� �ڿ� ����Ʈ �Ű������� �־�������~~`
    {
        Debug.LogFormat("Foo:{0}, {1}", _lhs, _rhs);
    }
}
