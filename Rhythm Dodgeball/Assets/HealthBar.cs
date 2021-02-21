using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject Player;
    public static Image HealthBarImg;
    // Start is called before the first frame update
    void Start()
    {
        HealthBarImg = GetComponent<Image>();
    }

    // Update is called once per frame
    public static void SetHealthBarValue(float value)
    {
        HealthBarImg.fillAmount = value;
    }

    public static float GetHealthBarValue()
    {
        return HealthBarImg.fillAmount;
    }

    void Update() {
        HealthBarImg.fillAmount = Player.GetComponent<PlayerMovement>().health * (0.2f);
    }

    /* Usage in other scripts:
     * 
     * in start set HealthBar.SetHealthBarValue(1);
     *
     */
}
