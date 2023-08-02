using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG.Infrastructure.Utils.Swipe;

public class Movement : MonoBehaviour
{

    public float movementSpeed = 2.0f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private SwipeListener swipe;

    void OnEnable() {
        swipe.OnSwipe.AddListener(OnSwipe);
    }

    void OnSwipe(string swipe) {
        switch (swipe) {
            case "Up":
                movementDirection = Vector2.up;
                break;
            case "Down":
                movementDirection = Vector2.down;
                break;
            case "Right":
                movementDirection = Vector2.right;
                break;
            case "Left":
                movementDirection = Vector2.left;
                break;
        }
    }

    void OnDisable() {
        swipe.OnSwipe.RemoveListener(OnSwipe);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void FixedUpdate() {
        rb.velocity = movementDirection * movementSpeed * Time.deltaTime;
    }
}
