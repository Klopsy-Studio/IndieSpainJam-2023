using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCharacterGrow : MonoBehaviour
{
    [HideInInspector] public PlayerCharacter parent;
    [SerializeField] CinemachineFreeLook camera;

    public float growthReduction = 0;

    [SerializeField] float baseCam;
    [SerializeField] float valueLevel1;
    [SerializeField] float valueLevel2;

    [SerializeField] float cameraSpeed;
    bool level1;
    bool level1Done;
    bool level2;
    bool level2Done;

    private void Start()
    {
        ResetCamera();
    }
    public void Grow(float growth)
    {
        growth -= growthReduction;

        if (growth <= 0) { growth = 0; }

        parent.transform.localScale = new Vector3(transform.localScale.x + growth, transform.localScale.y + growth, transform.localScale.z + growth);

        if(parent.transform.localScale.x >= 2)
        {
            level1 = true;
        }

        if (parent.transform.localScale.x >= 4)
        {
            level2 = true;
        }
        GameManager.instance.HandlePoolGrowth(growth);

    }
    public void ResetCamera()
    {
        camera.m_YAxis.Value = baseCam;
    }
    public void Update()
    {
        if (level1 && !level1Done)
        {
            camera.m_YAxis.Value = Mathf.Lerp(camera.m_YAxis.Value, valueLevel1, Time.deltaTime* cameraSpeed);

            if(camera.m_YAxis.Value >= valueLevel1)
            {
                camera.m_YAxis.Value = valueLevel1;
                level1Done = true;
            }
        }

        if(level2 && !level2Done)
        {
            camera.m_YAxis.Value = Mathf.Lerp(camera.m_YAxis.Value, valueLevel2, Time.deltaTime * cameraSpeed);

            if (camera.m_YAxis.Value >= valueLevel2)
            {
                camera.m_YAxis.Value = valueLevel2;
                level2Done = true;
            }
        }

    }

}
