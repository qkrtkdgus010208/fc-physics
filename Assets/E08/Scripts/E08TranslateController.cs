using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E08TranslateController : MonoBehaviour
{
    public float speed = 5f; // 이동 속도


    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(h, 0.0f, v);

        transform.Translate(movement * speed * Time.deltaTime);
    }
}
