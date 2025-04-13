using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float speed = 0.33f;
    [SerializeField] private CircleCollider2D circleCollider;
    [SerializeField] private LayerMask ground;

    private float cooldown = 5f;
    private float untilCooldown = 0f;
    private GameObject target;

    // Update is called once per frame
    private void Start()
    {
        target = new GameObject();
        var playerPos = GameObject.Find("Player").transform.position;
        target.transform.position = (playerPos - transform.position)  * 100f;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed);

        untilCooldown += Time.deltaTime;
        if(untilCooldown > cooldown)
        {
            Destroy(target);
            Destroy(gameObject);
        }
        if (touchedSmth())
        {
            Destroy(target);
            Destroy(gameObject);
        }
    }

    private bool touchedSmth()
    {
        return Physics2D.OverlapCircle(transform.position, 0.1f, ground);
    }
}
