using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{


    public Vector3 screenPoint;
    public Vector3 offset;

    public bool isW;
    public bool isStop;
    public bool isStep2;

    public bool isProcedure;


    void OnMouseDown()
    {
        //  Cursors.instance.cursors[0].gameObject.SetActive(true);

        //  Cursors.instance.cursors[1].gameObject.SetActive(false);
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        if (isProcedure)
        {
            if (!isStop)
            {

                Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
                Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;

                if (isW)
                {
                    transform.position = cursorPosition;
                    cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z + 10f);
                }
                else
                {
                    transform.position = cursorPosition;
                }
            }
        }


    }

    void OnMouseUp()
    {
        // Cursors.instance.cursors[0].gameObject.SetActive(false);

        // Cursors.instance.cursors[1].gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            isW = true;
        }
        else
        {
            isW = false;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            if (transform.GetChild(0).GetComponent<SelectedController>().isSelected)
            {
                transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.x + 55f * Time.deltaTime, Space.World);
            }
        }

        if (Input.GetKey(KeyCode.E))
        {
            if (transform.GetChild(0).GetComponent<SelectedController>().isSelected)
            {
                transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.x + -55f * Time.deltaTime, Space.World);
            }

        }

    }

    private void OnCollisionEnter(Collision other)
    {

        if (isStep2)
        {
            if (ObjectController.instance.Eksperimen == 2)
            {
                //step1
                if (gameObject.name == "BikarAmpaianKanjiParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step2
                if (gameObject.name == "AParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step3
                if (gameObject.name == "BikarAmpaianKanjiParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step4
                if (gameObject.name == "BParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step5
                if (gameObject.name == "BikarAmilaseParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step6
                if (gameObject.name == "AParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step7
                if (gameObject.name == "botolAirSulingParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step8
                if (gameObject.name == "BParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step15
                if (gameObject.name == "AParent" && other.gameObject.name == "penitisParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step16
                if (gameObject.name == "CParent" && other.gameObject.name == "penitisParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step17
                if (gameObject.name == "CParent" && other.gameObject.name == "penitisParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step21
                if (gameObject.name == "AParent" && other.gameObject.name == "penitisParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step22-23
                if (gameObject.name == "BParent" && other.gameObject.name == "penitisParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step24
                if (gameObject.name == "DParent" && other.gameObject.name == "penitisParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
            }

        }
        else
        {
            if (ObjectController2.instance.Eksperimen == 3)
            {
                //step1
                if (gameObject.name == "BeakerAmpaianAlbumenParent" && other.gameObject.name == "SilinderPenyukatParent")
                {
                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step2
                if (gameObject.name == "AParent" && other.gameObject.name == "SilinderPenyukatParent")
                {
                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;
                }

                //step3
                if (gameObject.name == "BeakerAsidHidroParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }

                //step4
                if (gameObject.name == "AParent" && other.gameObject.name == "SilinderPenyukatParent")
                {
                    Debug.Log("A Parent");
                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step6
                if (gameObject.name == "BeakerLarutanPepsinParent" && other.gameObject.name == "SilinderPenyukatParent")
                {
                    Debug.Log("A Parent");
                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step7
                if (gameObject.name == "AParent" && other.gameObject.name == "SilinderPenyukatParent")
                {
                    Debug.Log("A Parent");
                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step9
                if (gameObject.name == "BeakerAmpaianAlbumenParent" && other.gameObject.name == "SilinderPenyukatParent")
                {
                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step10
                if (gameObject.name == "SilinderPenyukatParent" && other.gameObject.name == "BParent")
                {
                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step11
                if (gameObject.name == "BeakerAsidHidroParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step12
                if (gameObject.name == "BParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }

                //step14
                if (gameObject.name == "botolAirSulingParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }

                //step15
                if (gameObject.name == "BParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step18
                if (gameObject.name == "AParent" && other.gameObject.name == "beakerParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step19
                if (gameObject.name == "BParent" && other.gameObject.name == "beakerParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
            }
            else if (ObjectController2.instance.Eksperimen == 4)
            {
                //step1
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "BeakerMinyakParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step2
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "AParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step3
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "LarutanNAParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step4
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "AParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step5
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "PencuciPingganParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step6
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "AParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step9
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "AParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step10
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "BParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step11
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "LarutanNAParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step12
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "BParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step13
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "PencuciPingganParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step14
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "BParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step17
                if (gameObject.name == "penitisParent" && other.gameObject.name == "LarutanFenolftelinParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step18
                if (gameObject.name == "penitisParent" && other.gameObject.name == "AParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step19
                if (gameObject.name == "penitisParent" && other.gameObject.name == "LarutanFenolftelinParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step20
                if (gameObject.name == "penitisParent" && other.gameObject.name == "BParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }

                //step21
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "EnzimLipaseParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step22
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "AParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step23
                if (gameObject.name == "botolAirSulingParent" && other.gameObject.name == "BParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step25
                if (gameObject.name == "beakerParent" && other.gameObject.name == "AParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step26
                if (gameObject.name == "beakerParent" && other.gameObject.name == "BParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
            }
            else if (ObjectController2.instance.Eksperimen == 5)
            {
                //step1
                if (gameObject.name == "gajusParent" && other.gameObject.name == "weightParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step3
                if (gameObject.name == "botolAirSulingParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step4
                if (gameObject.name == "ClampParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step9
                if (gameObject.name == "gajusParent" && other.gameObject.name == "plasticinParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step13
                if (gameObject.name == "gajusParent" && other.gameObject.name == "plasticinParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step17
                if (gameObject.name == "botolAirSulingParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step18
                if (gameObject.name == "ClampParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step23
                if (gameObject.name == "weightParent" && other.gameObject.name == "peanutParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step25
                if (gameObject.name == "plasticinParent" && other.gameObject.name == "peanutParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
            }
            else if (ObjectController2.instance.Eksperimen == 6)
            {
                //step1
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "DCPIPParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step2
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "TiubSpecimen1Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step3
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "DCPIPParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step4
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "TiubSpecimen2Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step5
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "DCPIPParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step6
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "TiubSpecimen3Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step7
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "DCPIPParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step8
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "TiubSpecimen4Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step9
                if (gameObject.name == "SyringeJarumParent" && other.gameObject.name == "AsidAskorbikParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step10
                if (gameObject.name == "SyringeJarumParent" && other.gameObject.name == "TiubSpecimen1Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step13
                if (gameObject.name == "SyringeJarumParent" && other.gameObject.name == "JusOrenParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step14
                if (gameObject.name == "SyringeJarumParent" && other.gameObject.name == "TiubSpecimen2Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step17
                if (gameObject.name == "SyringeJarumParent" && other.gameObject.name == "JusLimauNipisParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step18
                if (gameObject.name == "SyringeJarumParent" && other.gameObject.name == "TiubSpecimen3Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step21
                if (gameObject.name == "SyringeJarumParent" && other.gameObject.name == "JusLobakMerahParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step22
                if (gameObject.name == "SyringeJarumParent" && other.gameObject.name == "TiubSpecimen4Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step23
                if (gameObject.name == "SyringeJarumParent" && other.gameObject.name == "JusLobakMerahParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step24
                if (gameObject.name == "SyringeJarumParent" && other.gameObject.name == "TiubSpecimen4Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
            }
            else if (ObjectController2.instance.Eksperimen == 7)
            {
                //step1
                if (gameObject.name == "BikarAParent" && other.gameObject.name == "BikarAisParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
                //step2
                if (gameObject.name == "BikarBParent" && other.gameObject.name == "BikarAirParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step3
                if (gameObject.name == "BikarCParent" && other.gameObject.name == "BikarAirPanasParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step5
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "DCPIPParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step6
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "TiubSpecimen1Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step7
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "DCPIPParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step8
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "TiubSpecimen2Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step9
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "DCPIPParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step10
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "TiubSpecimen3Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step11
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "DCPIPParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step12
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "TiubSpecimen4Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step13
                if (gameObject.name == "SyringejarumParent" && other.gameObject.name == "AsidAskorbikParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step14
                if (gameObject.name == "SyringejarumParent" && other.gameObject.name == "TiubSpecimen1Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step17
                if (gameObject.name == "SyringejarumParent" && other.gameObject.name == "BikarAParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step18
                if (gameObject.name == "SyringejarumParent" && other.gameObject.name == "TiubSpecimen2Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step21
                if (gameObject.name == "SyringejarumParent" && other.gameObject.name == "BikarBParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step22
                if (gameObject.name == "SyringejarumParent" && other.gameObject.name == "TiubSpecimen3Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step25
                if (gameObject.name == "SyringejarumParent" && other.gameObject.name == "BikarCParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }//step26
                if (gameObject.name == "SyringejarumParent" && other.gameObject.name == "TiubSpecimen4Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = true;
                    gameObject.GetComponent<IsCollided>().isCollide = true;

                }
            }
        }

    }

    private void OnCollisionExit(Collision other)
    {
        if (isStep2)
        {
            if (ObjectController.instance.Eksperimen == 2)
            {
                //step1
                if (gameObject.name == "BikarAmpaianKanjiParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step2
                if (gameObject.name == "AParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step3
                if (gameObject.name == "BikarAmpaianKanjiParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step4
                if (gameObject.name == "BParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step5
                if (gameObject.name == "BikarAmilaseParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step6
                if (gameObject.name == "AParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step7
                if (gameObject.name == "botolAirSulingParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step8
                if (gameObject.name == "BParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step15
                if (gameObject.name == "AParent" && other.gameObject.name == "penitisParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step16
                if (gameObject.name == "CParent" && other.gameObject.name == "penitisParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step17
                if (gameObject.name == "CParent" && other.gameObject.name == "botolBenedicParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step21
                if (gameObject.name == "AParent" && other.gameObject.name == "botolIodinParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step22-23
                if (gameObject.name == "BParent" && other.gameObject.name == "botolIodinParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step24
                if (gameObject.name == "BParent" && other.gameObject.name == "botolIodinParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
            }

        }
        else
        {
            if (ObjectController2.instance.Eksperimen == 3)
            {
                //step1
                if (gameObject.name == "BeakerAmpaianAlbumenParent" && other.gameObject.name == "SilinderPenyukatParent")
                {
                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step2
                if (gameObject.name == "AParent" && other.gameObject.name == "SilinderPenyukatParent")
                {
                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;
                }
                //step3
                if (gameObject.name == "BeakerAsidHidroParent" && other.gameObject.name == "SilinderPenyukatParent")
                {
                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step4
                if (gameObject.name == "AParent" && other.gameObject.name == "SilinderPenyukatParent")
                {
                    Debug.Log("A Parent");
                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step6
                if (gameObject.name == "BeakerLarutanPepsinParent" && other.gameObject.name == "SilinderPenyukatParent")
                {
                    Debug.Log("Pepsin");
                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step7
                if (gameObject.name == "AParent" && other.gameObject.name == "SilinderPenyukatParent")
                {
                    Debug.Log("A Parent");
                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step9
                if (gameObject.name == "BeakerAmpaianAlbumenParent" && other.gameObject.name == "SilinderPenyukatParent")
                {
                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step10
                if (gameObject.name == "SilinderPenyukatParent" && other.gameObject.name == "BParent")
                {
                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step11
                if (gameObject.name == "BeakerAsidHidroParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step12
                if (gameObject.name == "BParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }

                //step14
                if (gameObject.name == "botolAirSulingParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }

                //step15
                if (gameObject.name == "BParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }

                //step18
                if (gameObject.name == "AParent" && other.gameObject.name == "beakerParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step19
                if (gameObject.name == "BParent" && other.gameObject.name == "beakerParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
            }
            else if (ObjectController2.instance.Eksperimen == 4)
            {
                //step1
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "BeakerMinyakParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step2
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "AParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step3
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "LarutanNAParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step4
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "AParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step5
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "PencuciPingganParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step6
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "AParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step9
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "AParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step10
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "BParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step11
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "LarutanNAParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step12
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "BParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step13
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "PencuciPingganParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step14
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "BParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step17
                if (gameObject.name == "penitisParent" && other.gameObject.name == "LarutanFenolftelinParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step18
                if (gameObject.name == "penitisParent" && other.gameObject.name == "AParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step19
                if (gameObject.name == "penitisParent" && other.gameObject.name == "LarutanFenolftelinParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step20
                if (gameObject.name == "penitisParent" && other.gameObject.name == "BParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }

                //step21
                if (gameObject.name == "syringeParent" && other.gameObject.name == "EnzimLipaseParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step22
                if (gameObject.name == "syringeParent" && other.gameObject.name == "AParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step23
                if (gameObject.name == "botolAirSulingParent" && other.gameObject.name == "BParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step25
                if (gameObject.name == "beakerParent" && other.gameObject.name == "AParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step26
                if (gameObject.name == "beakerParent" && other.gameObject.name == "BParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
            }
            else if (ObjectController2.instance.Eksperimen == 5)
            {
                //step1
                if (gameObject.name == "gajusParent" && other.gameObject.name == "weightParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step3
                if (gameObject.name == "botolAirSulingParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step4
                if (gameObject.name == "ClampParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step9
                if (gameObject.name == "gajusParent" && other.gameObject.name == "plasticinParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step13
                if (gameObject.name == "gajusParent" && other.gameObject.name == "plasticinParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step17
                if (gameObject.name == "botolAirSulingParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step18
                if (gameObject.name == "ClampParent" && other.gameObject.name == "SilinderPenyukatParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step23
                if (gameObject.name == "weightParent" && other.gameObject.name == "peanutParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step25
                if (gameObject.name == "plasticinParent" && other.gameObject.name == "peanutParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
            }
            else if (ObjectController2.instance.Eksperimen == 6)
            {
                //step1
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "DCPIPParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step2
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "TiubSpecimen1Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step3
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "DCPIPParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step4
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "TiubSpecimen2Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step5
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "DCPIPParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step6
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "TiubSpecimen3Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step7
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "DCPIPParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step8
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "TiubSpecimen4Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step9
                if (gameObject.name == "SyringeJarumParent" && other.gameObject.name == "AsidAskorbikParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step10
                if (gameObject.name == "SyringeJarumParent" && other.gameObject.name == "TiubSpecimen1Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step13
                if (gameObject.name == "SyringeJarumParent" && other.gameObject.name == "JusOrenParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step14
                if (gameObject.name == "SyringeJarumParent" && other.gameObject.name == "TiubSpecimen2Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step17
                if (gameObject.name == "SyringeJarumParent" && other.gameObject.name == "JusLimauNipisParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step18
                if (gameObject.name == "SyringeJarumParent" && other.gameObject.name == "TiubSpecimen3Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step21
                if (gameObject.name == "SyringeJarumParent" && other.gameObject.name == "JusLobakMerahParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step22
                if (gameObject.name == "SyringeJarumParent" && other.gameObject.name == "TiubSpecimen4Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step23
                if (gameObject.name == "SyringeJarumParent" && other.gameObject.name == "JusLobakMerahParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step24
                if (gameObject.name == "SyringeJarumParent" && other.gameObject.name == "TiubSpecimen4Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
            }
            else if (ObjectController2.instance.Eksperimen == 7)

            {
                //step1
                if (gameObject.name == "BikarAParent" && other.gameObject.name == "BikarAisParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
                //step2
                if (gameObject.name == "BikarBParent" && other.gameObject.name == "BikarAirParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step3
                if (gameObject.name == "BikarCParent" && other.gameObject.name == "BikarAirPanasParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step5
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "DCPIPParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step6
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "TiubSpecimen1Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step7
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "DCPIPParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step8
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "TiubSpecimen2Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step9
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "DCPIPParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step10
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "TiubSpecimen3Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step11
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "DCPIPParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step12
                if (gameObject.name == "SyringeParent" && other.gameObject.name == "TiubSpecimen4Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step13
                if (gameObject.name == "SyringejarumParent" && other.gameObject.name == "AsidAskorbikParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step14
                if (gameObject.name == "SyringejarumParent" && other.gameObject.name == "TiubSpecimen1Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step17
                if (gameObject.name == "SyringejarumParent" && other.gameObject.name == "BikarAParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step18
                if (gameObject.name == "SyringejarumParent" && other.gameObject.name == "TiubSpecimen2Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step21
                if (gameObject.name == "SyringejarumParent" && other.gameObject.name == "BikarBParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step22
                if (gameObject.name == "SyringejarumParent" && other.gameObject.name == "TiubSpecimen3Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step25
                if (gameObject.name == "SyringejarumParent" && other.gameObject.name == "BikarCParent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }//step26
                if (gameObject.name == "SyringejarumParent" && other.gameObject.name == "TiubSpecimen4Parent")
                {

                    other.gameObject.GetComponent<IsCollided>().isCollide = false;
                    gameObject.GetComponent<IsCollided>().isCollide = false;

                }
            }
        }

    }
}
