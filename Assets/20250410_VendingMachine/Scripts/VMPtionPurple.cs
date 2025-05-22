using UnityEngine;

public class VMPtionPurple : VMPotion
{
    public override void Drink(VMPlayer _player)
    {
        _player.AddDefencePoint(3);
    }
}
