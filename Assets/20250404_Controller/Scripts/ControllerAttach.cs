using UnityEngine;
//���� �ݱ� ���
public class ControllerAttach : MonoBehaviour
{
    //�Է¹޴°� ���� Ŭ������ 
    //ó���ϴ°� ����

    [SerializeField]
    private Transform attachPointTr = null;
    private GameObject attachItemGo = null;// ȹ���� �������� �Ű������� �ʿ� ����

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            AttachItem();
        if (Input.GetMouseButtonDown(1))
            DettachItem();
    }

    //��ü�� �浹�ߴ��� ���ߴ��� �Ǵ����ִ� ����
    private void OnTriggerEnter(Collider _collider) //�����ѻ���� ������ ����
    {
        if (_collider.CompareTag("Weapon")) //�±׸� ���Ͽ� �������� ���ؼ� ���⸦ �� �� �ְ�
            attachItemGo = _collider.gameObject; //���⸦ �˰Ե�
    }

    private void OnTriggerExit(Collider _collider)
    {
        if (attachItemGo != null)
            attachItemGo = null;// �������� ������ �������� �������� �𸣰Ե�
    }
    private void AttachItem()
    {
        if(attachItemGo != null)//���𰡿� ������ �ߴٸ�
        {
            //���⸦ ���� - �θ��� �ڽ����� �־�� ���������� �� ���� �� ����
            //transform.SetParent(attachItemGo.transform); // ���θ� �������� ����
            //attachItemGo.transform.SetParent(this.transform);// �߸��Ȱ���
            attachItemGo.transform.SetParent(attachPointTr);
            attachItemGo.transform.localPosition = Vector3.zero;
        }
    }
    private void DettachItem()
    {
        attachItemGo.transform.parent = null; //�θ� ������ ������ //SetParent�� parent �������
        Vector3 newPos = attachItemGo.transform.position;
        newPos.y = 0f;
        attachItemGo.transform.position = newPos;
        attachItemGo = null;
    }
}
