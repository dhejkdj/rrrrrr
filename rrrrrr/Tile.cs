

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour {
	private static Color selectedColor = new Color(.5f, .5f, .5f, 1.0f);
	private static Tile previousSelected = null;
	public static int item = 2;
	private SpriteRenderer render;
	private bool isSelected = false;
	private Vector2 vector2;
	private Vector2[] adjacentDirections = new Vector2[] { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

	void Awake() {
		render = GetComponent<SpriteRenderer>();
		
	}

	private void Select() {
		isSelected = true;
		render.color = selectedColor;
		previousSelected = gameObject.GetComponent<Tile>();
		SFXManager.instance.PlaySFX(Clip.Select);
		
		
		
	}

	private void Deselect() {
		isSelected = false;
		render.color = Color.white;
		previousSelected = null;
	}

	void OnMouseDown() {

		
		if (item == 2)
		{
			item = 3;
			float MaxDistance = 15f;
			

			List<GameObject> matchingTiles = new List<GameObject>();
			RaycastHit2D hit = Physics2D.Raycast(transform.position,transform.right, MaxDistance);
			RaycastHit2D hit1 = Physics2D.Raycast(transform.position, transform.right *-1 , MaxDistance);
			RaycastHit2D hit2 = Physics2D.Raycast(transform.position, transform.up , MaxDistance);
			RaycastHit2D hit3 = Physics2D.Raycast(transform.position, transform.up *-1, MaxDistance);
			
			for (int i = 0; i < 13; i++)
			{
				while (hit.collider != null && hit.collider.GetComponent<SpriteRenderer>().sprite != render.sprite)
				{
					matchingTiles.Add(hit.collider.gameObject);
					hit = Physics2D.Raycast(hit.collider.transform.position, transform.right, MaxDistance);
				}
				while (hit.collider != null && hit.collider.GetComponent<SpriteRenderer>().sprite == render.sprite)
				{
					matchingTiles.Add(hit.collider.gameObject);
					hit = Physics2D.Raycast(hit.collider.transform.position, transform.right, MaxDistance);
				}
				while (hit1.collider != null && hit1.collider.GetComponent<SpriteRenderer>().sprite != render.sprite)
				{
					matchingTiles.Add(hit1.collider.gameObject);
					hit1 = Physics2D.Raycast(hit1.collider.transform.position, transform.right * -1, MaxDistance);
				}
				while (hit1.collider != null && hit1.collider.GetComponent<SpriteRenderer>().sprite == render.sprite)
				{
					matchingTiles.Add(hit1.collider.gameObject);
					hit1 = Physics2D.Raycast(hit1.collider.transform.position, transform.right * -1, MaxDistance);
				}
				while (hit2.collider != null && hit2.collider.GetComponent<SpriteRenderer>().sprite != render.sprite)
				{
					matchingTiles.Add(hit2.collider.gameObject);
					hit2 = Physics2D.Raycast(hit2.collider.transform.position, transform.up, MaxDistance);
				}
				while (hit2.collider != null && hit2.collider.GetComponent<SpriteRenderer>().sprite == render.sprite)
				{
					matchingTiles.Add(hit2.collider.gameObject);
					hit2 = Physics2D.Raycast(hit2.collider.transform.position, transform.up, MaxDistance);
				}
				while (hit3.collider != null && hit3.collider.GetComponent<SpriteRenderer>().sprite != render.sprite)
				{
					matchingTiles.Add(hit3.collider.gameObject);
					hit3 = Physics2D.Raycast(hit3.collider.transform.position, transform.up * -1, MaxDistance);
				}
				while (hit3.collider != null && hit3.collider.GetComponent<SpriteRenderer>().sprite == render.sprite)
				{
					matchingTiles.Add(hit3.collider.gameObject);
					hit3 = Physics2D.Raycast(hit3.collider.transform.position, transform.up * -1, MaxDistance);
				}
			}

			for (int i = 0; i < matchingTiles.Count; i++)
			{
				matchingTiles[i].GetComponent<SpriteRenderer>().sprite = null;

			}
			render.sprite = null;
			
			StopCoroutine(BoardManager.instance.FindNullTiles());
			StartCoroutine(BoardManager.instance.FindNullTiles());
		}

		if (item==3)
        {
			item = 4;
			List<GameObject> matchingTiles = new List<GameObject>();
			for (int i = 0; i < adjacentDirections.Length; i++)       ////////////
			{
				matchingTiles.Add(GetAdjacent(adjacentDirections[i]));     /////////////////

			}
			for (int i = 0; i < matchingTiles.Count; i++)
			{
				matchingTiles[i].GetComponent<SpriteRenderer>().sprite = null;

			}
			render.sprite = null;
			
			StopCoroutine(BoardManager.instance.FindNullTiles());
			StartCoroutine(BoardManager.instance.FindNullTiles());
		}

		if (item ==4)
        {
			item = 5;
			render.sprite = null;
			
			StopCoroutine(BoardManager.instance.FindNullTiles());
			StartCoroutine(BoardManager.instance.FindNullTiles());
		}

		if (item ==5)
        {
			item = 6;
			List<GameObject> matchingTiles = new List<GameObject>();


            RaycastHit2D hit2 = Physics2D.Raycast(transform.position, transform.up, 1);
            RaycastHit2D hit3 = Physics2D.Raycast(transform.position, transform.up * -1, 1);




            matchingTiles.Add(hit2.collider.gameObject);
            matchingTiles.Add(hit3.collider.gameObject);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 1);
            matchingTiles.Add(hit.collider.gameObject);
            hit = Physics2D.Raycast(hit.collider.transform.position, transform.up, 1);
            matchingTiles.Add(hit.collider.gameObject);
            hit = Physics2D.Raycast(transform.position, transform.right, 1);
            hit = Physics2D.Raycast(hit.collider.transform.position, transform.up * -1, 1);
            matchingTiles.Add(hit.collider.gameObject);






			RaycastHit2D hit1 = Physics2D.Raycast(transform.position, transform.right * -1, 1);
			matchingTiles.Add(hit1.collider.gameObject);
			hit1 = Physics2D.Raycast(hit1.collider.transform.position, transform.up, 1);
			matchingTiles.Add(hit1.collider.gameObject);
			hit1 = Physics2D.Raycast(transform.position, transform.right * -1, 1);
			hit1 = Physics2D.Raycast(hit1.collider.transform.position, transform.up * -1, 1);
			matchingTiles.Add(hit1.collider.gameObject);

			


            for (int i = 0; i < matchingTiles.Count; i++)
			{
				matchingTiles[i].GetComponent<SpriteRenderer>().sprite = null;

			}
			render.sprite = null;
			
			StopCoroutine(BoardManager.instance.FindNullTiles());
			StartCoroutine(BoardManager.instance.FindNullTiles());


		}


		if ( item == 6)
        {
			item = 7;

			float MaxDistance = 15f;


			List<GameObject> matchingTiles = new List<GameObject>();
			RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, MaxDistance);
			RaycastHit2D hit1 = Physics2D.Raycast(transform.position, transform.right * -1, MaxDistance);
			

			for (int i = 0; i < (int)MaxDistance; i++)
			{
				while (hit.collider != null && hit.collider.GetComponent<SpriteRenderer>().sprite != render.sprite)
				{
					matchingTiles.Add(hit.collider.gameObject);
					hit = Physics2D.Raycast(hit.collider.transform.position, transform.right, MaxDistance);
				}
				while (hit.collider != null && hit.collider.GetComponent<SpriteRenderer>().sprite == render.sprite)
				{
					matchingTiles.Add(hit.collider.gameObject);
					hit = Physics2D.Raycast(hit.collider.transform.position, transform.right, MaxDistance);
				}
				while (hit1.collider != null && hit1.collider.GetComponent<SpriteRenderer>().sprite != render.sprite)
				{
					matchingTiles.Add(hit1.collider.gameObject);
					hit1 = Physics2D.Raycast(hit1.collider.transform.position, transform.right * -1, MaxDistance);
				}
				while (hit1.collider != null && hit1.collider.GetComponent<SpriteRenderer>().sprite == render.sprite)
				{
					matchingTiles.Add(hit1.collider.gameObject);
					hit1 = Physics2D.Raycast(hit1.collider.transform.position, transform.right * -1, MaxDistance);
				}
				
				
			}

			for (int i = 0; i < matchingTiles.Count; i++)
			{
				matchingTiles[i].GetComponent<SpriteRenderer>().sprite = null;

			}
			render.sprite = null;
			
			StopCoroutine(BoardManager.instance.FindNullTiles());
			StartCoroutine(BoardManager.instance.FindNullTiles());




		}
		if (item == 7)
		{
			item = 1;
			float MaxDistance = 15f;


			List<GameObject> matchingTiles = new List<GameObject>();
			
			RaycastHit2D hit2 = Physics2D.Raycast(transform.position, transform.up, MaxDistance);
			RaycastHit2D hit3 = Physics2D.Raycast(transform.position, transform.up * -1, MaxDistance);

			for (int i = 0; i < 13; i++)
			{
				
				while (hit2.collider != null && hit2.collider.GetComponent<SpriteRenderer>().sprite != render.sprite)
				{
					matchingTiles.Add(hit2.collider.gameObject);
					hit2 = Physics2D.Raycast(hit2.collider.transform.position, transform.up, MaxDistance);
				}
				while (hit2.collider != null && hit2.collider.GetComponent<SpriteRenderer>().sprite == render.sprite)
				{
					matchingTiles.Add(hit2.collider.gameObject);
					hit2 = Physics2D.Raycast(hit2.collider.transform.position, transform.up, MaxDistance);
				}
				while (hit3.collider != null && hit3.collider.GetComponent<SpriteRenderer>().sprite != render.sprite)
				{
					matchingTiles.Add(hit3.collider.gameObject);
					hit3 = Physics2D.Raycast(hit3.collider.transform.position, transform.up * -1, MaxDistance);
				}
				while (hit3.collider != null && hit3.collider.GetComponent<SpriteRenderer>().sprite == render.sprite)
				{
					matchingTiles.Add(hit3.collider.gameObject);
					hit3 = Physics2D.Raycast(hit3.collider.transform.position, transform.up * -1, MaxDistance);
				}
			}

			for (int i = 0; i < matchingTiles.Count; i++)
			{
				matchingTiles[i].GetComponent<SpriteRenderer>().sprite = null;

			}
			render.sprite = null;
			
			StopCoroutine(BoardManager.instance.FindNullTiles());
			StartCoroutine(BoardManager.instance.FindNullTiles());
		}

		if (render.sprite == null /*|| BoardManager.instance.IsShifting*/) 
		{
			return;
		}

		if (isSelected)
		{ 
			Deselect();
		} else {
			if (previousSelected == null) { 
				Select();
			} else {
				if (GetAllAdjacentTiles().Contains(previousSelected.gameObject)) { 
					SwapSprite(previousSelected.render);
					previousSelected.ClearAllMatches();
					previousSelected.Deselect();
					ClearAllMatches();
						
				} else {
					previousSelected.GetComponent<Tile>().Deselect();
					Select();
				}
			}
		}
	}

	public void SwapSprite(SpriteRenderer render2) 
	{
		if (render.sprite == render2.sprite) {
			return;
		}

		Sprite tempSprite = render2.sprite;
		render2.sprite = render.sprite;
		render.sprite = tempSprite;
		SFXManager.instance.PlaySFX(Clip.Swap);
		//GUIManager.instance.MoveCounter--; 
	}

	private GameObject GetAdjacent(Vector2 castDir)
	{
		RaycastHit2D hit = Physics2D.Raycast(transform.position, castDir);
		if (hit.collider != null) {
			return hit.collider.gameObject;
		}
		return null;
	}

	private List<GameObject> GetAllAdjacentTiles() {
		List<GameObject> adjacentTiles = new List<GameObject>();
		for (int i = 0; i < adjacentDirections.Length; i++) {
			adjacentTiles.Add(GetAdjacent(adjacentDirections[i]));
			
		}
		
		return adjacentTiles;
	}

	private List<GameObject> FindMatch(Vector2 castDir) {
		List<GameObject> matchingTiles = new List<GameObject>();
		RaycastHit2D hit = Physics2D.Raycast(transform.position, castDir);

		if (item == 1)
		{
			while (hit.collider != null && hit.collider.GetComponent<SpriteRenderer>().sprite == render.sprite)
			{
				matchingTiles.Add(hit.collider.gameObject);
				hit = Physics2D.Raycast(hit.collider.transform.position, castDir);

			}
			return matchingTiles;

		}


		return matchingTiles;

	}

	private void ClearMatch(Vector2[] paths) 
	{
		
		List<GameObject> matchingTiles = new List<GameObject>();
        for (int i = 0; i < paths.Length; i++) { matchingTiles.AddRange(FindMatch(paths[i])); }

		if (item == 1)
		{
			if (matchingTiles.Count >= 2)
			{
				for (int i = 0; i < matchingTiles.Count; i++)
				{
					matchingTiles[i].GetComponent<SpriteRenderer>().sprite = null;



				}
				matchFound = true;
			}

		}

	}
	private void ClearMatch1(Vector2[] paths)
	{
		List<GameObject> matchingTiles = new List<GameObject>();
		for (int i = 0; i < paths.Length; i++) { matchingTiles.AddRange(FindMatch(paths[i])); }
		if (matchingTiles.Count >= 2)
		{
			for (int i = 0; i < matchingTiles.Count; i++)
			{
				matchingTiles[i].GetComponent<SpriteRenderer>().sprite = null;
				
			}
			matchFound = true;
		}
	}


	private bool matchFound = false;
	public void ClearAllMatches() {
		
		if (render.sprite == null)
			return;

		ClearMatch(new Vector2[2] { Vector2.left, Vector2.right });
		ClearMatch(new Vector2[2] { Vector2.up, Vector2.down });
		if (matchFound) {
			render.sprite = null;
			matchFound = false;
			StopCoroutine(BoardManager.instance.FindNullTiles()); 
			StartCoroutine(BoardManager.instance.FindNullTiles()); 
			SFXManager.instance.PlaySFX(Clip.Clear);
			
		}
	}

}