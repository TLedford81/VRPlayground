using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(SteamVR_TrackedObject))]

public class ControllerInteraction : MonoBehaviour {

    public GameObject menu;
    private BeachBall ball;
    public GameObject objectinhand;
    public GameObject model;

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
        if (controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            if (objectinhand.GetComponent<Gun>())
            {
                model.SetActive(true);
            }
            Debug.Log("Dropping Item");
            objectinhand.GetComponent<Rigidbody>().isKinematic = false;
            objectinhand.gameObject.transform.SetParent(null);
            objectinhand = null;
            tossObject(objectinhand.GetComponent<Rigidbody>());
        }

        if (objectinhand != null)
        {
            if (objectinhand.GetComponent<Gun>())
            {
                Gun gun = objectinhand.GetComponent<Gun>();
                if (controller.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
                {
                    gun.Shoot();
                }
            }
        }
    }

    //object.transform.localposition = new Vector3(0.002f, 0.009f, -0.132)
    //    rotation = this.transform.localrotation
    //    rotate 0 90 60

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other);
        if (!other.GetComponent<StaticObject>())
        {
            Debug.Log(other + " IS STATIC");
            if (controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            {
                Debug.Log("Grabbing " + other);
                other.attachedRigidbody.isKinematic = true;
                other.gameObject.transform.SetParent(this.gameObject.transform);
                objectinhand = other.gameObject;
                if (objectinhand.GetComponent<Gun>())
                {
                    other.transform.localPosition = new Vector3(0f, -0.02f, 0.02f);
                    other.transform.rotation = this.transform.rotation;
                    other.transform.Rotate(45, 0, 0);
                    model.SetActive(false);
                }
            }
        }

        //if (controller.gettouchdown(steamvr_controller.buttonmask.trigger))
        //{
        //    if (other.getcomponent<menuteleportbutton>())
        //    {
        //        other.getcomponent<menuteleportbutton>().teleport();
        //        debug.log("attempting to teleport");
        //    }
        if (other.GetComponent<SleepButton>())
        {
            other.GetComponent<SleepButton>().Sleep();
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
