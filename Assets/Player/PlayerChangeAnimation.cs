using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeAnimation : MonoBehaviour
{
    [SerializeField]Animator AnimatorController;
    [SerializeField] Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity != Vector2.zero)
            AnimatorController.SetBool("IsMoving", true);
        else
            AnimatorController.SetBool("IsMoving", false);
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            AnimatorController.SetInteger("Direction", 1);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            AnimatorController.SetInteger("Direction", 3);
        }
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            AnimatorController.SetInteger("Direction", 2);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            AnimatorController.SetInteger("Direction", 4);
        }
    }
}
