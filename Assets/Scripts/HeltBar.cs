using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HeltBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public Gradient gradient;
    public Image fill;
   public void SetMaxHealt(int healt){
            slider.maxValue=healt;
            slider.value=0;
            fill.color=gradient.Evaluate(1f);
    }
    public void SetHealt(int healt){
        slider.value=healt;
      fill.color=gradient.Evaluate(slider.normalizedValue);
    }
}
