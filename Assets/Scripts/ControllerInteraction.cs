using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(SteamVR_TrackedObject))]

public class ControllerInteraction : MonoBehaviour {

    public GameObject menu;
    private BeachBall ball;

    SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device controller
     {
         get { return SteamVR_Controller.Input((int) trackedObject.index); }
     }

        private BasketballScoreboard scoreboard;

	// Use this for initialization
	void Start () {
        scoreboard = GameObject.FindObjectOfType<BasketballScoreboard>();
        ball = GameObject.FindObjectOfType<BeachBall>();
    }

	void Awake () {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
        if (controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            ball.Respawn();
        }
        if (controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            PlayerPrefsManager.SetBBHighScore(0);
        }
        if(controller.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            Debug.Log("Menu Pressed");
            if (menu.activeInHierarchy)
            {
                menu.SetActive(false);
            }
            else
            {
                menu.SetActive(true);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.GetComponent<StaticObject>())
        {
            if (controller.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                other.attachedRigidbody.isKinematic = true;
                other.gameObject.transform.SetParent(this.gameObject.transform);
            }
            if (controller.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                other.attachedRigidbody.isKinematic = false;
                other.gameObject.transform.SetParent(null);
            }

            tossObject(other.attachedRigidbody);
        }

        if (controller.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            if (other.GetComponent<MenuTeleportButton>())
            {
                other.GetComponent<MenuTeleportButton>().Teleport();
                Debug.Log("Attempting to Teleport");
            }
            if (other.GetComponent<SleepButton>())
            {
                other.GetComponent<SleepButton>().Sleep();
            }
        }
    }

    private void tossObject(Rigidbody rb)
    {
        Transform origin = trackedObject.origin ? trackedObject.origin : trackedObject.transform.parent;
        if (origin != null)
        {
            rb.velocity = origin.TransformVector(controller.velocity);
            rb.angularVelocity = origin.TransformVector(controller.angularVelocity);
        } else {
            rb.velocity = controller.velocity;
            rb.angularVelocity = controller.angularVelocity;
        }
    }
}
