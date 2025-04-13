using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float speed = 0.1f;
    public bool isCorrect;
    public bool isNumber;

    private float cooldown = 0f;
    private bool touched = false;
    
    void Start()
    {
        if(isNumber == true)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cooldown += Time.deltaTime;
        if (cooldown > 4f)
        {
            Destroy(gameObject);
        }

        if (isNumber == false)
        {
            return;
        }
        if (playerTouched() && touched == false)
        {
            touched = true;
            if(isCorrect == false)
            {
                Debug.Log("Au murit");
            }
            else
            {
                Debug.Log("Brabo");
                try
                {
                    GameObject.Find("BOMBadon-Sheet_0").GetComponent<Boss1Script>().numberOfLives -= 1;
                    Debug.Log(GameObject.Find("BOMBadon-Sheet_0").GetComponent<Boss1Script>().numberOfLives);
                }
                catch
                {
                    Debug.Log("Boss wasn't found!");
                }
            }
        }

        if (cooldown >= 1.5f && cooldown <= 4f)
        {
            transform.position = transform.position - new Vector3(0f, speed, 0f);
        }

    }

    private bool playerTouched()
    {
        return gameObject.GetComponent<BoxCollider2D>().OverlapPoint(player.position);
    }
}
