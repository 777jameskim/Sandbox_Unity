using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectLanguage : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown langselect;
    [SerializeField] private GameObject KorUI;
    [SerializeField] private GameObject EngUI;
    // Start is called before the first frame update
    void Start()
    {
        ReadLanguage();
        langselect.onValueChanged.AddListener(delegate
        {
            ReadLanguage();
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReadLanguage()
    {
        Debug.Log(langselect.value);
        switch (langselect.value)
        {
            case 0:
                KorUI.SetActive(true);
                EngUI.SetActive(false);
                break;
            case 1:
                KorUI.SetActive(false);
                EngUI.SetActive(true);
                break;
        }
    }
}
