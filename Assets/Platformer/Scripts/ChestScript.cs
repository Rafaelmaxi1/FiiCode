using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    [SerializeField] private Sprite chestOpened;
    [SerializeField] private Sprite chestClosed;
    [SerializeField] private CircleCollider2D cc;
    [SerializeField] private Transform player;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private GameObject particleSystem;
    [SerializeField] private GameObject hlai;
    [SerializeField] private Transform point;

    private bool chestWasOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        sr.sprite = chestClosed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(nearChest() && Input.GetKeyDown(KeyCode.F) && !chestWasOpened)
        {
            chestWasOpened = true;
            sr.sprite = chestOpened;
            particleSystem.GetComponent<ParticleSystem>().enableEmission = true;
            particleSystem.GetComponent<ParticleSystem>().Emit(150);
            var newHlai = Instantiate(hlai);
            newHlai.transform.position = transform.position;
            newHlai.GetComponent<HLAIScript>().point1 = point;
        }
    }

    private bool nearChest()
    {
        return cc.OverlapPoint(player.position);
    }
}
