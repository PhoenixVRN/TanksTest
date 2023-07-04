using System;
using System.Collections;
using System.Collections.Generic;
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
        
        private float _speedMove;
        private float _speedRotationGun;
        
        public void InitDead()
        {
            evtKill();
            evtKill = delegate { };
            evtLives = delegate { };
            evtMakeKill = delegate { };
            ClearVariablesSubscribe();
        }
        internal SubscriptionField<bool> IsDead { get; }
        internal SubscriptionField<float> AddMaxSpeed { get; }
        internal SubscriptionField<float> Speed { get; }

        public TankModel()
        {
            IsDead = new SubscriptionField<bool>();
            AddMaxSpeed = new SubscriptionField<float>();
            Speed = new SubscriptionField<float>();
        }
        public void ClearVariablesSubscribe()
        {
            
        }
    }
}