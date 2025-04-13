using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoCamera : MonoBehaviour
{
    // Start is called before the first frame update
    Transform player_transform;
    void Start()
    {
        player_transform = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player_transform.position.x,player_transform.position.y,transform.position.z);

    }
}
