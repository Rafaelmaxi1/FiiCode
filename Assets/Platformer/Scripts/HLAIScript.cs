using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HLAIScript : MonoBehaviour
{
    public Transform point1;

    private Vector2 speed = Vector2.zero;
    private Vector3 offset = new Vector3(1f, 0f, 0f);
    private float horizontalAxis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (Input.GetAxisRaw("Horizontal") != 0f)
        {
            horizontalAxis = Input.GetAxisRaw("Horizontal");
        }
        
        Vector2 hoverPos = point1.position + new Vector3(horizontalAxis * -1f, 0f, 0f);
        transform.position = Vector2.SmoothDamp(transform.position, hoverPos,ref speed, 0.15f);
    }
}
