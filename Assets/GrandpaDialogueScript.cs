using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandpaDialogueScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Player")
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = audioClip;
                audioSource.Play();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
