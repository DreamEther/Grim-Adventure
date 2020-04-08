using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    [CreateAssetMenu(menuName = "Attack Sequence - #3")]
    public class NinjaAttackSequence3 : AttackSequence
    {
        private NinjaAI ninjaAttackSequence;
        public float accuracy;
        public override void Initialize(GameObject gameObject)
        {
            ninjaAttackSequence = gameObject.GetComponent<NinjaAI>();
            //ninjaAttackSequence.accuracy = accuracy;      
        }

        public override void TriggerAbility(Action onAttackCompleted)
        {
            PlayerController.Attack attack = ninjaAttackSequence.AttackSequence2;
            ninjaAttackSequence.TriggerNinjaAttackSequence(attack);
        }

    }
