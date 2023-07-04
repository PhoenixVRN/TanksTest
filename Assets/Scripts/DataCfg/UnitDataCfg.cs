using UnityEngine;

[System.Serializable]
public sealed class UnitDataCfg
{
    public int HitPoint => _hp;
    [Header("HitPoint")] [SerializeField] private int _hp = 10;

    public int SpeedMove => _speedMove;
    [Header("SpeedMove")] [SerializeField] private int _speedMove = 50;

    public int SpeedRotateGun => _speedRotateGun;
    [Header("SpeedRotateGun")] [SerializeField] private int _speedRotateGun = 10;

    public int ReloadedOfFire => _reloadedOfFire;
    [Header("ReloadedOfFire")][SerializeField] private int _reloadedOfFire = 2;

    public int Damage => _damage;
    [Header("Damage")] [SerializeField] private int _damage = 2;
    
}
    
