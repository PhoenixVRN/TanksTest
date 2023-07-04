using System;
using Tanks;
using UnityEngine;

public class MoveController : IController, IFixedExecute, IDisposable
{
  public event Action<IController> EvtNeedDestroy;
  
  private TankModel _tankModel;
  private TankView _tankView;
  
  private Transform _turretParent;
  private Rigidbody2D _rb;
  private float _deltaTime = 0;
  
  
  public MoveController(TankModel tankModel, TankView tankView)
  {
    _tankModel = tankModel;
    _tankView = tankView;
    _rb = _tankView.Rb;
    _turretParent = _tankView.TurretParent;
  }
  
  public void FixedExecute(float deltaTime)
  {
    _deltaTime = deltaTime;
    Debug.Log($"Move {_tankModel.MoveDirection.Value}");
    Move(_tankModel.MoveDirection.Value);
    HandleTurretMovement();
  }
  private void Move(Vector2 dir)
  {
    var dirnormal = dir.normalized;
    Vector2 moveDir = (Vector2) _rb.transform.up * dirnormal.y * _tankModel.SpeedMove.Value * _deltaTime;
    _rb.velocity = moveDir;
    int revers = dir.y < 0 ? 1 : -1 ;
    _rb.MoveRotation(_rb.transform.rotation * Quaternion.Euler(0, 0, dirnormal.x * _tankModel.SpeedMove.Value * _deltaTime *  revers));
  }

  private void HandleTurretMovement()
  {
    var turretDirection = (Vector3) _tankModel.MousPosition.Value - _rb.transform.position;
    var deseredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg;
    _turretParent.rotation = Quaternion.RotateTowards(_turretParent.rotation, Quaternion.Euler( 0,0,deseredAngle), _tankModel.SpeedRotateGun.Value * _deltaTime);
  }

  public void Dispose()
  {
  }
}
