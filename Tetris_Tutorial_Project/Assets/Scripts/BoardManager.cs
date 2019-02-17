using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{

	public const int 				columns = 12;
	public const int 				rows = 22;

	public int 		scorePerLine = 200; 

	public GameObject		wallTile;
	public GameObject		backTile;
	public GameObject 		freezeTile;

	private GameManager 		gameScript;
	private Transform 			boardHolder;
	public 	GameObject[][]		tileArray = new GameObject[rows][];

	public int 		GetRows()
	{
		return rows;
	}

	public int 		GetColumns()
	{
		return columns;
	}

    void 	BoardSetup()
	{
		boardHolder = new GameObject ("Board").transform;

		for (int y = 0; y < rows; y++)
		{
			tileArray[y] = new GameObject[columns];
			for (int x = 0; x < columns; x++)
			{
				GameObject toInstatiate = backTile;
				if (x == 0 || x == columns - 1 || y == rows - 1)
					toInstatiate = wallTile;
				else if (y == 0)
					toInstatiate = freezeTile;

				tileArray[y][x] = Instantiate(toInstatiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
				tileArray[y][x].transform.SetParent(boardHolder);
			}
		}
	}

	void 	Awake()
	{
		gameScript = GetComponent<GameManager>();
		BoardSetup();
	}


	public	void 	FreezeFigureOnBoard()
	{
		int x;
		int y;
		int i = 0;
		while (i < 4)
		{
			// Vector3 brickPos = gameScript.figureBricks[i].transform.position;
			y = (int)gameScript.figureBricks[i].transform.position.y;
			x = (int)gameScript.figureBricks[i].transform.position.x;

			Destroy(tileArray[y][x]);
			tileArray[y][x] = Instantiate(freezeTile, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
			tileArray[y][x].transform.SetParent(boardHolder);

			Destroy(gameScript.figureBricks[i]);
			Destroy(gameScript.figureBricksNext[i]);
			i++;
		}
	}

	private void 	ShiftDown(int height)
	{
		int x;
		int y = height;

		while (y < rows - 1)
		{
			x = 1;
			while (x < columns - 1)
			{
				if (tileArray[y][x].CompareTag("FreezeBlock") && tileArray[y - 1][x].CompareTag("BackBlock"))
				{
					Destroy(tileArray[y][x]);
					tileArray[y][x] = Instantiate(backTile, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
					tileArray[y][x].transform.SetParent(boardHolder);

					Destroy(tileArray[y - 1][x]);
					tileArray[y - 1][x] = Instantiate(freezeTile, new Vector3 (x, y - 1, 0f), Quaternion.identity) as GameObject;
					tileArray[y - 1][x].transform.SetParent(boardHolder);
				}
				x++;
			}
			y++;
		}
	}

	public 	int 	CheckLineDestruct()
	{
		int x;
		int y;
		int count;

		y = 1;
		while (y < rows - 1)
		{
			//Check "y" line loop
			x = 1;
			count = 0;
			while (x < columns - 1)
			{
				if (tileArray[y][x].CompareTag("FreezeBlock"))
				{
					count++;
				}
				x++;
			}
			if (count >= columns - 2)
			{
				// Destroy line loop
				x = 1;
				while (x < columns - 1)
				{
					Destroy(tileArray[y][x]);
					tileArray[y][x] = Instantiate(backTile, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
					tileArray[y][x].transform.SetParent(boardHolder);
					x++;
				}
				ShiftDown(y);
				return scorePerLine;
			}
			y++;
		}
		return 0;
	}

}
