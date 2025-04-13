using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript2D : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform player;
    [SerializeField] private BoxCollider2D enteringBoss1;
    [SerializeField] private GameObject boss1;

    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    private Vector3 offset = new Vector3(0f, -0.5f, -10f);
    private Vector3 bossLockedPos;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (boss1.GetComponent<Boss1Script>().isAlive == false)
        {
            Vector3 playerPos = player.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, playerPos + new Vector3(0f, 2f, 0f), ref velocity, smoothTime);
        }
        else if(boss1.GetComponent<Boss1Script>().isAlive == true)
        {
            transform.position = Vector3.SmoothDamp(transform.position, boss1.transform.position + new Vector3(0f, -5f, -10f), ref velocity, smoothTime);
        }
    }

    private void Update()
    {
        if (EnteringBossScene())
        {
            gameObject.GetComponent<Camera>().orthographicSize = 10f;
            boss1.GetComponent<Boss1Script>().isAlive = true;          
        }
    }

    private bool EnteringBossScene()
    {
        return enteringBoss1.OverlapPoint(player.position);
    }
}
