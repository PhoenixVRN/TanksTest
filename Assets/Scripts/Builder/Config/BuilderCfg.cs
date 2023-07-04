using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BuilderCfg : MonoBehaviour
{
    public UnitDataCfg UnitDataCfg => _dataUnitCfg;
    [SerializeField] private UnitDataCfg _dataUnitCfg;
}


