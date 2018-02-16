using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepButton : MonoBehaviour {

    private SkyChanger skyChanger;

    private void Start()
    {
        skyChanger = FindObjectOfType<SkyChanger>();
    }

    public void Sleep()
    {
        skyChanger.Sleep();

    }
}
