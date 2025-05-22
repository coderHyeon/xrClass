using UnityEngine;

public class Anim_Doctor : MonoBehaviour
{
    private Animator anim = null;
    private bool transDance2 = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            transDance2 = !transDance2; //���� ������  True�� �ƴٰ� False�� �ƴٰ� �׷�
            anim.SetBool("TransDance2", transDance2);
        }
    }

}
