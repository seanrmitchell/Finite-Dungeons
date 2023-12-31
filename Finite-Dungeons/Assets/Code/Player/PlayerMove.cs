using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public Controller playerMove;

    [SerializeField]
    private float speed, smoothMove;

    private Rigidbody2D player;

    private Vector2 move, mousePos;

    private Vector2 baseVel = Vector2.zero;

    void Awake()
    {
        playerMove = new Controller();
    }

    private void OnEnable()
    {
        playerMove.Enable();
    }

    private void OnDisable()
    {
        playerMove.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Reads in mouse position on screen translated to vector 2
        // Converts the position to a world point in engine
        mousePos = Mouse.current.position.ReadValue();
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        // Distance between player and mouse is calculated & used to calculate angle based on tan y/x
        Vector2 rotation = worldPos - transform.position;
        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg - 90f;

        // Applies rotation in euler angles on the z-axis (2D rotation axis)
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // Calculates player vector2 movement from keys and applies to player
        move = playerMove.Movement.Strafe.ReadValue<Vector2>();
        player.velocity = Vector2.SmoothDamp(player.velocity, move * speed, ref baseVel, smoothMove);
    }
}
