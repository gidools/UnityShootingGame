using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    Transform tr;
    public float speed;

    void Start()
    {
        tr = GetComponent<Transform>();
        StartCoroutine(DestroySelf());
    }

    private IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        tr.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
