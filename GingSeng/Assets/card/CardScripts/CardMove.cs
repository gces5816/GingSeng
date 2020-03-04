using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class CardMove : MonoBehaviour
{

    public GameObject ltext;
    public GameObject rtext;
    public GameObject FMNJCardPrefab;

    static public int destroy;
    static public int isleft;
    static public int isright;

    private Vector3 Distance;
    private float checkX, checkY;
    private Vector3 mousePosition;
    private Rigidbody2D rb;
    private Vector2 direction;
    private float moveSpeed = 400f;
    private float minRotation = -14;
    private float maxRotation = 14;
    public float minPosX = -100f;
    public float maxPosX = 100f;

    public artend artend;
    public medicalend medicalend;
    public businessend businessend;
    public scienceend scienceend;
    public miserable miserable;
    public ghost ghost;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        destroy = 0;
        isleft = 0;
        isright = 0;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isleft = 0;
            isright = 0;
            Distance = Camera.main.WorldToScreenPoint(transform.position);
            checkX = Mathf.Abs(Input.mousePosition.x - Distance.x);
            checkY = Input.mousePosition.y - Distance.y;
            if (checkX <= 120f)
            {
                if (-300f <= checkY && checkY <= 300f)
                {
                    mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    direction = (mousePosition - transform.position).normalized;
                    rb.velocity = new Vector2(direction.x * moveSpeed, 0);
                }
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            if (GetComponent<Transform>().position.x < -0.2)
            {
                destroy = 1;
                isleft = 1;
                whether();
            }
            if (GetComponent<Transform>().position.x > 0.2)
            {
                destroy = 1;
                isright = 1;
                whether();
            }
        }

        if (GetComponent<Transform>().position.x < -0.4)
        {
            transform.Rotate(Vector3.forward, 5);
            RotateLimit();
            rtext.SetActive(false);
            ltext.SetActive(true);
        }
        else if (GetComponent<Transform>().position.x > 0.4)
        {
            transform.Rotate(Vector3.forward, -5);
            RotateLimit();
            rtext.SetActive(true);
            ltext.SetActive(false);
        }
        else
        {
            transform.rotation = Quaternion.identity;
            rtext.SetActive(false);
            ltext.SetActive(false);
        }
    }

    private void RotateLimit()
    {
        Vector3 currentRotation = transform.localRotation.eulerAngles;
        if (GetComponent<Transform>().position.x < -0.4)
        {
            currentRotation.z = Mathf.Clamp(currentRotation.z, minRotation, maxRotation);
        }
        else if (GetComponent<Transform>().position.x > 0.4)
        {
            currentRotation.z = Mathf.Clamp(currentRotation.z, maxRotation, minRotation);
        }
        transform.localRotation = Quaternion.Euler(currentRotation);
    }

    void whether()
    {
        long tick = DateTime.Now.Ticks;
        System.Random ran = new System.Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
        int end;

        if (GameManager.joke == 1)
        {
            if (CardMove.isleft == 1)
            {
                BarChange.img = "ghostleft/" + ghost.dataArray[GameManager.cardnum].Limage;
            }
            else if (CardMove.isright == 1)
            {
                BarChange.img = "ghostright/" + ghost.dataArray[GameManager.cardnum].Rimage;
            }
            changescenes.FromScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(6);
        }

        if (BarChange.MOmax == true && BarChange.puma == 5) 
        {
            BarChange.img = "ends/m1";
            changescenes.FromScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(6);
        }
        if (BarChange.Fzero == true || BarChange.Hzero == true || BarChange.SMzero == true || BarChange.Azero == true || BarChange.SOzero == true)
        {
            end = ran.Next(0, 11);
            BarChange.img = "miserable/" + miserable.dataArray[end].Image;
            changescenes.FromScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(6);
        }
        if (BarChange.Mzero == true)
        {
            end = ran.Next(1, 4);
            if (end == 1)
            {
                BarChange.img = "miserable/" + miserable.dataArray[1].Image;
            }
            else if (end == 2)
            {
                BarChange.img = "miserable/" + miserable.dataArray[5].Image;
            }
            else if (end == 3)
            {
                BarChange.img = "miserable/" + miserable.dataArray[6].Image;
            }
            else if (end == 4)
            {
                BarChange.img = "miserable/" + miserable.dataArray[9].Image;
            }
            changescenes.FromScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(6);
        }
        if (BarChange.SMmaximun == true)
        {
            if (changescenes.volunteer == "medical")
            {
                end = ran.Next(0, 3);
                BarChange.img = "medicalends/" + medicalend.dataArray[end].Image;
            }
            else if (changescenes.volunteer == "business")
            {
                end = ran.Next(0, 3);
                BarChange.img = "businessends/" + businessend.dataArray[end].Image;
            }
            else if (changescenes.volunteer == "art")
            {
                end = ran.Next(0, 3);
                BarChange.img = "artends/" + artend.dataArray[end].Image;
            }
            else if (changescenes.volunteer == "science")
            {
                end = ran.Next(0, 3);
                BarChange.img = "scienceend/" + scienceend.dataArray[end].Image;
            }
            changescenes.FromScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(6);
        }
        if (BarChange.Amaximun == true)
        {
            if (changescenes.volunteer == "medical")
            {
                end = ran.Next(4, 8);
                BarChange.img = "medicalends/" + medicalend.dataArray[end].Image;
            }
            else if (changescenes.volunteer == "business")
            {
                end = ran.Next(4, 8);
                BarChange.img = "businessends/" + businessend.dataArray[end].Image;
            }
            else if (changescenes.volunteer == "art")
            {
                end = ran.Next(4, 8);
                BarChange.img = "artends/" + artend.dataArray[end].Image;
            }
            else if (changescenes.volunteer == "science")
            {
                end = ran.Next(4, 8);
                BarChange.img = "scienceend/" + scienceend.dataArray[end].Image;
            }
            changescenes.FromScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(6);
        }
        if (BarChange.SOmaximun == true)
        {
            if (changescenes.volunteer == "medical")
            {
                end = ran.Next(9, 12);
                BarChange.img = "medicalends/" + medicalend.dataArray[end].Image;
            }
            else if (changescenes.volunteer == "business")
            {
                end = ran.Next(9, 14);
                BarChange.img = "businessends/" + businessend.dataArray[end].Image;
            }
            else if (changescenes.volunteer == "art")
            {
                end = ran.Next(9, 13);
                BarChange.img = "artends/" + artend.dataArray[end].Image;
            }
            else if (changescenes.volunteer == "science")
            {
                end = ran.Next(9, 12);
                BarChange.img = "scienceend/" + scienceend.dataArray[end].Image;
            }
            changescenes.FromScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(6);
        }
    }
}