using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonucing : MonoBehaviour
{


    // Update is called once per frame
    void OnMouseOver()
    {
        LeanTween.scale(this.gameObject, new Vector3(0.5f, 0.5f, gameObject.transform.localScale.z), 500f).setEase(LeanTweenType.easeInBounce);
    }
}
