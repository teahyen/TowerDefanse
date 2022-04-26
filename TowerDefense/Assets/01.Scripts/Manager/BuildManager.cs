using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class BuildManager : Singleton<BuildManager>
{
    public GameObject towerPrefab = null;               // 타워 프리팹

    private Camera mainCam = null;
    private Ray ray = default;
    private RaycastHit hit = default;

    void Awake()
    {
        mainCam = Camera.main;
    }

    // 타워를 스폰하는 함수
    void SpawnTower(Transform tileTransform)
    {
        // Tower 가 SpawnTile 자식으로 들어감
        if (tileTransform.childCount < 1)
        {
            Instantiate(towerPrefab, tileTransform);
        }
    }

    // 스폰 가능한 타일인지 Raycast 로 체크하는 함수
    public void SpawnableTileRaycast(InputAction.CallbackContext context)
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (context.ReadValueAsButton())
            {
                ray = mainCam.ScreenPointToRay(GameManager.Instance.mousePosition);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.transform.CompareTag("SpawnTile"))
                    {
                        SpawnTower(hit.transform);
                    }
                }
            }
        }
    }
    

    // 
    public void SpawnTileColor()
    {

    }
}
