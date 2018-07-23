using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD

public class TurretSpawn : MonoBehaviour {
    
    public GameObject turretPrefab;
=======
using UnityEngine.UI;

public class TurretSpawn : MonoBehaviour {

    public GameObject[] turrets;

>>>>>>> cb469ab9e9fc62a367cb6d55bd8de9e7e3fa8131
    public PathFinding pathfinding;
    public GridController grid;
    public GameController GC;
    bool nodeSelected;

<<<<<<< HEAD
=======
    public GameObject[] towerMenu;

>>>>>>> cb469ab9e9fc62a367cb6d55bd8de9e7e3fa8131
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
<<<<<<< HEAD
=======

                        foreach(GameObject button in towerMenu)
                        {
                            button.GetComponent<Button>().interactable = true;
                        }

>>>>>>> cb469ab9e9fc62a367cb6d55bd8de9e7e3fa8131
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
<<<<<<< HEAD
                    else if (selectedNode != null && selectedNode == objectHit && pathfinding.possible)
                    {
                        selectedNode.GetComponent<NodeController>().towerOn = true;
                        selectedNode.GetComponent<NodeController>().trigger = true;
                        SpawnTurret(selectedNode);
                    }
=======
>>>>>>> cb469ab9e9fc62a367cb6d55bd8de9e7e3fa8131
                }
            }

            if (Input.GetMouseButtonDown(1) && selectedNode != null)
            {
<<<<<<< HEAD
=======

>>>>>>> cb469ab9e9fc62a367cb6d55bd8de9e7e3fa8131
                selectedNode.layer = 0;
                selectedNode = null;

                grid.FillGrid();
                pathfinding.triggerPath = true;
<<<<<<< HEAD
=======

                foreach (GameObject button in towerMenu)
                {
                    button.GetComponent<Button>().interactable = false;
                }
>>>>>>> cb469ab9e9fc62a367cb6d55bd8de9e7e3fa8131
            }
        }
    }

<<<<<<< HEAD
    void SpawnTurret(GameObject objHit)
    {  
        Instantiate(turretPrefab, position: (objHit.transform.position + spawnOffset), rotation: Quaternion.Euler(0, 0, 0), parent: objHit.transform);
        selectedNode = null;
=======
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
>>>>>>> cb469ab9e9fc62a367cb6d55bd8de9e7e3fa8131
    }
}
