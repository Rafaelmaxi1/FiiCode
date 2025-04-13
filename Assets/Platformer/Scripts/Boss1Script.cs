using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Script : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform player;
    [SerializeField] private GameObject bulletVoid;

    private Vector3 offset = new Vector3(0f, 10f, 0f);
    private float smoothTime = 0.5f;
    private Vector3 velocity = Vector3.zero;

    public bool isAlive = true;

    private float cooldown = 5f;
    private float untilCooldown = 0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isAlive)
        {
            return;
        }

        if(cooldown <= untilCooldown)
        {
            untilCooldown = 0f;
            shootBullets();

        }

        untilCooldown += Time.deltaTime;
    }
    private void shootBullets()
    {
        var newBullet1 = Instantiate(bulletVoid);
        newBullet1.transform.position = transform.position;
        newBullet1.GetComponent<VoidBulletScript>().startDir = new Vector3(1f, -1f, 0f);
        newBullet1.GetComponent<VoidBulletScript>().player = player;

        var newBullet2 = Instantiate(bulletVoid);
        newBullet2.transform.position = transform.position;
        newBullet2.GetComponent<VoidBulletScript>().startDir = new Vector3(-1f, -1f, 0f);
        newBullet2.GetComponent<VoidBulletScript>().player = player;

        var newBullet3 = Instantiate(bulletVoid);
        newBullet3.transform.position = transform.position;
        newBullet3.GetComponent<VoidBulletScript>().startDir = new Vector3(0f, -1f, 0f);
        newBullet3.GetComponent<VoidBulletScript>().player = player;
    }
}
