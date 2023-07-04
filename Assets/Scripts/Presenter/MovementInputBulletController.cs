using System;
using Tanks;
using UnityEngine;

public class MovementInputBulletController :  IController,IExecute, IDisposable
{
    private BulletView _bulletView;
    private BulletModel _bulletModel;
    public MovementInputBulletController (BulletModel bulletModel , BulletView bulletView)
    {
        _bulletView = bulletView;
        _bulletModel = bulletModel;
        // _heroModel.СollisionModelEvt += Delay;
    }

   
    private void Kill()
    {
        Debug.Log("Kill");
        // _heroModel.KillUnitEvt?.Invoke();
    }
   
    public void Execute(float deltaTime)
    {
        // InputMoveHiro(_heroModel.SpeedMove, deltaTime);
    }
    
    public void InputMoveHiro(int speed, float deltaTime)
    {
        // _heroModel.Move = _viewHero.transform.forward  * speed * deltaTime;
        // _heroModel.Rotate =_viewHero.transform.up * Input.GetAxis("Horizontal") * rotateSpeed * deltaTime;
    }
    public void Dispose()
    {
        // _heroModel.СollisionModelEvt -= _heroModel.KillUnitEvt;
    }

    public event Action<IController> EvtNeedDestroy;
}
