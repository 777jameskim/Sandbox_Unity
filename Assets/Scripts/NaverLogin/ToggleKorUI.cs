using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleKorUI : MonoBehaviour
{
    [SerializeField] private ToggleGroup UItg;
    [SerializeField] private GameObject ID;
    [SerializeField] private GameObject OTP;
    [SerializeField] private GameObject QR;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(UItg.ActiveToggles());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
