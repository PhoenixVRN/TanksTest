using System;
using UnityEngine;

namespace Tanks
{
    public class TankModel
    {
        private ControlLeak _controlLeak = new ControlLeak("TankModel");

        internal event Action<float> evtLives = delegate { };
        internal event Action evtKill = delegate { };
        internal event Action evtMakeKill = delegate { };   
        
        private int _hp;

        internal int HP
        {
            get => _hp;
            set
            {
                if (_hp != value && (!_hp.Equals(-1) || value > 0 || value.Equals(Constants.HPForKill)))
                {
                    if (_hp < value)
                    {
                        _hp = value;
                        evtLives.Invoke(value);
                    }

                    if (_hp > value)
                    {
                        evtLives.Invoke(value);

                        if (((_hp > 0 && value <= 0) || value == -1000) && !IsDead.Value)
                        {
                            evtMakeKill.Invoke();
                            //IsDead = true;
                        }

                        _hp = value;
                        _hp = _hp < 0 ? 0 : _hp;

                    }

                }
            }
        }
        internal SubscriptionField<float> SpeedMove { get; }
        internal SubscriptionField<float> SpeedRotateGun { get; }
        internal SubscriptionField<float> ReloadedOfFire { get; }
        internal SubscriptionField<float> Damage { get; }
        internal SubscriptionField<bool> IsDead { get; }
        internal SubscriptionField<Vector2> MoveDirection { get; }
        internal SubscriptionField<Vector2> MousPosition { get; }
        
        internal SubscriptionField<bool> Shoot { get; }
        
        


        public TankModel(int hp,float speed, float speedRotateGun, float reloadedOfFire, float damage)
        {
            _hp = hp;

            SpeedMove = new SubscriptionField<float>();
            SpeedMove.Value = speed;
            
            SpeedRotateGun = new SubscriptionField<float>();
            SpeedRotateGun.Value = speedRotateGun;

            ReloadedOfFire = new SubscriptionField<float>();
            ReloadedOfFire.Value = reloadedOfFire;

            Damage = new SubscriptionField<float>();
            Damage.Value = damage;
            
            IsDead = new SubscriptionField<bool>();

            MoveDirection = new SubscriptionField<Vector2>();

            MousPosition = new SubscriptionField<Vector2>();

            Shoot = new SubscriptionField<bool>();
        }

        public void ShootGun()
        {
          Debug.Log("Shoot");  
        }
        public void InitDead()
        {
            evtKill();
            evtKill = delegate { };
            evtLives = delegate { };
            evtMakeKill = delegate { };
            ClearVariablesSubscribe();
        }
        public void ClearVariablesSubscribe()
        {
            
        }
    }
}