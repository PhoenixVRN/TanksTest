using System;
using Tanks;
using UnityEngine;

public class CollisionController : IController,IDisposable
{
    private BulletView _bulletView;
    private BulletModel _bulletModel;
    
    public CollisionController(BulletModel bulletModel, BulletView bulletView)
    {
        _bulletView = bulletView;
        _bulletModel = bulletModel;
        // _viewHero.СollisionEvt += obj => CollisionHeroHandler(obj);
    }

    private void CollisionHeroHandler(GameObject obj)
    {
        // _heroModel.СollisionModelEvt?.Invoke();
        Debug.Log($"Hero столкнулся с {obj}");
    }
    public void Dispose()
    {
        // _viewHero.СollisionEvt -= obj => CollisionHeroHandler(obj); 
    }

    public event Action<IController> EvtNeedDestroy;
}
