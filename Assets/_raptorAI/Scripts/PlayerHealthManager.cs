using UnityEngine;
using System.Collections;

public class PlayerHealthManager : MonoBehaviour {

    [SerializeField]
    int health = 100;

    void OnGUI()
    {
        string textToDisplay = System.String.Format("Player Health: {0} ",health);
        Rect textToDisplayRectancle = new Rect(0,0,100,100);
        GUI.Label(textToDisplayRectancle, textToDisplay);
    }

    void ReceiveDamage(int damageAmount)
    {
        health = Mathf.Clamp(health-damageAmount,0,100);
    }
}
