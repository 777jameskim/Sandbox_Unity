using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StateView : MonoBehaviour
{
    [SerializeField] private ItemController ic;

    public Image icon;
    public Image itemGrade;
    public TMP_Text iconDesc;
    [SerializeField] private TMP_Text levelTxt;
    [SerializeField] private TMP_Text gradeTxt;
    [SerializeField] private TMP_Text enchantTxt;

    public int level
    {
        set
        {
            levelTxt.text = (value != 0) ? $"Level: {value}" : "";
        }
    }
    
    public string grade
    {
        set
        {
            gradeTxt.text = $"Item Grade: {value}";
        }
    }

    public int enchant
    {
        set
        {
            enchantTxt.text = $"Enchant Level: +{value}";
        }
    }

    public int amount
    {
        set
        {
            levelTxt.text = $"#: {value}";
            gradeTxt.text = "";
            enchantTxt.text = "";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        itemGrade.sprite = ic.frame[0];
        icon.sprite = null;
        icon.color = new Color(1f, 1f, 1f, 00);
        iconDesc.text = "Choose an item...";
        levelTxt.text = "";
        gradeTxt.text = "";
        enchantTxt.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
