using UnityEngine;

public class VMPtionYellow : VMPotion 
{
    public override void Drink(VMPlayer _player)
    {
        _player.AddDefencePoint(13);
        _player.AddAgilityPoint(-2);
    }
}
