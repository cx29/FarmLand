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
      //只有在斜向移动的时候才进行归一化计算，减小垂直水平行走时不必要的计算开销
      movement=new Vector2(horizontal,vertical);
      if (movement.sqrMagnitude > 1)
      {
         movement.Normalize();
      }
   }

   private void Move()
   {
      var distance = _rigidbody2D.position + movement * (_speed * Time.deltaTime);
      _rigidbody2D.MovePosition(Vector2.Lerp(_rigidbody2D.position, distance, 0.5f));
   }
}
