using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthbarUI : MonoBehaviour
{
    public Image healthBarFront;
    public Image healthBarBack;
    public PlayerHealth pHealth;
    public TextMeshProUGUI text;

    public float chipSpeed = 2f;
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pHealth.currentHealth = Mathf.Clamp(pHealth.currentHealth, 0, pHealth.maxHealth);

        UpdateHealthUI();


        if (Input.GetKeyDown(KeyCode.X))
        {
            pHealth.TakeDamage(Random.Range(5, 10));

        }


        if (Input.GetKeyDown(KeyCode.Z))
        {
            pHealth.RestoreHealth(Random.Range(5, 10));

        }
    }

    public void UpdateHealthUI()
    {
        //Debug.Log(pHealth.currentHealth);

        //Update Text
        text.text = ("HP: " + pHealth.currentHealth);

        //Set fill amount variables
        float fillF = healthBarFront.fillAmount;
        float fillB = healthBarBack.fillAmount;
        float hFraction = pHealth.currentHealth / pHealth.maxHealth;

        //If player takes damage, apply chip effect.
        if (fillB > hFraction)
        {
            //Debug.Log("fillb less than hfraction");
            healthBarFront.fillAmount = hFraction;
            healthBarBack.color = Color.red;
            pHealth.lerpTimer += Time.deltaTime;
            float percentComplete = pHealth.lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            healthBarBack.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }

        //If player heals, apply chip effect.
        if (fillF < hFraction)
        {
            //Debug.Log("filla less than hfraction");
            healthBarBack.color = Color.green;
            healthBarBack.fillAmount = hFraction;
            pHealth.lerpTimer += Time.deltaTime;
            float percentComplete = pHealth.lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            healthBarFront.fillAmount = Mathf.Lerp(fillF, healthBarBack.fillAmount, percentComplete);

        }    


    }
}
