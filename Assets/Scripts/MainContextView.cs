using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.impl;
using strange.extensions.injector.api;
using strange.extensions.signal.impl;
using strange.extensions.mediation.impl;

public class MainContextView : ContextView {

	// Use this for initialization
	void Awake ()
    {
        var context = new MainContext(this);
	}
}
