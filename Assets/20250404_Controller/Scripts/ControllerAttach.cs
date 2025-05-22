using UnityEngine;
//무기 줍기 잡기
public class ControllerAttach : MonoBehaviour
{
    //입력받는거 따로 클래스를 
    //처리하는거 따로

    [SerializeField]
    private Transform attachPointTr = null;
    private GameObject attachItemGo = null;// 획득한 아이템은 매개변수가 필요 없음

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            AttachItem();
        if (Input.GetMouseButtonDown(1))
            DettachItem();
    }

    //물체를 충돌했는지 안했는지 판단해주는 것임
    private void OnTriggerEnter(Collider _collider) //접촉한상대의 정보가 들어옴
    {
        if (_collider.CompareTag("Weapon")) //태그를 비교하여 무기인지 비교해서 무기를 쥘 수 있게
            attachItemGo = _collider.gameObject; //무기를 알게됨
    }

    private void OnTriggerExit(Collider _collider)
    {
        if (attachItemGo != null)
            attachItemGo = null;// 떨어지면 접촉한 아이템이 무엇인지 모르게됨
    }
    private void AttachItem()
    {
        if(attachItemGo != null)//무언가에 접촉을 했다면
        {
            //무기를 쥐어라 - 부모의 자식으로 넣어야 계층구조를 잘 따라갈 수 있음
            //transform.SetParent(attachItemGo.transform); // 내부모가 누구인지 지정
            //attachItemGo.transform.SetParent(this.transform);// 잘못된거임
            attachItemGo.transform.SetParent(attachPointTr);
            attachItemGo.transform.localPosition = Vector3.zero;
        }
    }
    private void DettachItem()
    {
        attachItemGo.transform.parent = null; //부모가 없으면 떨어짐 //SetParent랑 parent 같은기능
        Vector3 newPos = attachItemGo.transform.position;
        newPos.y = 0f;
        attachItemGo.transform.position = newPos;
        attachItemGo = null;
    }
}
