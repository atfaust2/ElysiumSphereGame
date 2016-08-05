
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour {

	public void LoadScene(int level) {

		SceneManager.LoadScene (level);
	}

}
