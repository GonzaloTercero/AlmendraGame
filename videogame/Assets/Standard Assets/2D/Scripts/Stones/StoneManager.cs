using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StoneManager : MonoBehaviour {

    public int stones;
    

    public Text stonesText;

    void Update()
    {
        stonesText.text = (":" + stones);

    }


}
