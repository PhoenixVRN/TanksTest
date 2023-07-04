using Tanks;
using UnityEngine;

public class PlayerBuilder
{
    private MoveController _moveController;
    private InputController _inputController;
    private TankModel _tankModel;

    public PlayerBuilder()
    {
        var tank = Resources.Load("Unit/Player", typeof(GameObject)) as GameObject;
        var player = Object.Instantiate(tank, new Vector3(0, 0, 0), Quaternion.identity);
        player.transform.SetParent(Reference.ActiveElements);
        var builder = player.GetComponentInChildren<BuilderCfg>();
        _tankModel = new TankModel(builder.UnitDataCfg.HitPoint,
            builder.UnitDataCfg.SpeedMove,
            builder.UnitDataCfg.SpeedRotateGun,
            builder.UnitDataCfg.ReloadedOfFire,
            builder.UnitDataCfg.Damage);
        
        _moveController = new MoveController(_tankModel, player.GetComponentInChildren<TankView>());
        _inputController = new InputController(_tankModel, player.GetComponentInChildren<TankView>());
        ListControllers.Add(_moveController);
        ListControllers.Add(_inputController);
        
        
        
    }
}
