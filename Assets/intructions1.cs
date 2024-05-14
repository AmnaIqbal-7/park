using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class intructions1 : MonoBehaviour
{
    public Image instructionsobject;
    public Sprite[] instructionsprites;
    public int instrucno;
    public GameObject lastquestion;
    public GameObject instructionboxobject;
    public GameObject counter;
    public GameObject[] instructionscreen;
    public GameObject INSTRUCTIONSGAMEOBJECT;
    public GameObject TUTORIALGAMEOBJECT;
    void Start()
    {
        instructionsobject.sprite = instructionsprites[instrucno];


    }

    
    void Update()
    {
        
    }
    public void nextbtn()
    {
     
        if (instrucno < instructionsprites.Length-2)

        {
            instructionscreen[instrucno].SetActive(false);
            instrucno++;
            instructionsobject.sprite = instructionsprites[instrucno];

            instructionscreen[instrucno].SetActive(true);
        }
        else if(instrucno == instructionsprites.Length-2)
        {
            instructionscreen[instrucno].SetActive(false);
            instrucno++;
            lastquestion.SetActive(true);
            instructionboxobject.SetActive(false);
            counter.SetActive(false);

        }
    }

    public void opentutorialscreen()
    {
        INSTRUCTIONSGAMEOBJECT.SetActive(false);
        TUTORIALGAMEOBJECT.SetActive(true);
    }
}
