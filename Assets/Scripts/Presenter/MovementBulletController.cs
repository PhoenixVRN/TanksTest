using System;
using Tanks;

public class MovementBulletController: IController, IDisposable
{
    private BulletView _bulletView;
    private BulletModel _bulletModel;

    public MovementBulletController(BulletModel bulletModel, BulletView bulletView)
    {
        _bulletView = bulletView;
        _bulletModel = bulletModel;
    }

    public void Execute(float deltaTime)
    {
        MoveHiro();
    }

    public void MoveHiro()
    {
        // _viewHero.Rb.velocity = _modelHero.Move;
        // _viewHero.transform.Rotate(_modelHero.Rotate);
    }
    
    public void Dispose()
    {
    }

    public event Action<IController> EvtNeedDestroy;
}
