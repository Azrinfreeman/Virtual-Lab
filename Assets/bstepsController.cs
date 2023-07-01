using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bstepsController : MonoBehaviour
{
    public static bstepsController instance;

    private void Awake()
    {
        instance = this;
    }
    public int eks;
    public Animator[] bsteps;
    // Start is called before the first frame update
    void Start()
    {
        if (eks == 3)
        {
            bsteps = new Animator[20];


            for (int i = 0; i < 20; i++)
            {
                bsteps[i] = transform.Find("Step" + (i + 1)).transform.GetChild(0).GetComponent<Animator>();
            }
        }
        else if (eks == 4)
        {
            bsteps = new Animator[27];


            for (int i = 0; i < 27; i++)
            {
                bsteps[i] = transform.Find("Step" + (i + 1)).transform.GetChild(0).GetComponent<Animator>();
            }
        }
        else if (eks == 5)
        {
            bsteps = new Animator[31];


            for (int i = 0; i < 31; i++)
            {
                bsteps[i] = transform.Find("Step" + (i + 1)).transform.GetChild(0).GetComponent<Animator>();
            }
        }
        else if (eks == 6)
        {
            bsteps = new Animator[26];


            for (int i = 0; i < 26; i++)
            {
                bsteps[i] = transform.Find("Step" + (i + 1)).transform.GetChild(0).GetComponent<Animator>();
            }
        }
        else if (eks == 7)
        {
            bsteps = new Animator[28];


            for (int i = 0; i < 28; i++)
            {
                bsteps[i] = transform.Find("Step" + (i + 1)).transform.GetChild(0).GetComponent<Animator>();
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
