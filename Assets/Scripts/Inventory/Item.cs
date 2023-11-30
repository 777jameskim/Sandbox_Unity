using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{

    ItemData data = new ItemData();

    [SerializeField] private GameObject obj;
    [SerializeField] private TMP_Text enchantTxt;
    [SerializeField] private TMP_Text levelTxt;
    private StateView sv;

    public Image icon;

    ItemController ic;

    private int count = 1;
    public int Count
    { 
        get { return count; }
        set
        {
            count = value;
            enchantTxt.text = $"{count}";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetData(ItemData data, ItemController ic, int etcIndex = -1)
    {
        //data setting
        this.ic = ic;
        this.data = data;

        //UI setting
        obj.SetActive(true);
        Image bg = GetComponent<Image>();
        bg.color = new Color(1f, 1f, 1f, 1f);
        bg.sprite = ic.frame[(int)data.grade];
        levelTxt.text = $"Lv.{data.level}";
        //icon.sprite = ic.armorSprites[Random.Range(0, ic.armorSprites.Length)];
        if(data.type != ItemType.ETC)
        {
            icon.sprite = ic.dicSprites[data.type][Random.Range(0,ic.dicSprites[data.type].Count)];
            if (data.enchantLevel != 0)
                enchantTxt.text = $"+{data.enchantLevel}";
            else
                enchantTxt.text = string.Empty;
        }
        else
        {
            icon.sprite = ic.dicSprites[data.type][etcIndex];
            enchantTxt.text = "1";
        }

    }

    public void SetStateView(StateView sv)
    {
        this.sv = sv;
    }

    public void Empty()
    {
        obj.SetActive(false);
    }

    public void OnSetStateView()
    {
        sv.icon.sprite = this.icon.sprite;
        sv.icon.color = new Color(1f, 1f, 1f, 1f);
        sv.itemGrade.sprite = ic.frame[(int)data.grade];
        sv.iconDesc.text = this.icon.sprite.name;
        if (data.type != ItemType.ETC)
        {
            sv.level = data.level;
            sv.grade = data.grade.ToString();
            sv.enchant = data.enchantLevel;
        }
        else
        {
            sv.amount = count;
        }
    }
}
