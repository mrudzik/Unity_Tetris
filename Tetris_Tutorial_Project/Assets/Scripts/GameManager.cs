using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	
	public GameObject		brick;
	public float 			timerSpeed = 4f;
	public float 			gameSpeed = 1f;

	public LayerMask 		blockingLayer;
	public LayerMask 		freezeLayer;
	public Text 			scoreText;
	public Text 			timeText;
	public Text 			gameOverText;

	private bool 			gameOver;
	private float 			turnTimer;
	private float 			gameTimer;
	private int 			score;
	private int 			nextFigure;


	private BoardManager 	boardScript;
	private FigureGen		figGenScript;

	[HideInInspector]
	public 	GameObject[]		figureBricks = new GameObject [4];
	private	Transform 			figure;

	[HideInInspector]
	public 	GameObject[]		figureBricksNext = new GameObject [4];
	private	Transform 			figureNext;

	private	BoxCollider2D[]		boxCollider = new BoxCollider2D [4];
	private Vector3[] 			tempRotateBricks = new Vector3 [4];

	void	Start()
	{
								
		boardScript = GetComponent<BoardManager>();
		figGenScript = GetComponent<FigureGen>();
		figure = new GameObject ("Figura").transform;
		figureNext = new GameObject ("FiguraNext").transform;
		nextFigure = (int)Random.Range(0, 7);
		SetupFigure();
		// boxCollider = Figure.brick.GetComponent<BoxCollider2D>();
		gameOver = false;
		turnTimer = 1;
		gameSpeed = 1;
		score = 0;
	}


	void 	Update()
	{
		if (gameOver)
		{
			gameOverText.text = "Game Over";
		}
		else
		{
			GameStuff();
		}

		
	}

	private void 	GameStuff()
	{
		int 	horizontal = 0;
		int 	vertical = 0;
		int 	rotate = 0;

		horizontal 	= (int)Input.GetAxisRaw("Horizontal");
		vertical 	= (int)Input.GetAxisRaw("Vertical");
		rotate 		= (int)Input.GetAxisRaw("Jump");

		score += boardScript.CheckLineDestruct();
		if (turnTimer >= 1)
		{
			FigureMove(horizontal, vertical, rotate);
		}
		else
			turnTimer += timerSpeed * Time.deltaTime;

		if (gameTimer >= 1)
		{
			FigureMove(0, -1, 0);
			gameTimer = 0;
		}
		gameTimer += gameSpeed * Time.deltaTime;
		scoreText.text = "Score : " + score;
		timeText.text = "Time : " + (int)Time.fixedTime;

	}

	private void	SetupFigure()
	{
		int i = 0;
		while (i < 4)
		{
			Vector3 	figPos = new Vector3 (0, 0, 0);

			figureBricks[i] = Instantiate(brick, figPos, Quaternion.identity, figure) as GameObject;
			figureBricksNext[i] = Instantiate(brick, figPos, Quaternion.identity, figureNext) as GameObject;
			boxCollider[i] = figureBricks[i].GetComponent<BoxCollider2D>();
			i++;
		}

		figGenScript.GenerateFigure(2, boardScript.GetRows() - 1, nextFigure);
		
		nextFigure = (int)Random.Range(0, 7);
		figGenScript.GenerateFigureNext(-7, boardScript.GetRows() - 7, nextFigure);
	}


	private bool 	FigureAttemptNotFreeze(int xDir, int yDir)
	{
		int i = 0;
		while (i < 4)
		{
			Vector2			start = figureBricks[i].transform.position;
    		Vector2 		end = start + new Vector2 (xDir, yDir);
    		RaycastHit2D 	hit;

    		boxCollider[i].enabled = false;
    		hit = Physics2D.Linecast (start, end, freezeLayer);
    		boxCollider[i].enabled = true;
    		if (hit.transform != null)
    			return false;
			i++;
		}
		return true;
	}

	private bool	FigureAttemptMove(int xDir, int yDir)
	{
		int i = 0;
		while (i < 4)
		{
			Vector2			start = figureBricks[i].transform.position;
    		Vector2 		end = start + new Vector2 (xDir, yDir);
    		RaycastHit2D 	hit;

    		boxCollider[i].enabled = false;
    		hit = Physics2D.Linecast (start, end, blockingLayer);
    		boxCollider[i].enabled = true;
    		if (hit.transform != null)
    			return false;
			i++;
		}
		return true;
	}

	private void 	FigureMoveNormalBehavior(int horizontal, int vertical)
	{
		if (FigureAttemptMove(horizontal, vertical))
		{
			int i = 0;
			while (i < 4)
			{
				figureBricks[i].transform.Translate(new Vector3 (horizontal, vertical, 0));
				i++;
			}
		}
	}

	private void 	FigureRotate()
	{
		Vector3	firstBrickPos = figureBricks[0].transform.position;
		
		int i = 1;
		while (i < 4)
		{
			Vector3 tempBrickPos = figureBricks[i].transform.position - firstBrickPos;
			Vector3 rotatedVector = new Vector3 (-1 * tempBrickPos.y, tempBrickPos.x, 0f);
			tempRotateBricks[i] = rotatedVector + firstBrickPos;


			RaycastHit2D 	hit;
    		boxCollider[i].enabled = false;
    		hit = Physics2D.Linecast (figureBricks[i].transform.position, tempRotateBricks[i], blockingLayer);
    		if (hit.transform != null)
    			return;
    		hit = Physics2D.Linecast (figureBricks[i].transform.position, tempRotateBricks[i], freezeLayer);
    		if (hit.transform != null)
    			return;
    		boxCollider[i].enabled = true;

			i++;
		}

		i = 1;
		while (i < 4)
		{
			figureBricks[i].transform.position = tempRotateBricks[i];
			i++;
		}
	}

	private void	FigureMove(int horizontal, int vertical, int rotate)
	{
		if (rotate != 0)
		{
			turnTimer = 0;
			FigureRotate();
		}

		if (horizontal != 0 || vertical > 0)
			vertical = 0;

		if (horizontal != 0 || vertical != 0)
		{
			
			turnTimer = 0;
			if (FigureAttemptNotFreeze(horizontal, vertical))
			{
				FigureMoveNormalBehavior(horizontal, vertical);
			}
			else
			{
				if (vertical != 0)
				{
					score += 10;
					boardScript.FreezeFigureOnBoard();
					SetupFigure();
					gameOver = CheckIfGameOver();
				}
			}	
		}
	}

	private bool 	CheckIfGameOver()
	{
		int i = 1;
		while (i < 4)
		{
			RaycastHit2D 	hit;

    		boxCollider[i].enabled = false;
    		hit = Physics2D.Linecast (figureBricks[i].transform.position, figureBricks[i].transform.position, blockingLayer);
    		if (hit.transform != null)
    			return true;
    		hit = Physics2D.Linecast (figureBricks[i].transform.position, figureBricks[i].transform.position, freezeLayer);
    		if (hit.transform != null)
    			return true;
    		boxCollider[i].enabled = true;

			i++;
		}
		return false;
	}
}
