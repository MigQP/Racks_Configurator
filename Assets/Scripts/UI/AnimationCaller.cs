using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCaller : MonoBehaviour
{

    // POPPING SYSTEM FOR MENU
    public void PlayAnimation()
    {
        GetComponent<Animator>().SetBool("open", false);
    }
}
