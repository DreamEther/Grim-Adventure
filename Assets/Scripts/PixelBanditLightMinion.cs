using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Minion - Pixel Bandit Light")]
public class PixelBanditLightMinion : BaseMinion
{

    public int health = 10;
    public int attackPower = 5;
    PixelBanditLightBehavior pixelBanditLightBehavior;

    public override void Initialize(GameObject gameObject)
    {
        pixelBanditLightBehavior = gameObject.GetComponent<PixelBanditLightBehavior>();
        pixelBanditLightBehavior.health = health;
        pixelBanditLightBehavior.attackPower = attackPower;

    } 

}