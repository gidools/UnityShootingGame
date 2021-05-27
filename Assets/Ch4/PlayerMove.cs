using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public Vector2 limitPoint1;
    public Vector2 limitPoint2;
    public GameObject prefabBullet;

    Transform tr;
    Vector2 mousePosition;

    void Start()
    {
        tr = GetComponent<Transform>();

        StartCoroutine(FireBullet());
    }

    private IEnumerator FireBullet()
    {
        while(true)
        {
            Instantiate(prefabBullet, tr.position, Quaternion.identity);
            yield return new WaitForSeconds(0.3f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePosition.x < limitPoint1.x)
            {
                mousePosition.x = limitPoint1.x;
            }
            if(mousePosition.y < limitPoint1.y)
            {
                mousePosition.y = limitPoint1.y;
            }
            if (mousePosition.x > limitPoint2.x)
            {
                mousePosition.x = limitPoint2.x;
            }
            if (mousePosition.y > limitPoint2.y)
            {
                mousePosition.y = limitPoint2.y;
            }


            tr.position = Vector2.MoveTowards(tr.position, mousePosition, Time.deltaTime * speed);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(limitPoint1, new Vector2(limitPoint2.x, limitPoint1.y));
        Gizmos.DrawLine(limitPoint2, new Vector2(limitPoint2.x, limitPoint1.y));
        Gizmos.DrawLine(limitPoint1, new Vector2(limitPoint1.x, limitPoint2.y));
        Gizmos.DrawLine(limitPoint2, new Vector2(limitPoint1.x, limitPoint2.y));
    }
}
