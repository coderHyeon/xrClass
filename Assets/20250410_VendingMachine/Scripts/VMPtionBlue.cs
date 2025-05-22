using UnityEngine;

public class VMPtionBlue : VMPotion
{
    public override void Drink(VMPlayer _player)
    {
        _player.AddDefencePoint(13);
        _player.AddAttackPoint(-2);
    }
}
