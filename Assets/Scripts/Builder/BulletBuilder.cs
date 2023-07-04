using System.Collections;
using System.Collections.Generic;
using Tanks;
using UnityEngine;

public class BulletBuilder
{
    private MovementInputBulletController _movementInputBulletController;
    private MovementBulletController _movementBulletController;
    private CollisionController _collisionController;
    private BulletModel _bulletModel;
    
    public BulletBuilder()
    {
        var bullet = Resources.Load("Unit/Bullet", typeof(GameObject)) as GameObject;
        var bulletActive = Object.Instantiate(bullet, new Vector3(0, 0, 0), Quaternion.identity);
        bulletActive.transform.SetParent(Reference.ActiveElements);
        var builder = bulletActive.GetComponent<BulletDataCfg>();
        _bulletModel = new BulletModel(builder.SpeedMove, builder.Damage, builder.FlightTime);

        _movementInputBulletController =
            new MovementInputBulletController(_bulletModel, bulletActive.GetComponent<BulletView>());
        _movementBulletController = 
            new MovementBulletController(_bulletModel, bulletActive.GetComponent<BulletView>());
        _collisionController = 
            new CollisionController(_bulletModel, bulletActive.GetComponent<BulletView>());
        
        ListControllers.Add( _movementInputBulletController);
        ListControllers.Add( _movementBulletController);
        ListControllers.Add(  _collisionController);
    }
}
