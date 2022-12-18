using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gyro : MonoBehaviour
{

    Transform m_transform;

    Quaternion currentGyro;

    readonly Quaternion _BASE_ROTATION = Quaternion.Euler(0, 0, 0);

    [SerializeField]
    Cinemachine.CinemachineDollyCart cart;
    [SerializeField]
    Text gyroText;

    // Start is called before the first frame update
    void Start()
    {
        cart = GameObject.Find("DollyCart").GetComponent<Cinemachine.CinemachineDollyCart>();
        Input.gyro.enabled = true;
        gyroText = GameObject.Find("GyroText").GetComponent<Text>();
        m_transform = this.transform;
        if (!cart) return;
        cart.m_Speed = CameraRayCast.railSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion gyro = Input.gyro.attitude;
        gyroText.text = $"enabled: {Input.gyro.enabled} attitude: {Input.gyro.attitude}";

        m_transform.localRotation =
            _BASE_ROTATION * (new Quaternion(-gyro.x, -gyro.y, gyro.z, gyro.w));

        if (Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene("Title");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggerEnter");
        string obj_name = other.gameObject.name;
        if (obj_name == "Teleporter1")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


}
