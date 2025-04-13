using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidBulletScript : MonoBehaviour
{
    // Update is called once per frame
    public Transform player;
    public Vector3 startDir;

    public LayerMask layerMask;

    private float speed = 0.1f;
    bool finishedStart = false;
    private float timer = 0f;

    bool created = false;

    private AudioSource audioSource;
    public AudioClip shootAudio;

    GameObject dir;
    private void Start()
    {
        dir = new GameObject();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = shootAudio;
        audioSource.Play();
    }
    void FixedUpdate()
    {
        if (touchedSmth())
        {
            Destroy(dir);
            Destroy(gameObject);
        }
        timer += Time.deltaTime;
        if (!created && timer > 1.5f)
        {
            created = true;
            dir.transform.position = new Vector3(player.position.x - transform.position.x, player.position.y - transform.position.y, transform.position.z) * 100f;
        }
        if (timer <= 0.75f)
        {
            transform.position += startDir * speed;
        }
        else if(timer > 0.75f && timer <= 1.5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed);
        }
        else if(timer > 1.5f && timer <= 4f)
        {
            transform.position = Vector2.MoveTowards(transform.position, dir.transform.position, speed);
        }
        else
        {
            Destroy(dir);
            Destroy(gameObject);
        }
    }

    private bool touchedSmth()
    {
        return Physics2D.OverlapCircle(transform.position, 0.1f, layerMask);
    }
}
