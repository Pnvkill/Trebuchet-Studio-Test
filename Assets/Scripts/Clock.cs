using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public Transform initialPos;
    private GameObject minuteHand, hourHand;
    public GameObject[] hourHandList, minuteHandList;
    private int minutes;

    // Start is called before the first frame update
    void Start()
    {
        print(initialPos.eulerAngles);
        int n = Random.Range(0, hourHandList.Length);
        hourHand = Instantiate(hourHandList[n], initialPos.position, Quaternion.Euler(initialPos.eulerAngles));
        minuteHand = Instantiate(minuteHandList[n], initialPos.position, Quaternion.Euler(initialPos.eulerAngles));
        hourHand.transform.parent = initialPos;
        minuteHand.transform.parent = initialPos;
    
    }

    // Update is called once per frame
    void Update()
    {

        minuteHand.transform.localRotation = Quaternion.Euler(0, getSystemHour(false) * 360 / 60, 0);
        hourHand.transform.localRotation = Quaternion.Euler(0, getSystemHour(true) * 360/12 ,0);

    }

    private int getSystemHour(bool isHour)
    {
        if(isHour)
        {
            return int.Parse(System.DateTime.UtcNow.ToLocalTime().ToString("hh"));
        }
        return int.Parse(System.DateTime.UtcNow.ToString("mm"));
    }
}
