using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerControler : MonoBehaviour
{
    private const string ACTION_MAP = "Game";
    private const string MOVE_ACTION = "Move";
    private const string ANIMATION_SPEED = "speed";
    
    [SerializeField] private InputActionAsset inputActions;
    [SerializeField] private float speed = 5f;
    private InputAction moveAction;
    private Animator animator;
    private SpriteRenderer spriteRenderer;



    void Awake()
    {
        moveAction = inputActions.FindActionMap(ACTION_MAP).FindAction(MOVE_ACTION);
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        inputActions.FindActionMap(ACTION_MAP).Enable();
    }    
    
    void OnDisable()
    {
        inputActions.FindActionMap(ACTION_MAP).Disable();
    }

    void Update()
    {
        float velocity = moveAction.ReadValue<float>() * speed;
        animator.SetFloat(ANIMATION_SPEED, Mathf.Abs(velocity));
        spriteRenderer.flipX = velocity < 0;
        Vector2 movement =  velocity * Time.deltaTime * Vector2.right;
        transform.Translate(movement);
    }
}
