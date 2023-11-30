using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDropDown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;

    // Start is called before the first frame update
    void Start()
    {
        dropdown.options.Clear();

        string[] str = { "alpha", "beta", "theta", "gamma", "epsilon", "omega" };

        List<TMP_Dropdown.OptionData> opData = new List<TMP_Dropdown.OptionData>();
        foreach (string item in str)
        {
            TMP_Dropdown.OptionData data = new TMP_Dropdown.OptionData();
            data.text = item;

            opData.Add(data);
        }
        dropdown.options = opData;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
