using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureGen : MonoBehaviour
{
	private GameManager 		gameScript;

    void Awake()
    {
       	gameScript = GetComponent<GameManager>();
    }


    /* I was to lazy to do it right with pointers on arrays */
    public void 	GenerateFigureNext (int x, int y, int i)
    {
    	int z = -3;
    
    	//_##
    	//__##
    	if (i == 0)
    	{
    		gameScript.figureBricksNext[0].transform.position = new Vector3 (x + 2, y - 1, z);
    		gameScript.figureBricksNext[1].transform.position = new Vector3 (x + 1, y - 1, z);
    		gameScript.figureBricksNext[2].transform.position = new Vector3 (x + 2, y - 2, z);
    		gameScript.figureBricksNext[3].transform.position = new Vector3 (x + 3, y - 2, z);
    	}
    	//__##
    	//_##
    	else if (i == 1)
    	{
    		gameScript.figureBricksNext[0].transform.position = new Vector3 (x + 2, y - 2, z);
    		gameScript.figureBricksNext[1].transform.position = new Vector3 (x + 1, y - 2, z);
    		gameScript.figureBricksNext[2].transform.position = new Vector3 (x + 2, y - 1, z);
    		gameScript.figureBricksNext[3].transform.position = new Vector3 (x + 3, y - 1, z);
    	}
    	//_#
    	//_#
    	//_##
    	else if (i == 2)
    	{
    		gameScript.figureBricksNext[0].transform.position = new Vector3 (x + 1, y - 2, z);
    		gameScript.figureBricksNext[1].transform.position = new Vector3 (x + 1, y - 1, z);
    		gameScript.figureBricksNext[2].transform.position = new Vector3 (x + 1, y - 3, z);
    		gameScript.figureBricksNext[3].transform.position = new Vector3 (x + 2, y - 3, z);
    	}
    	//__#
    	//__#
    	//_##
    	else if (i == 3)
    	{
    		gameScript.figureBricksNext[0].transform.position = new Vector3 (x + 2, y - 2, z);
    		gameScript.figureBricksNext[1].transform.position = new Vector3 (x + 2, y - 1, z);
    		gameScript.figureBricksNext[2].transform.position = new Vector3 (x + 2, y - 3, z);
    		gameScript.figureBricksNext[3].transform.position = new Vector3 (x + 1, y - 3, z);
    	}
    	//_##
    	//_##
    	else if (i == 4)
    	{
    		gameScript.figureBricksNext[0].transform.position = new Vector3 (x + 2, y - 1, z); 
    		gameScript.figureBricksNext[1].transform.position = new Vector3 (x + 1, y - 1, z);
    		gameScript.figureBricksNext[2].transform.position = new Vector3 (x + 1, y - 2, z);
    		gameScript.figureBricksNext[3].transform.position = new Vector3 (x + 2, y - 2, z);
    	}
    	//_#
    	//_#
    	//_#
    	//_#
    	else if (i == 5)
    	{
    		gameScript.figureBricksNext[0].transform.position = new Vector3 (x + 1, y - 2, z);
    		gameScript.figureBricksNext[1].transform.position = new Vector3 (x + 1, y - 1, z);
    		gameScript.figureBricksNext[2].transform.position = new Vector3 (x + 1, y - 3, z);
    		gameScript.figureBricksNext[3].transform.position = new Vector3 (x + 1, y - 4, z);
    	}
    	//__#
    	//_###
    	else if (i == 6)
    	{
    		gameScript.figureBricksNext[0].transform.position = new Vector3 (x + 2, y - 2, z);
    		gameScript.figureBricksNext[1].transform.position = new Vector3 (x + 2, y - 1, z);
    		gameScript.figureBricksNext[2].transform.position = new Vector3 (x + 1, y - 2, z);
    		gameScript.figureBricksNext[3].transform.position = new Vector3 (x + 3, y - 2, z);
    	}
    }

    public void 	GenerateFigure (int x, int y, int i)
    {
    	int z = -3;
 		
 		//_##
    	//__##
    	if (i == 0)
    	{
    		gameScript.figureBricks[0].transform.position = new Vector3 (x + 2, y - 1, z);
    		gameScript.figureBricks[1].transform.position = new Vector3 (x + 1, y - 1, z);
    		gameScript.figureBricks[2].transform.position = new Vector3 (x + 2, y - 2, z);
    		gameScript.figureBricks[3].transform.position = new Vector3 (x + 3, y - 2, z);
    	}
    	//__##
    	//_##
    	else if (i == 1)
    	{
    		gameScript.figureBricks[0].transform.position = new Vector3 (x + 2, y - 2, z);
    		gameScript.figureBricks[1].transform.position = new Vector3 (x + 1, y - 2, z);
    		gameScript.figureBricks[2].transform.position = new Vector3 (x + 2, y - 1, z);
    		gameScript.figureBricks[3].transform.position = new Vector3 (x + 3, y - 1, z);
    	}
    	//_#
    	//_#
    	//_##
    	else if (i == 2)
    	{
    		gameScript.figureBricks[0].transform.position = new Vector3 (x + 1, y - 2, z);
    		gameScript.figureBricks[1].transform.position = new Vector3 (x + 1, y - 1, z);
    		gameScript.figureBricks[2].transform.position = new Vector3 (x + 1, y - 3, z);
    		gameScript.figureBricks[3].transform.position = new Vector3 (x + 2, y - 3, z);
    	}
    	//__#
    	//__#
    	//_##
    	else if (i == 3)
    	{
    		gameScript.figureBricks[0].transform.position = new Vector3 (x + 2, y - 2, z);
    		gameScript.figureBricks[1].transform.position = new Vector3 (x + 2, y - 1, z);
    		gameScript.figureBricks[2].transform.position = new Vector3 (x + 2, y - 3, z);
    		gameScript.figureBricks[3].transform.position = new Vector3 (x + 1, y - 3, z);
    	}
    	//_##
    	//_##
    	else if (i == 4)
    	{
    		gameScript.figureBricks[0].transform.position = new Vector3 (x + 2, y - 1, z); 
    		gameScript.figureBricks[1].transform.position = new Vector3 (x + 1, y - 1, z);
    		gameScript.figureBricks[2].transform.position = new Vector3 (x + 1, y - 2, z);
    		gameScript.figureBricks[3].transform.position = new Vector3 (x + 2, y - 2, z);
    	}
    	//_#
    	//_#
    	//_#
    	//_#
    	else if (i == 5)
    	{
    		gameScript.figureBricks[0].transform.position = new Vector3 (x + 1, y - 2, z);
    		gameScript.figureBricks[1].transform.position = new Vector3 (x + 1, y - 1, z);
    		gameScript.figureBricks[2].transform.position = new Vector3 (x + 1, y - 3, z);
    		gameScript.figureBricks[3].transform.position = new Vector3 (x + 1, y - 4, z);
    	}
    	//__#
    	//_###
    	else if (i == 6)
    	{
    		gameScript.figureBricks[0].transform.position = new Vector3 (x + 2, y - 2, z);
    		gameScript.figureBricks[1].transform.position = new Vector3 (x + 2, y - 1, z);
    		gameScript.figureBricks[2].transform.position = new Vector3 (x + 1, y - 2, z);
    		gameScript.figureBricks[3].transform.position = new Vector3 (x + 3, y - 2, z);
    	}
    }
}
