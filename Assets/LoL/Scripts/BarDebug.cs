using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarDebug : MonoBehaviour
{
    [SerializeField] private BarScript HPbar, MPbar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
            HPbar.SetBarVal(HPbar.maxVal);
        if (Input.GetKeyDown(KeyCode.Keypad1))
            HPbar.SetBarVal(HPbar.barVal - 10);
        if (Input.GetKeyDown(KeyCode.Keypad2))
            HPbar.SetBarVal(HPbar.barVal - 20);
        if (Input.GetKeyDown(KeyCode.Keypad3))
            HPbar.SetBarVal(HPbar.barVal - 30);
        if (Input.GetKeyDown(KeyCode.Keypad4))
            HPbar.SetBarVal(HPbar.barVal - 40);
        if (Input.GetKeyDown(KeyCode.Keypad5))
            HPbar.SetBarVal(HPbar.barVal - 50);
        if (Input.GetKeyDown(KeyCode.Keypad6))
            HPbar.SetBarVal(HPbar.barVal - 60);
        if (Input.GetKeyDown(KeyCode.Keypad7))
            HPbar.SetBarVal(HPbar.barVal - 70);
        if (Input.GetKeyDown(KeyCode.Keypad8))
            HPbar.SetBarVal(HPbar.barVal - 80);
        if (Input.GetKeyDown(KeyCode.Keypad9))
            HPbar.SetBarVal(HPbar.barVal - 90);
        if (Input.GetKeyDown(KeyCode.Alpha0))
            MPbar.SetBarVal(MPbar.maxVal);
        if (Input.GetKeyDown(KeyCode.Alpha1))
            MPbar.SetBarVal(MPbar.barVal - 10);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            MPbar.SetBarVal(MPbar.barVal - 20);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            MPbar.SetBarVal(MPbar.barVal - 30);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            MPbar.SetBarVal(MPbar.barVal - 40);
        if (Input.GetKeyDown(KeyCode.Alpha5))
            MPbar.SetBarVal(MPbar.barVal - 50);
        if (Input.GetKeyDown(KeyCode.Alpha6))
            MPbar.SetBarVal(MPbar.barVal - 60);
        if (Input.GetKeyDown(KeyCode.Alpha7))
            MPbar.SetBarVal(MPbar.barVal - 70);
        if (Input.GetKeyDown(KeyCode.Alpha8))
            MPbar.SetBarVal(MPbar.barVal - 80);
        if (Input.GetKeyDown(KeyCode.Alpha9))
            MPbar.SetBarVal(MPbar.barVal - 90);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            HPbar.barVal = HPbar.maxVal;
            HPbar.SetBarVal(HPbar.barVal);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
            HPbar.maxVal += 10;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            HPbar.regenVal += 1;
        if (Input.GetKeyDown(KeyCode.UpArrow))
            MPbar.maxVal += 10;
        if (Input.GetKeyDown(KeyCode.DownArrow))
            MPbar.regenVal += 1;
    }
}
