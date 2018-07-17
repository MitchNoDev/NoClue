using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretSpawn : MonoBehaviour {

    public GameObject[] turrets;

    public PathFinding pathfinding;
    public GridController grid;
    public GameController GC;
    bool nodeSelected;

    public GameObject[] towerMenu;

    public Vector3 spawnOffset;

    public GameObject selectedNode;
    
    public bool canBuild;

    private void Start()
    {
        pathfinding = GetComponent<PathFinding>();
        grid = GetComponent<GridController>();
        GC = GetComponent<GameController>();
    }

    void Update()
    {
        if (canBuild)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                GameObject objectHit = hit.transform.gameObject;

                if (Input.GetMouseButtonDown(0) && objectHit.tag == "Turret Spawn")
                {
                    if (selectedNode == null)
                    {

                        foreach(GameObject button in towerMenu)
                        {
                            button.GetComponent<Button>().interactable = true;
                        }

                        selectedNode = objectHit;
                        selectedNode.layer = 8;
                        
                        grid.FillGrid();
                        pathfinding.triggerPath = true;
                    }
                    else if (selectedNode != null && selectedNode != objectHit)
                    {
                        selectedNode.layer = 0;
                        selectedNode = objectHit;
                        selectedNode.layer = 8;

                        grid.FillGrid();
                        pathfinding.triggerPath = true;
                    }
                }
            }

            if (Input.GetMouseButtonDown(1) && selectedNode != null)
            {

                selectedNode.layer = 0;
                selectedNode = null;

                grid.FillGrid();
                pathfinding.triggerPath = true;

                foreach (GameObject button in towerMenu)
                {
                    button.GetComponent<Button>().interactable = false;
                }
            }
        }
    }

    public void SpawnBaseTurret(GameObject objHit)
    {
        objHit = selectedNode;

        Instantiate(turrets[0], position: (objHit.transform.position + spawnOffset), rotation: Quaternion.Euler(0, 0, 0), parent: objHit.transform);
        selectedNode = null;

        foreach (GameObject button in towerMenu)
        {
            button.GetComponent<Button>().interactable = false;
        }
    }

    public void SpawnFastTurret(GameObject objHit)
    {
        objHit = selectedNode;

        Instantiate(turrets[1], position: (objHit.transform.position + spawnOffset), rotation: Quaternion.Euler(0, 0, 0), parent: objHit.transform);
        selectedNode = null;

        foreach (GameObject button in towerMenu)
        {
            button.GetComponent<Button>().interactable = false;
        }
    }

    public void SpawnSlowTurret(GameObject objHit)
    {
        objHit = selectedNode;

        Instantiate(turrets[2], position: (objHit.transform.position + spawnOffset), rotation: Quaternion.Euler(0, 0, 0), parent: objHit.transform);
        selectedNode = null;

        foreach (GameObject button in towerMenu)
        {
            button.GetComponent<Button>().interactable = false;
        }
    }
}
