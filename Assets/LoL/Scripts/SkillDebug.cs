using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDebug : MonoBehaviour
{
    [SerializeField] private SkillSlot skillQ, skillW, skillE, skillR, spellD, spellF, item1, item2, item3, item4, item5, item6, item7, recall; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            skillQ.OnClick();
        if (Input.GetKeyDown(KeyCode.W))
            skillW.OnClick();
        if (Input.GetKeyDown(KeyCode.E))
            skillE.OnClick();
        if (Input.GetKeyDown(KeyCode.R))
            skillR.OnClick();
        if (Input.GetKeyDown(KeyCode.D))
            spellD.OnClick();
        if (Input.GetKeyDown(KeyCode.F))
            spellF.OnClick();
        if (Input.GetKeyDown(KeyCode.Alpha1))
            item1.OnClick();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            item2.OnClick();
        if (Input.GetKeyDown(KeyCode.Alpha3))
            item3.OnClick();
        if (Input.GetKeyDown(KeyCode.Alpha4))
            item4.OnClick();
        if (Input.GetKeyDown(KeyCode.Alpha5))
            item5.OnClick();
        if (Input.GetKeyDown(KeyCode.Alpha6))
            item6.OnClick();
        if (Input.GetKeyDown(KeyCode.Alpha7))
            item7.OnClick();
        if (Input.GetKeyDown(KeyCode.B))
            recall.OnClick();
    }
}
