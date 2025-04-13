using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject text;
    [SerializeField]Image panel;
    [SerializeField] Vector2 whereToTp;
    Transform player_transform;
    Rigidbody2D rb;
    Animator animator;
    [SerializeField]DemoMovement movement;
    bool blakenScreen = false,unblakenScreen=false;
    private void Start()
    {
        text.SetActive(false);
        player_transform = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent <Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.E) && text.activeSelf) 
        {
            animator.SetBool("IsMoving", false);
            movement.inAnimation = true;
            blakenScreen = true;
        }
        if (unblakenScreen)
        {
            rb.velocity = Vector2.up;
            if (panel.color.a <=-0.25f)
            {
                movement.inAnimation = false;
                panel.color = new Color(0, 0, 0, 0);
                unblakenScreen = false;
                panel.color = new Color(0, 0, 0, panel.color.a - 0.7f * Time.deltaTime);
            }
            panel.color = new Color(0, 0, 0, panel.color.a - 0.7f * Time.deltaTime);
        }
        if(blakenScreen)
        {
            if(panel.color.a >= 1)
            {
                animator.SetInteger("Direction", 2);
                animator.SetBool("IsMoving", true);
                blakenScreen = false;
                player_transform.position = whereToTp;
                unblakenScreen = true;
            }
                
            panel.color = new Color(0, 0, 0, panel.color.a + 0.7f * Time.deltaTime);
        }
    }
    
}
