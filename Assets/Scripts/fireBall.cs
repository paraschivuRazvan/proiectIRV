using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBall : MonoBehaviour {

    GameObject prefab;

    public float velocity;
    public float forwardOffset;

    int throwable = 1;

    // Use this for initialization
    void Start()
    {
        //prefab = Resources.Load("dynamite") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
            throwable = 1;

        if (Input.GetKeyDown(KeyCode.Alpha2))
            throwable = 2;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(throwable);
            if (throwable == 1)
            {
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                go.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
                go.transform.position = transform.position + transform.forward;
                go.AddComponent<Rigidbody>();
                go.GetComponent<Rigidbody>().AddForce(transform.forward * 1000f);
                go.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * velocity;
                //go.AddComponent<DWGDestroyer>();
                Destroy(go, 10f);
            }

            if (throwable == 2)
            {
                GameObject go = Instantiate(prefab) as GameObject;
                //go.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
                go.transform.position = transform.position + transform.forward;
                Quaternion rot = Quaternion.FromToRotation(Vector3.up, go.transform.position);
                go.AddComponent<Rigidbody>();
                go.GetComponent<Rigidbody>().AddForce(transform.forward * 1000f);
                go.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * velocity;
                //go.AddComponent<DWGDestroyer>();
                Destroy(go, 1f);
            }

            AudioManager.PlaySFX(AudioResources.Instance.shoot_ball);
        }
    }
}
