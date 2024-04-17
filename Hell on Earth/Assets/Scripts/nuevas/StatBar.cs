using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    public StatPoints statPoints;
    public Image meterImage;
    public TextMeshProUGUI statNumber;

    void Update()
    {
        meterImage.fillAmount = (float)statPoints.currentValue / statPoints.maxValue;
        statNumber.text = statPoints.currentValue.ToString() + "/" + statPoints.maxValue;
    }

}
