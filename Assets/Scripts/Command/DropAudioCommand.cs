using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.command.impl;

public class DropAudioCommand : Command {

    public override void Execute()
    {
        Camera.main.gameObject.GetComponent<AudioSource>().PlayOneShot(Resources.Load("VFX/Drop") as AudioClip);
    }
}
