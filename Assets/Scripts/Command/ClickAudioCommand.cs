using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.command.impl;

public class ClickAudioCommand : Command {

    public override void Execute()
    {
        Camera.main.gameObject.GetComponent<AudioSource>().PlayOneShot(Resources.Load("VFX/Click") as AudioClip);
    }
}
