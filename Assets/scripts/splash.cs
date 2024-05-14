using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splash : MonoBehaviour
{
    private Animator animator;
    private bool isPlaying = false;
    public GameObject nextButton; // Reference to the next button

    private bool animationCompleted = false;
    Sceneloader sceneloader;
    void Start()
    {
        sceneloader = FindAnyObjectByType<Sceneloader>();

    }
    public void Awake()
    {
        animator = GetComponent<Animator>();
        animator.speed = 1;
        AnimationEvent animationEvent = new AnimationEvent();
        animationEvent.time = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length - 1; // Set event time to end of animation
        animationEvent.functionName = "OnAnimationComplete";
        animator.GetCurrentAnimatorClipInfo(0)[0].clip.AddEvent(animationEvent);

    }


    void OnAnimationComplete()
    {
        animationCompleted = true;

    }


    public void Update()
    {
        if (animationCompleted)
        {
            animator.speed = 0;
            sceneloader.LoadNextScene();
        }
    }

    IEnumerator Splash()
    {
        yield return new WaitForSeconds(2f);
        sceneloader.LoadNextScene();
    }
}
