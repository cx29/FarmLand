using System;
using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField]
   private float _speed;
   private Rigidbody2D _rigidbody2D;
   private Vector2 movement;

   private void Awake()
   {
      _rigidbody2D = GetComponent<Rigidbody2D>();
   }

   private void Update()
   {
      PlayerInput();
   }

   private void FixedUpdate()
   {
      Move();
   }

   private void PlayerInput()
   {
      float horizontal = Input.GetAxis("Horizontal");
      float vertical = Input.GetAxis("Vertical");
      movement = horizontal != 0 || vertical != 0 ? new Vector2(horizontal, vertical).normalized : Vector2.zero;
   }

   private void Move()
   {
      var distance = _rigidbody2D.position + movement * (_speed * Time.deltaTime);
      _rigidbody2D.MovePosition(distance);
   }
}
