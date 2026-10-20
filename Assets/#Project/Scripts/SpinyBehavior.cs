using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpinyBehavior : MonoBehaviour
{
[SerializeField] private float speed = -5f;
[SerializeField] private float offsetCheckVoid = 0.5f;
private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector2 origin = transform.position + offsetCheckVoid * (speed > 0 ? Vector3.right: Vector3.left);
        Vector2 direction = Vector2.down;

        Debug.DrawRay(origin, direction, Color.cyan);
        
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, 2f);
        if(hit.collider == null)
        {
            speed *= -1;
            spriteRenderer.flipX = speed > 0;
        }

        transform.Translate(speed * Time.deltaTime * Vector2.right);
    }
}
