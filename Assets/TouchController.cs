using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{

    public Transform[] Barangs;
    // Start is called before the first frame update
    void Start()
    {
        // Barangs = new Transform[15];

        // for (int i = 0; i < Barangs.Length; i++)
        // {


        //     if (i == 5)
        //     {
        //         Barangs[5] = transform.GetChild(5).transform.GetChild(1).transform.GetChild(0).transform.GetChild(0)
        //             .transform.GetChild(0);
        //     }
        //     else if (i == 7)
        //     {
        //         Barangs[7] = transform.GetChild(7).transform.GetChild(1).transform.GetChild(3).transform.GetChild(0);

        //     }
        //     else if (i == 9)
        //     {
        //         Barangs[9] = transform.GetChild(9).transform.GetChild(1).transform.GetChild(0);
        //     }
        //     else if (i == 11)
        //     {
        //         Barangs[11] = transform.GetChild(11).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0);
        //     }
        //     else if (i == 12)
        //     {
        //         Barangs[12] = transform.GetChild(12).transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0);
        //     }
        //     else if (i == 13)
        //     {
        //         Barangs[13] = transform.GetChild(12).transform.GetChild(1).transform.GetChild(0).transform.GetChild(2).transform.GetChild(1).transform.GetChild(0);
        //     }
        //     else if (i == 14)
        //     {
        //         Barangs[14] = transform.GetChild(13);
        //     }
        //     else
        //     {
        //         Barangs[i] = transform.GetChild(i);
        //     }
        // }


        Barangs = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            Barangs[i] = transform.GetChild(i);
        }
    }



    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                if (raycastHit.collider.transform.childCount > 0)
                {
                    var hitObject = raycastHit.collider.transform.GetChild(0).name;
                    var selectedObject = raycastHit.collider.transform.GetChild(0);
                    Debug.Log(hitObject);
                    if (selectedObject.CompareTag("AK"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isToggle)
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = true;
                            selectedObject.GetComponent<Outline>().enabled = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = false;
                            selectedObject.GetComponent<Outline>().enabled = false;
                        }

                    }
                    else if (selectedObject.CompareTag("SP"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isToggle)
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = true;
                            selectedObject.GetComponent<Outline>().enabled = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = false;
                            selectedObject.GetComponent<Outline>().enabled = false;
                        }

                    }
                    else if (selectedObject.CompareTag("A"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isToggle)
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = true;
                            selectedObject.GetComponent<Outline>().enabled = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = false;
                            selectedObject.GetComponent<Outline>().enabled = false;
                        }

                    }
                    else if (selectedObject.CompareTag("B"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isToggle)
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = true;
                            selectedObject.GetComponent<Outline>().enabled = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = false;
                            selectedObject.GetComponent<Outline>().enabled = false;
                        }

                    }
                    else if (selectedObject.CompareTag("LA"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isToggle)
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = true;
                            selectedObject.GetComponent<Outline>().enabled = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = false;
                            selectedObject.GetComponent<Outline>().enabled = false;
                        }

                    }

                    else if (selectedObject.CompareTag("AS"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isToggle)
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = true;
                            selectedObject.GetComponent<Outline>().enabled = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = false;
                            selectedObject.GetComponent<Outline>().enabled = false;
                        }

                    }
                    else if (selectedObject.CompareTag("BB"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isToggle)
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = true;
                            selectedObject.GetComponent<Outline>().enabled = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = false;
                            selectedObject.GetComponent<Outline>().enabled = false;
                        }

                    }
                    else if (selectedObject.CompareTag("JR"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isToggle)
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = true;
                            selectedObject.GetComponent<Outline>().enabled = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = false;
                            selectedObject.GetComponent<Outline>().enabled = false;
                        }

                    }
                    else if (selectedObject.CompareTag("PA"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isToggle)
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = true;
                            selectedObject.GetComponent<Outline>().enabled = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = false;
                            selectedObject.GetComponent<Outline>().enabled = false;
                        }

                    }
                    else if (selectedObject.CompareTag("PE"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isToggle)
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = true;
                            selectedObject.GetComponent<Outline>().enabled = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = false;
                            selectedObject.GetComponent<Outline>().enabled = false;
                        }

                    }

                    else if (selectedObject.CompareTag("C"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isToggle)
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = true;
                            selectedObject.GetComponent<Outline>().enabled = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = false;
                            selectedObject.GetComponent<Outline>().enabled = false;
                        }

                    }

                    else if (selectedObject.CompareTag("BE"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isToggle)
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = true;
                            selectedObject.GetComponent<Outline>().enabled = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = false;
                            selectedObject.GetComponent<Outline>().enabled = false;
                        }

                    }
                    else if (selectedObject.CompareTag("BI"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isToggle)
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = true;
                            selectedObject.GetComponent<Outline>().enabled = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = false;
                            selectedObject.GetComponent<Outline>().enabled = false;
                        }

                    }
                    else if (selectedObject.CompareTag("BI2"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isToggle)
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = true;
                            selectedObject.GetComponent<Outline>().enabled = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = false;
                            selectedObject.GetComponent<Outline>().enabled = false;
                        }

                    }
                    else if (selectedObject.CompareTag("D"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isToggle)
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = true;
                            selectedObject.GetComponent<Outline>().enabled = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = false;
                            selectedObject.GetComponent<Outline>().enabled = false;
                        }

                    }
                    else if (selectedObject.CompareTag("SW"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isToggle)
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = true;
                            selectedObject.GetComponent<Outline>().enabled = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<SelectedController>().isToggle = false;
                            selectedObject.GetComponent<Outline>().enabled = false;
                        }
                    }
                }

            }
        }
    }
}
