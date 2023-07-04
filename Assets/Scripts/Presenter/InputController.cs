using System;
using Tanks;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : IController, IFixedExecute, IDisposable
{
    public event Action<IController> EvtNeedDestroy;

    private PlayerInput _input;
    private TankModel _tankModel;
    private TankView _tankView;

    private Vector2 _moveDirection;
    private Vector2 _mosWorldPos;

    public InputController(TankModel tankModel, TankView tankView)
    {
        _tankModel = tankModel;
        _tankView = tankView;
        _input = new PlayerInput();
        _input.Enable();
        _input.Player.Shoot.performed += context => _tankModel.ShootGun();
    }

    public void FixedExecute(float deltaTime)
    {
        _moveDirection = _input.Player.Move.ReadValue<Vector2>();
        _tankModel.MoveDirection.Value = _moveDirection;
        Debug.Log($"Input {_moveDirection}");

        HandleTurretMovement();
    }
    
    private void HandleTurretMovement()
    {
        Vector3 mosPos = Mouse.current.position.ReadValue();
        mosPos.z = Camera.main.nearClipPlane;
        _mosWorldPos = Camera.main.ScreenToWorldPoint(mosPos);
        _tankModel.MousPosition.Value = _mosWorldPos;
    }

    public void Dispose()
    {
        // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
        _input.Player.Shoot.performed -= context => _tankModel.ShootGun();
        _input?.Dispose();
        _input.Disable();
    }
}
