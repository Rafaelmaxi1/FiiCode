using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    [SerializeField] private AudioSource audioSource;

    private bool chestWasOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        sr.sprite = chestClosed;
    }

    // Update is called once per frame
    void Update()
    {
        if (nearChest()){
            GameObject.Find("Text (TMP)1").GetComponent<TextMeshProUGUI>().text = "Press 'F' to open";
            if (Input.GetKeyDown(KeyCode.F) && !chestWasOpened)
            {
                chestWasOpened = true;
                sr.sprite = chestOpened;
                particleSystem.GetComponent<ParticleSystem>().enableEmission = true;
                particleSystem.GetComponent<ParticleSystem>().Emit(150);
                var newHlai = Instantiate(hlai);
                newHlai.transform.position = transform.position;
                newHlai.GetComponent<HLAIScript>().point1 = point;
                audioSource.Play();
            }
        }
        else
        {
            GameObject.Find("Text (TMP)1").GetComponent<TextMeshProUGUI>().text = "";
        }
    }

    private bool nearChest()
    {
        return cc.OverlapPoint(player.position);
    }
}
