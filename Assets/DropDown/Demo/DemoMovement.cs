using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class DemoMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] Rigidbody2D rb;
    public bool inAnimation = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inAnimation) return;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vetical = Input.GetAxisRaw("Vertical");
        var movement = new Vector2(horizontal, vetical).normalized;
        rb.velocity = movement*movementSpeed;
    }
}
