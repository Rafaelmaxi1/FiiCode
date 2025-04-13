using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = System.Random;

public class Boss1Script : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform player;
    [SerializeField] private GameObject bulletVoid;
    [SerializeField] private LayerMask layerMask;

    [SerializeField] private AudioClip bossFightMusic;
    private AudioSource audioSource;

    [SerializeField] private GameObject number1;
    [SerializeField] private GameObject number2;
    [SerializeField] private GameObject number3;
    [SerializeField] private GameObject number4;
    [SerializeField] private GameObject number5;
    [SerializeField] private GameObject number6;
    [SerializeField] private GameObject number7;
    [SerializeField] private GameObject number8;
    [SerializeField] private GameObject number9;
    [SerializeField] private GameObject number10;
    [SerializeField] private GameObject plusSign;
    [SerializeField] private GameObject multiplySign;
    [SerializeField] private GameObject equalSign;
    [SerializeField] private GameObject questionSign;

    private Vector3 offset = new Vector3(0f, 10f, 0f);
    private float smoothTime = 0.5f;
    private Vector3 velocity = Vector3.zero;

    public bool isAlive = true;
    public int numberOfLives;

    private float cooldownBullets = 5f;
    private float untilCooldownBullets = 0f;

    private float cooldownQuestion = 10f;
    private float untilCooldownQuestion = 0f;

    private string[] questions = new string[] { "3 + 4 = 7 ? 1 8 3", "2 + 2 = 4 ? 9 6 3", "7 + 1 = 8 ? 6 1 3", "1 + 1 = 2 ? 7 4 5", "6 + 4 = 10 ? 9 1 8", "2 x 2 = 4 ? 7 3 8", "2 x 3 = 6 ? 7 5 10", "2 x 5 = 10 ? 3 7 9", "1 x 5 = 5 ? 2 3 8" };

    // Update is called once per frame
    private void Start()
    {
        numberOfLives = 5;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bossFightMusic;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            audioSource.clip = bossFightMusic;
            audioSource.Play();
        }
    }
    void FixedUpdate()
    {
        if (numberOfLives <= 0)
        {
            GameObject.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "YOU WON!";
            Destroy(gameObject);
            isAlive = false;
        }
        else
        {
            GameObject.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "";
        }
        if (!isAlive)
        {
            return;
        }
        if(cooldownBullets <= untilCooldownBullets)
        {
            untilCooldownBullets = 0f;
            shootBullets();

        }
        if(cooldownQuestion <= untilCooldownQuestion)
        {
            untilCooldownQuestion = 0f;
            putQuestions();
        }

        untilCooldownBullets += Time.deltaTime;
        untilCooldownQuestion += Time.deltaTime;
    }
    private void shootBullets()
    {
        var newBullet1 = Instantiate(bulletVoid);
        newBullet1.transform.position = transform.position;
        newBullet1.GetComponent<VoidBulletScript>().startDir = new Vector3(1f, -1f, 0f);
        newBullet1.GetComponent<VoidBulletScript>().player = player;
        newBullet1.GetComponent<VoidBulletScript>().layerMask = layerMask;

        var newBullet2 = Instantiate(bulletVoid);
        newBullet2.transform.position = transform.position;
        newBullet2.GetComponent<VoidBulletScript>().startDir = new Vector3(-1f, -1f, 0f);
        newBullet2.GetComponent<VoidBulletScript>().player = player;
        newBullet2.GetComponent<VoidBulletScript>().layerMask = layerMask;

        var newBullet3 = Instantiate(bulletVoid);
        newBullet3.transform.position = transform.position;
        newBullet3.GetComponent<VoidBulletScript>().startDir = new Vector3(0f, -1f, 0f);
        newBullet3.GetComponent<VoidBulletScript>().player = player;
        newBullet3.GetComponent<VoidBulletScript>().layerMask = layerMask;
    }

    private void putQuestions()
    {
        Random rand = new Random();
        int currentQuestion = rand.Next(0, questions.Length);

        string[] txt = questions[currentQuestion].Split(' ');
        Debug.Log(txt);

        GameObject sign = Instantiate(findNumberByString(txt[1]));
        sign.transform.position = transform.position + new Vector3(0f, 3f, 0f);
        sign.GetComponent<NumberScript>().isNumber = false;

        GameObject firstNumber = Instantiate(findNumberByString(txt[0]));
        firstNumber.transform.position = sign.transform.position + new Vector3(-2f, 0f, 0f);
        firstNumber.GetComponent<NumberScript>().isNumber = false;

        GameObject secondNumber = Instantiate(findNumberByString(txt[2]));
        secondNumber.transform.position = sign.transform.position + new Vector3(2f, 0f, 0f);
        secondNumber.GetComponent<NumberScript>().isNumber = false;

        GameObject equalSign = Instantiate(findNumberByString(txt[3]));
        equalSign.transform.position = secondNumber.transform.position + new Vector3(2f, 0f, 0f);
        equalSign.GetComponent<NumberScript>().isNumber = false;

        GameObject correctNumber = Instantiate(findNumberByString(txt[4]));
        correctNumber.transform.position = transform.position + new Vector3(-3f, 0f, 0f);
        correctNumber.GetComponent<NumberScript>().isNumber = true;
        correctNumber.GetComponent<NumberScript>().isCorrect = true;
        correctNumber.GetComponent<NumberScript>().player = player;

        GameObject questionMark = Instantiate(findNumberByString(txt[5]));
        questionMark.transform.position = equalSign.transform.position + new Vector3(2f, 0f, 0f);
        questionMark.GetComponent<NumberScript>().isNumber = false;

        GameObject wrongNumber1 = Instantiate(findNumberByString(txt[6]));
        wrongNumber1.transform.position = correctNumber.transform.position + new Vector3(-2f, 0f, 0f);
        wrongNumber1.GetComponent<NumberScript>().isNumber = true;
        wrongNumber1.GetComponent<NumberScript>().isCorrect = false;
        wrongNumber1.GetComponent<NumberScript>().player = player;

        GameObject wrongNumber2 = Instantiate(findNumberByString(txt[7]));
        wrongNumber2.transform.position = transform.position + new Vector3(3f, 0f, 0f);
        wrongNumber2.GetComponent<NumberScript>().isNumber = true;
        wrongNumber2.GetComponent<NumberScript>().isCorrect = false;
        wrongNumber2.GetComponent<NumberScript>().player = player;

        GameObject wrongNumber3 = Instantiate(findNumberByString(txt[8]));
        wrongNumber3.transform.position = wrongNumber2.transform.position + new Vector3(2f, 0f, 0f);
        wrongNumber3.GetComponent<NumberScript>().isNumber = true;
        wrongNumber3.GetComponent<NumberScript>().isCorrect = false;
        wrongNumber3.GetComponent<NumberScript>().player = player;

    }

    private GameObject findNumberByString(string numberText)
    {
        switch (numberText)
        {
            case "1":
                return number1;
            case "2":
                return number2;
            case "3":
                return number3;
            case "4":
                return number4;
            case "5":
                return number5;
            case "6":
                return number6;
            case "7":
                return number7;
            case "8":
                return number8;
            case "9":
                return number9;
            case "10":
                return number10;
            case "+":
                return plusSign;
            case "=":
                return equalSign;
            case "?":
                return questionSign;
            case "x":
                return multiplySign;
        }
        return new GameObject();
    }
}
