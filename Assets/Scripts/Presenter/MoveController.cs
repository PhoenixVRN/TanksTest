using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveController 
{
  public int moveSpeed;
  public int moveRotation;
  public float moveRotationTurret;
  public Transform TurretParent;
  private Vector2 _moveDirection;
  private Rigidbody2D _rb;

  private Vector3 _mosWorldPos;

  private PlayerInput _input;
  private void Awake()
  {
    _input = new PlayerInput();
    _input.Player.Shoot.performed += context => Shoot();
    
  }
  

  public void OnMove(InputAction.CallbackContext context)
  {
    _moveDirection = context.ReadValue<Vector2>();
  }

  private void FixedUpdate()
  {
    _moveDirection = _input.Player.Move.ReadValue<Vector2>();
    Move(_moveDirection);
    HandleTurretMovement();
  }
  
  // public void OnShoot(InputAction.CallbackContext context)
  // {
  //   Debug.Log("Shoot");
  // }
  private void Move(Vector2 dir)
  {
    var dirnormal = dir.normalized;
    float speed = moveSpeed * Time.deltaTime;
    Vector3 moveDirection = new Vector3(dir.x, dir.y, 0);
    Vector2 moveDir = (Vector2) _rb.transform.up * dirnormal.y * speed * Time.deltaTime;
    _rb.velocity = moveDir;
    int revers = dir.y < 0 ? 1 : -1 ;
    _rb.MoveRotation(_rb.transform.rotation * Quaternion.Euler(0, 0, dirnormal.x * moveRotation * Time.deltaTime * revers));
  }

  private void HandleTurretMovement()
  {
    Vector3 mosPos = Mouse.current.position.ReadValue();
    mosPos.z = Camera.main.nearClipPlane;
    _mosWorldPos = Camera.main.ScreenToWorldPoint(mosPos);
    var turretDirection = (Vector3) _mosWorldPos - _rb.transform.position;
    var deseredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg;
    var rotationStep = moveRotationTurret * Time.deltaTime;
    TurretParent.rotation = Quaternion.RotateTowards(TurretParent.rotation, Quaternion.Euler( 0,0,deseredAngle), rotationStep);
  }
  private void Shoot()
  {
    Debug.Log("Shoot");
  }
  
  private void OnEnable()
  {
     _input.Enable();
  }

  private void OnDisable()
  {
     _input.Disable();
  }
}
