using UnityEngine;

public class VMPotionRed : VMPotion
{
    public override void Drink(VMPlayer _player)
    {
        _player.AddHealthPoint(5);
        _player.AddAttackPoint(3);
    }
}
