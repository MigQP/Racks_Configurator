using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    public GameObject Panel;

    public void PanelOpener()
    {
        if (Panel != null)
        {
            Animator animator = Panel.GetComponent<Animator>();
            if(animator != null)
            {
                bool isOpen = animator.GetBool("open");
                animator.SetBool("open", !isOpen);
            }
        }
    }


}
