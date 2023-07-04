using System;
using UnityEngine;

namespace Tanks
{
    public class BulletModel
    {
        private ControlLeak _controlLeak = new ControlLeak("BulletModel");

        internal SubscriptionField<float> SpeedMove { get; }
        internal SubscriptionField<float> Damage { get; }
        internal SubscriptionField<float> FlightTime { get; }
        internal SubscriptionField<Vector2> MoveDirection { get; }
        internal SubscriptionField<bool> IsDead { get; }
        
        public BulletModel(float speed, float damage, float flightTime)
        {
            SpeedMove = new SubscriptionField<float>();
            SpeedMove.Value = speed; 
            
            Damage = new SubscriptionField<float>();
            Damage.Value = damage;

            FlightTime = new SubscriptionField<float>();
            FlightTime.Value = flightTime;
            
            MoveDirection = new SubscriptionField<Vector2>();
            
            IsDead = new SubscriptionField<bool>();
        }
    }
}