using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameBrain : MonoBehaviour {


	// används för att räkna pellets och spara dess information
	GameObject[] pellets;
	int[][] allDeadPellets = new int[30][] ;
	int currentLevel;
	bool dontLoad = true;
	string[] scores;
	public int[][] pelletscore = new int[3][];
	int ones;
	int tens;

	// används för liv och armour
	int lives;
	public int lastLevel;
	public bool armoured;

	void Awake () {

		DontDestroyOnLoad (this);

		lives = 3;
		armoured = false;

		if (FindObjectsOfType(GetType()).Length > 1) // singleton pattern. Ser till att det bara finns ett sådant gameobject.
		{
			Destroy(gameObject);
			dontLoad = false;
		}

		// gär så att varje plats i array får 30 platser var. allt som allt fins 30x30 platser
		else for (int i = 0; i < allDeadPellets.Length; i++) {
				allDeadPellets [i] = new int[30]; // 31 platser eftersom första pellet försvinner pga att den har platsen [i][0]
				for (int j = 0; j < allDeadPellets.Length; j++) {
					allDeadPellets [i] [j] = -1;
				}
			}


		for (int i = 0; i < pelletscore.Length; i++) {
			pelletscore [i] = new int[10];
		}
	}


	// Jämför de pellets som är utlagda och stänger av dem när leveln laddas
	//på de platser som finns i listan med inaktiverade pellets.
	void OnLevelWasLoaded (int level) 
	{
		if (dontLoad) {           // Checks if it's a duplicated object or not, is it duplicated this does not run.


			pellets = GameObject.FindGameObjectsWithTag ("pellet");

			int epokScore = 0;

			currentLevel = level - 1; // eftersom det finns ett antal scener innan själva leveln tar vi -4
			ones = currentLevel % 10;
			tens = (currentLevel % 100 - ones)/10;


			for (int i = 0; i < pellets.Length; i++) {
				for (int j = 0; j < allDeadPellets.Length; j++) {
					if (allDeadPellets [currentLevel][j] == i) { //allDeadPellets[currentlevel] innan

						pellets [i].gameObject.SetActive (false);

					}
				}
			}

			if (level == 0) {
				for (int i = 0; i < pelletscore.Length; i++) {

					for (int j = 0; j < pelletscore [i].Length; j++) {

						if (((j - 9) % 10 != 0))
						{
							epokScore += pelletscore [i] [j];
						}



						if (((j - 9) % 10) == 0 && epokScore > pelletscore[i][j]){

							pelletscore [i] [j] = epokScore;
							epokScore = 0;
						}
					}
				}
			}
		}
	}



	// Skapar en lista med inaktiverade pellets samt har koll på hur många pellets
	//som tagits (för poängräkning). Åkallas från OnCollisionScript när man går ut ur en level.
	public void SetDeadPellet () 
	{

		int recentScore = 0;

		for (int i = 0; i < pellets.Length; i++) {

			if (pellets [i].gameObject.activeSelf == false) 
			{
				recentScore += 1;
				allDeadPellets [currentLevel] [i] = i;
			}
		}

		//gör att pelletscore skrivs över om man fått mer poäng än man tidigare fått i banan.
		if (pelletscore [tens][ones] < recentScore) {
			pelletscore [tens][ones] = recentScore;

		}

		if (lastLevel < currentLevel + 1) {
			lastLevel = currentLevel + 1;

		}
			

		//Debug.Log("pelletscore: " + (pelletscore[tens][ones]));
		SceneManager.LoadScene ("mainroom");
	}









	// metoder för att hantera skydd- och livspoäng.
	public void GainArmour ()
	{
		armoured = true;
	}

	public void LoseArmour ()
	{
		armoured = false;
	}


	public void LoseLife ()
	{
		lives--;
		if (lives <= 0)
		{
			Destroy(gameObject);
		}
	}


	public void GainLife ()
	{
		if (lives < 6) {
			lives++;
		}
	}
}
