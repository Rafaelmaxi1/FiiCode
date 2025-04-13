using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private CircleCollider2D circleCollider;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject exclam;

    private float cooldown = 3f;
    private float untilCooldown = 0f;
    private float movespeed = 10f;

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2( Mathf.Clamp(rb.velocity.x, -5f, 5f), rb.velocity.y);

        if (circleCollider.OverlapPoint(player.position))
        {
            Vector2 magnitude = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
            if (Mathf.Abs(magnitude.x) > 3f)
            {
                rb.AddForceAtPosition(new Vector2(Mathf.Clamp(magnitude.x, -1f, 1f) * movespeed, 0f), player.position);
            }
            else
            {
                rb.velocity = new Vector2(0f, rb.velocity.y);
            }
            if (untilCooldown > cooldown - 1f)
            {
                exclam.active = true;
            }
            else
            {
                exclam.active = false;
            }
            if(untilCooldown > cooldown)
            {
                untilCooldown = 0f;
                Shoot();
            }
        }

        untilCooldown += Time.deltaTime;
    }
    private void Shoot()
    {
        var newBullet = Instantiate(bullet);
        newBullet.transform.position = transform.position;

        var playerPos = GameObject.Find("Player").transform.position;
        Vector2 dir = playerPos - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        newBullet.transform.rotation = Quaternion.Euler(0, 0, angle);

    }
}