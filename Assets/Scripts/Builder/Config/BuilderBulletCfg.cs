using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderBulletCfg : MonoBehaviour
{
    public BulletDataCfg BulletDataCfg => _bulletDataCfg;
    [SerializeField] private BulletDataCfg _bulletDataCfg;
}
