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
    RectTransform selectGauge;

    Vector2 gaugeVec = new Vector2(50, 5);

    public static float railSpeed = 50;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeedText = GameObject.Find("CurrentSpeedText").GetComponent<Text>();
        selectGauge = GameObject.Find("SelectGauge").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Titleシーン意外だとめっちゃエラー出ちゃうのでifで囲ってます
        if (currentSpeedText != null && selectGauge != null)
        {
            Select();
        }
    }

    private void Select()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug
            .DrawRay(ray.origin,
            ray.direction,
            new Color(1.0f, 0.0f, 0.0f, 1.0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            currentButton = hit.collider.gameObject.name;
            timer += Time.deltaTime;
            selectGauge.sizeDelta =
                new Vector2(gaugeVec.x * timer / selectTime, gaugeVec.y);

            if (timer > selectTime)
            {
                switch (currentButton)
                {
                    case "StartButton":
                        selectGauge.sizeDelta = new Vector2(0, gaugeVec.y);
                        Loanch();
                        break;
                    default:
                        selectGauge.sizeDelta = new Vector2(0, gaugeVec.y);
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
            selectGauge.sizeDelta = new Vector2(0, gaugeVec.y);
        }
    }

    void Loanch()
    {
        SceneManager.LoadScene("Snowman");
    }
}
