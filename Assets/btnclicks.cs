
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;



public class btnclicks : MonoBehaviour
{
  //  public Button wrongbtn;
  //  public Button rightbtn;
    public  List<GameObject> waitingpersons = new List<GameObject>();
    public GameObject endpoint;
    public int correctpersonno = 0;
    public int incorrectpersonno = 0;
    public GameObject hh;
    private Animator animator;
    public void Start()
    {
        for(int i=0; i<waitingpersons.Count; i++)
        {
            waitingpersons[i].GetComponent<Animator>().speed = 0;

          
            // GetSpritesFromClip(animator.GetCurrentAnimatorClipInfo(0)[0].clip);


        }
        animator = waitingpersons[0].GetComponent<Animator>();
        foreach (var binding in AnimationUtility.GetObjectReferenceCurveBindings(animator.GetCurrentAnimatorClipInfo(0)[0].clip))
        {
            var keyframes = AnimationUtility.GetObjectReferenceCurve(animator.GetCurrentAnimatorClipInfo(0)[0].clip, binding);

            for (int i = 0; i < keyframes.Length; i++)
            {
                if (i == 2)
                {
                    
                    waitingpersons[0].gameObject.GetComponent<Image>().sprite = (Sprite)keyframes[2].value;
                    Debug.Log("hgggggggg" + keyframes[i].value);
                }

                // sprites.Add((Sprite)frame.value);
            }

        }

    }



    public  void incorrect()
    {
        incorrectpersonno = 0;
        waitingpersons.Insert(waitingpersons.Count, waitingpersons[0]);
        waitingpersons.RemoveAt(0);
        waitingpersons[waitingpersons.Count-1].transform.localScale = new Vector3(-1, 1, 1);
        waitingpersons[waitingpersons.Count-1].GetComponent<Animator>().speed = .4f;
        
        LeanTween.moveX(waitingpersons[waitingpersons.Count - 1], waitingpersons[waitingpersons.Count-2].transform.position.x , 5).setOnStart(resetlineonIncorrect).setOnComplete(destroyline);
    }

    public void resetlineonIncorrect()
    {

       
        for (int i = 0; i < waitingpersons.Count-1; i++)
        {
            LeanTween.moveX(waitingpersons[i], waitingpersons[i].transform.position.x + 1f, 3).setOnComplete(incorrectresetspeed);

            waitingpersons[i].GetComponent<Animator>().speed = .4f;

        }

    }

    public void destroyline()
    {
       
        waitingpersons[waitingpersons.Count-1].GetComponent<Animator>().speed = 0;
        waitingpersons[waitingpersons.Count-1].transform.localScale = new Vector3(1, 1, 1);
      
    }

    public void incorrectresetspeed()
    {
        waitingpersons[incorrectpersonno].GetComponent<Animator>().speed = 0f;
       
            incorrectpersonno += 1;

        
       
    }
    public void correct()
    {
        correctpersonno = 0;
        hh = waitingpersons[0].gameObject;
        waitingpersons[0].GetComponent<Animator>().speed = .5f;
        LeanTween.moveX(waitingpersons[0], endpoint.transform.position.x, 4).setOnComplete(destroyonreaced);
        waitingpersons.RemoveAt(0);
        Invoke("resetlineoncorrect", .2f);
    }

    public void destroyonreaced()
    {
      
        Destroy(hh);
    }
    public void resetlineoncorrect()
    {
      
       
        for (int i = 0; i < waitingpersons.Count; i++)
        {
            LeanTween.moveX(waitingpersons[i], waitingpersons[i].transform.position.x + 1f, 3).setOnComplete(correctresetspeed);
            waitingpersons[i].GetComponent<Animator>().speed = .4f;
           
        }
       

    }
    public void correctresetspeed()
    {
        waitingpersons[correctpersonno].GetComponent<Animator>().speed = 0f;
       
            correctpersonno += 1;

        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
      //  if (waitingpersons[0].)
    }

        public void Update()
    {
        
    }
}
