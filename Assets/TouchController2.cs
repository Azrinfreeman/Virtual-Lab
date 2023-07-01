using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController2 : MonoBehaviour
{
    public static TouchController2 instance;
    private void Awake()
    {
        instance = this;
    }
    public Transform[] alat;
    // Start is called before the first frame update
    void Start()
    {
        alat = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            alat[i] = transform.GetChild(i);
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
                //Debug.Log("touch\n");
                if (raycastHit.collider.transform.childCount >0)
                {
                    var hitObject = raycastHit.collider.transform.GetChild(0).name;
                    var selectedObject = raycastHit.collider.transform.GetChild(0);

                    //Debug.Log(hitObject);
                    if (hitObject.Equals("BeakerAmpaianAlbumen"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("SilinderPenyukat"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("BeakerAsidHidro"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("A"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("BeakerLarutanPepsin"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("B"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("botolAirSuling"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("penunu"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("stopwatch"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("beaker"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("penitis"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("botolBenedic"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("botolIodin"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("EnzimLipase"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("LarutanNA"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("BeakerMinyak"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("PencuciPinggan"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("LarutanFenolftelin"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("Syringe"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("TiubSpecimen1"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("TiubSpecimen2"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("TiubSpecimen3"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("TiubSpecimen4"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("Syringejarum"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("AsidAskorbik"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("DCPIP"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("JusOren"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("JusLimauNipis"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("JusLobakMerah"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("BikarA"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("BikarB"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("BikarC"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("BikarAis"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("BikarAir"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("BikarAirPanas"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("weight"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("Clamp"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("plasticin"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("peanut"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                    else if (hitObject.Equals("gajus"))
                    {
                        if (!selectedObject.GetComponent<SelectedController>().isSelected)
                        {
                            selectedObject.GetComponent<Outline>().enabled = true;
                            selectedObject.GetComponent<SelectedController>().isSelected = true;
                        }
                        else
                        {
                            selectedObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<SelectedController>().isSelected = false;

                        }
                    }
                }


            }
        }
    }


    public void FindAlat(string namaAlat)
    {
        for (int i = 0; i < alat.Length; i++)
        {
            if (alat[i].Equals(namaAlat))
            {

            }
        }
    }
}
