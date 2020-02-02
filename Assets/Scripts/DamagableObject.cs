using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DamagableObject : MonoBehaviour
{

    public float HealthMax;
    public float Health;
    //todo add armour value

    public UnityEngine.UI.Image healthBar; 

    public EventTrigger.TriggerEvent OnDeath;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = (Health / HealthMax);
            healthBar.transform.parent.gameObject.transform.parent.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
    }

    /// <summary>
    /// Called by attacking object when fired upon
    /// </summary>
    public void RecieveHit(float damage)
    {
        Health -= damage;

        if(Health<=0)
        {
            BaseEventData eventData = new BaseEventData(EventSystem.current);
            OnDeath.Invoke(eventData);
        }
    }
}
