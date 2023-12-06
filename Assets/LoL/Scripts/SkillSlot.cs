using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements.Experimental;

public class SkillSlot : MonoBehaviour
{
    [SerializeField] private Material greyscale;

    [SerializeField] private Button skill;
    [SerializeField] private Image loading;
    [SerializeField] private TMP_Text reload;

    [SerializeField] private float reloadtime = 15;
    private float reloadtimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        reload.text = "";
        loading.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (reloadtimer > 0)
        {
            reloadtimer -= Time.deltaTime;
            if (reloadtimer < 1)
                reload.text = reloadtimer.ToString("0.0");
            else
                reload.text = reloadtimer.ToString("0");
            loading.fillAmount = reloadtimer / reloadtime;
        }
        else
        {
            skill.interactable = true;
            reload.text = "";
            GetComponent<Image>().material = null;
        }
    }

    public void OnClick()
    {
        skill.interactable = false;
        reloadtimer = reloadtime;
        GetComponent<Image>().material = greyscale;
    }
}
