using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    [SerializeField] private Scrollbar sbar;
    [SerializeField] private Image dynamicbar, staticbar;
    [SerializeField] private TMP_Text status, regenrate;
    [SerializeField] private bool death = false;

    private float dynamicDelta;
    private float dynamicGoal;
    [SerializeField] private float dynamicRate = 0.8f;

    [SerializeField] private int framerate = 20;

    public float barVal = 600;
    public int maxVal = 600;
    public float regenVal = 1;

    // Start is called before the first frame update
    void Start()
    {
        SetBars(barVal);
        StartCoroutine(UpdateDynamicBar());
        StartCoroutine(Regeneration());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetBar(Image bar, float value)
    {
        float percentage = value / maxVal;
        float width = sbar.transform.GetChild(0).GetComponent<RectTransform>().rect.width * percentage;
        float height = sbar.GetComponent<RectTransform>().rect.height;
        bar.rectTransform.sizeDelta = new Vector2(width, height);
    }

    private float ReadBar(Image bar)
    {
        float barval = bar.transform.GetComponent<RectTransform>().rect.width;
        float maxwidth = sbar.transform.GetChild(0).GetComponent<RectTransform>().rect.width;
        return barval / maxwidth * maxVal;
    }

    private void SetBars(float value)
    {
        status.text = $"{value.ToString("0")}/{maxVal}";
        SetBar(staticbar, value);
        dynamicGoal = value;
        dynamicDelta = ReadBar(dynamicbar) - value;
        if (dynamicDelta <= 0)
        {
            SetBar(dynamicbar, value);
            dynamicDelta = 0;
        }
        barVal = value;
    }

    public void SetBarVal(float value)
    {
        if (value < 0)
            value = 0;
        if (death && barVal == 0)
            return;
        if (value > maxVal)
            value = maxVal;
        SetBars(value);
    }

    private IEnumerator UpdateDynamicBar()
    {
        while (true)
        {
            if (dynamicDelta > 0)
            {
                dynamicDelta = dynamicDelta * dynamicRate;
                SetBar(dynamicbar, dynamicGoal + dynamicDelta);
            }
            yield return new WaitForSeconds(1f / framerate);
        }
    }

    private IEnumerator Regeneration()
    {
        while (true)
        {
            if (barVal == maxVal || (death && barVal == 0))
            {
                regenrate.text = "";
            }
            else
            {
                regenrate.text = $"+{regenVal.ToString("0.0")}";
                SetBarVal(barVal + regenVal/framerate);
            }
            yield return new WaitForSeconds(1f / framerate);
        }
    }
}
