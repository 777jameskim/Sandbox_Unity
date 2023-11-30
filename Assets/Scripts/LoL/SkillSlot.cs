using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements.Experimental;

public class SkillSlot : MonoBehaviour
{
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
        StartCoroutine(Reload());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(){
        skill.interactable = false;
        reloadtimer = reloadtime;
    }

    private IEnumerator Reload(){
        while(true){
            if(reloadtimer > 1)
                reload.text = reloadtimer.ToString("0");
            else if(reloadtimer > 0)
                reload.text = reloadtimer.ToString("0.0");
            if(reloadtimer > 0){
                yield return new WaitForSeconds(0.1f);
                reloadtimer -= 0.1f;
                loading.fillAmount = reloadtimer/reloadtime;
            }
            if(reloadtimer == 0){
                skill.interactable = true;
            }
        }
    }
}
