using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class GroupButtons : MonoBehaviour
{

    private Button[] buttons;


    void Start()
    {
        buttons  = GetComponentsInChildren<Button>();
        //buttons[1].interactable = false;
    }


    public void OnClickButtonInGroup()
    {

        
        var clickedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        
        foreach ( var button in buttons)
        {
            if (button == clickedButton)
            {
                button.interactable = false;
                button.Select();
                
            }
            else
            {
                button.interactable = true;
            }
        }

    }
}
