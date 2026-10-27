using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatChopping : MonoBehaviour
{
    [SerializeField] private Animator meatAnim;

    // Scaling setting
    public GameObject triggerObject;

    public GameObject knife;

    private void OnMouseDown()
    {
        meatAnim.SetBool("meatChopped", true);
    }
}
