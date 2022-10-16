using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    GameObject light;
    public bool isDropApple = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    GameObject timerText;
    GameObject pointText;
    GameObject generator;
    float time = 30.0f;
    int point = 0;


    public void GetApple()
    {
        point += 100;
    }
    public void Getbomb()
    {
        point /= 2;
        Debug.Log("point +¿œ∂ß ∆¯≈∫∏‘¿Ω");
    }
    public void DropApple()
    {
        point -= 100;
       
    }
    public void Dropbomb()
    {
        if (point < 0)
        {
            Debug.Log("point -¿œ∂ß ∆¯≈∫∏‘¿Ω");
            point = point * 2;
        }
    }
    void moveLight()
    {
        light.transform.Rotate(new Vector3(-3, 0, 0) * Time.deltaTime);
    }


    private void Start()
    {
        timerText = GameObject.Find("Time");
        pointText = GameObject.Find("Point");
        generator = GameObject.Find("itemGenerator");
        light = GameObject.Find("DirectionalLight");
    }
    private void Update()
    {

        time -= Time.deltaTime;

        if (this.time < 0)
        {
            this.time = 0;
            this.generator.GetComponent<itemGenerator>().SetParameter(10000.0f, 0, 0);
            
        }
        else if (0 <= this.time && this.time < 5)
        {
            this.generator.GetComponent<itemGenerator>().SetParameter(0.9f, -0.02f, 3);
        }
        else if (5 <= this.time && this.time < 10)
        {
            this.generator.GetComponent<itemGenerator>().SetParameter(0.4f, -0.018f, 6);
        }
        else if (10 <= this.time && this.time < 20)
        {
            this.generator.GetComponent<itemGenerator>().SetParameter(0.7f, -0.015f, 4);
        }
        else if (20 <= this.time && this.time < 30)
        {
            this.generator.GetComponent<itemGenerator>().SetParameter(1.0f, -0.01f, 2);
        }
        timerText.GetComponent<TextMeshProUGUI>().text = time.ToString("F1");
        pointText.GetComponent<TMP_Text>().text = point.ToString() + "Point";
        if (this.time < 30 && this.time > 0)
        {
            moveLight();
        }

        if (point < 0)
        {
            isDropApple = true;
        }
        else
        {
            isDropApple = false;
        }
    }
}
