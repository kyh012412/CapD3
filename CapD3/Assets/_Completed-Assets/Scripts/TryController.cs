﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TryController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private RectTransform rect_Background;
    [SerializeField] private RectTransform rect_Joystic;

    private float radius;

    [SerializeField] private GameObject go_Player;
    [SerializeField] private float movespeed;

    private bool isTouch = false;
    private Vector3 movePosition;
    private int i = 0;



    // Start is called before the first frame update
    void Start()
    {
        radius = rect_Background.rect.width * 0.5f;
        MoveStart();
        //InvokeRepeating("MoveStart", 0f, 0.025f);
        //Invoke("timestop", 10f);

    }
    public void oneseclater()
    {
        Invoke("MoveStart", 0f);
    }
    public void timestop()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 value = eventData.position - (Vector2)rect_Background.position;

        value = Vector2.ClampMagnitude(value, radius);
        rect_Joystic.localPosition = value;

        float distance = Vector2.Distance(rect_Background.position, rect_Joystic.position) / radius;
        //Debug.Log("distance: "+distance+" deltime: "+Time.deltaTime);
        value = value.normalized;
        //movePosition = new Vector3(value.x * movespeed * distance * Time.deltaTime, 0f, value.y * movespeed * distance * Time.deltaTime);
        movePosition = new Vector3(value.x * movespeed * distance , 0f, value.y * movespeed * distance);

        //go_Player.transform.rotation = Quaternion.Euler(Mathf.Acos(value.x), 0, Mathf.Asin(value.y));
        go_Player.transform.rotation = Quaternion.Euler(0, Mathf.Atan2(value.x, value.y) * Mathf.Rad2Deg, 0);
        //Debug.Log(value.x + " "+value.y);


    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouch = false;
        rect_Joystic.localPosition = Vector3.zero;
        //movePosition = Vector3.zero;
    }
    public void MoveStart()
    {
        if (isTouch)
        {
            go_Player.transform.position += movePosition / Time.deltaTime;
        }
        if (i < 10)
            Debug.Log(Time.deltaTime);
        Invoke("MoveStart", Time.deltaTime);
    }
}
