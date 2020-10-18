using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurglarMovement : MonoBehaviour
{
    [SerializeField]private bool _isLookingToRight;
    [SerializeField] private float _speed = 3;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        if (xAxis < 0 && _isLookingToRight)
            FlipSpriteX();
        else if (xAxis > 0 && !_isLookingToRight)
            FlipSpriteX();
        transform.position += new Vector3(xAxis, yAxis) * _speed * Time.fixeDeltaTime;
    }

    private void FlipSpriteX()
    {
        _isLookingToRight = !_isLookingToRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
}
