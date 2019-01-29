using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Used to prevent the alpha of "buttons" from being clicked on
// 1 = Fully opaque
// 0 = Transparent (default)
[RequireComponent(typeof(Image))]
public class ButtonAlphaHitTest : MonoBehaviour {

    [Range(0, 1)]
    public float AlphaThreshHold = 1.0f;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Image>().alphaHitTestMinimumThreshold = AlphaThreshHold;

    }
}
