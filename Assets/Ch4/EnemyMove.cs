using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
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
        yield return new WaitForSeconds(10.0f);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        tr.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("GameManager").GetComponent<Score>().score += 10;

        Destroy(this.gameObject);
        Destroy(collision.gameObject);
    }
}
