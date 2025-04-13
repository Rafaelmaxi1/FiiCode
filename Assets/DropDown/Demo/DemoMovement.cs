using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private LayerMask sceneChanger;
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

        if (hitByScene())
        {
            Debug.Log("DAA");
            try
            {
                if (GameObject.Find("SceneChange").tag == "Platformer")
                {
                    SceneManager.LoadScene("Platformer 1");
                }
                if (GameObject.Find("SceneChange").tag == "Boss")
                {

                    SceneManager.LoadScene("Bossfight");
                }
            }
            catch
            {
                Debug.Log("Object doesn't exist!");
            }
        }
        
    }
    private bool hitByScene()
    {
        return Physics2D.OverlapCircle(transform.position, 0.5f, sceneChanger);
    }
}
