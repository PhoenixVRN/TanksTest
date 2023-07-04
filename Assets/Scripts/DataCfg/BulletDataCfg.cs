using System;
using UnityEngine;

[Serializable]
public sealed class BulletDataCfg
{
    public int SpeedMove => _speedMove;
    [Header("SpeedMove")] [SerializeField] private int _speedMove = 50;
    
    public int Damage => _damage;
    [Header("Damage")] [SerializeField] private int _damage = 2;
    
    public float FlightTime => _flightTime;
    [Header("FlightTime")] [SerializeField] private float _flightTime = 2;

}
