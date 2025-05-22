using UnityEngine;

public abstract class VMPotion : MonoBehaviour
{
    //private float duration = 0;
    private float rotSpeed = 10f;

    private void Uptate()
    {
        transform.Rotate(Vector3.up, rotSpeed + Time.deltaTime);
    }

    public abstract void Drink(VMPlayer _player);

}
