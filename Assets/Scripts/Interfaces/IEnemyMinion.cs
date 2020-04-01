using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public interface IEnemyMinion : ITakeDamage
    {
        void Ability();
    }


    public interface GroundMinion : IEnemyMinion
    {
        void GetGroundMinion(string tag);
    }

public interface FlyingMinion : IEnemyMinion
{

}

public interface RangedMinion : IEnemyMinion
{

}

public interface PixelMinion : IEnemyMinion

{

}



