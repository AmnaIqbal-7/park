using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class intructions2 : MonoBehaviour
{
    public Sprite[] instructionsboxsprites;
    public Image instructionbox;
    public int instrucno;
    public GameObject[] background;
    public int bkno;
    public Sprite begintutorialbtn;
    public Image btnnext;
    public GameObject TUTORIALOBJECT;
    void Start()
    {
        instructionbox.sprite = instructionsboxsprites[0];
        background[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nextbtn()
    {
        if (instrucno < instructionsboxsprites.Length-1)
        {
            instrucno += 1;
            if (instrucno < 3)
            {
                background[bkno].SetActive(false);
                bkno += 1;
                background[bkno].SetActive(true);
            }
            instructionbox.sprite = instructionsboxsprites[instrucno];

        }
      
        if (instrucno > instructionsboxsprites.Length-1)
        {
            TUTORIALOBJECT.SetActive(true);
            gameObject.SetActive(false);


        }
        if (instrucno == instructionsboxsprites.Length - 1)
        {
            btnnext.sprite = begintutorialbtn;
            instrucno += 1;

        }

    }
}
