using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIEnabler : MonoBehaviour
{
    [SerializeField]
    GameObject loseTitle;

    [SerializeField]
    GameObject restart;

    [SerializeField]
    GameObject close;

    public void EnableUIElements()
    {
        loseTitle.SetActive(true);
        restart.SetActive(true);
        close.SetActive(true);
    }
}
