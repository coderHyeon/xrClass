using UnityEngine;

public class DefaultParameter : MonoBehaviour
{
    private void Start()
    {
        Func();
        Foo(3);//디폴트매개변수의 딜레마 
    }
    private void Func(int _val=7)// 매개변수의 기본값을 지정하는게 DefaultParameter
    {
        Debug.Log("Func int: " + _val);
    }

    private void Foo(int _val = 7)
    {
        Debug.LogFormat("Func int: " + _val);
    }
    private void Foo(int _lhs=5, int _rhs=3)//디폴트매개변수는 뒷자리부터만 가능 앞자리 한개는 안됨
                                            //스피어케스트가 매개변수 3개 넣었는데 실제로는 7개는 뒤에 디폴트 매개변수가 있었던거임~~`
    {
        Debug.LogFormat("Foo:{0}, {1}", _lhs, _rhs);
    }
}
