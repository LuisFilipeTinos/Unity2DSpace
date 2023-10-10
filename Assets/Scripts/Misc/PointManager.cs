using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textPoints;

    int points;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        textPoints.text = "0";
    }

    public void AddPoints()
    {
        points += 50;
        textPoints.text = points.ToString();
    }
}
