using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraRayCast : MonoBehaviour
{
    string currentButton;

    float timer = 0;

    [SerializeField]
    float selectTime;

    [SerializeField]
    Text currentSpeedText;


    [SerializeField]
    Image selectber;

    Vector2 gaugeVec = new Vector2(50, 5);

    public static float railSpeed = 15 ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpeedText != null && selectber != null)
        {
            currentSpeedText.text = "選択中のスピード" + railSpeed;
            Select();
        }
    }

    private void Select()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            currentButton = hit.collider.gameObject.name;
            timer += Time.deltaTime;
            selectber.fillAmount = timer / selectTime;


            if (timer > selectTime)
            {
                switch (currentButton)
                {
                    case "StartButton":
                        selectber.fillAmount = 0;
                        Loanch();
                        break;
                    default:
                        selectber.fillAmount = 0;
                        railSpeed = int.Parse(currentButton);
                        currentSpeedText.text =
                            "選択中のスピード" + currentButton;
                        break;
                }
            }
        }
        else
        {
            timer = 0;
            //selectGauge.sizeDelta = new Vector2(0, gaugeVec.y);
            selectber.fillAmount = timer / selectTime;
        }
    }

    void Loanch()
    {
        int num = SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % num);
    }
}
