using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu01 : MonoBehaviour
{
    [SerializeField]
    PlayerController _player;
    [SerializeField]
    Image _fadeToBlack;
    [SerializeField]
    float _delayToFadeToBlack = 0.5f;
    [SerializeField]
    float _fadeToBlackSpeed = 1f;

    private void Update()
    {
        if (GameManager.Instance.Input.Shoot.IsDown)
        {
            StartCoroutine(this.FadeToBlack());
        }
    }

    IEnumerator FadeToBlack()
    {
        while (this._fadeToBlack.color.a < 0.95f)
        {
            this._fadeToBlack.color = Color.Lerp(this._fadeToBlack.color, Color.black, Time.deltaTime * this._fadeToBlackSpeed);
            yield return new WaitForEndOfFrame();
        }
        this._fadeToBlack.color = Color.black;

        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(3);

        GameManager.Instance.StopMainMenuMusic();
        Physics2D.gravity *= -1;
    }
}
