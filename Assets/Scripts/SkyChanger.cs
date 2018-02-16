using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyChanger : MonoBehaviour {

    private Animator anim;
    private bool Night;
    private MusicManager musicManager;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        musicManager = GameObject.FindObjectOfType<MusicManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Sleep()
    {
        anim.SetTrigger("Sleep");
    }

    public void ChangeSky(Material Skybox)
    {
        RenderSettings.skybox = Skybox;
        if(Night)
        {
            anim.SetBool("Nighttime", false);
            Night = false;
            musicManager.SetMusicTrack(0);
        }else if (!Night)
        {
            anim.SetBool("Nighttime", true);
            Night = true;
            musicManager.SetMusicTrack(1);
        }
        else
        {
            Debug.LogError("NIGHT VARIABLE IS NOT TRUE OR FALSE");
        }
    }
}
