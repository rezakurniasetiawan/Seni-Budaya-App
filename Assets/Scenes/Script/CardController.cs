using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class CardController : MonoBehaviour
{
    [SerializeField] Card cardPrefab;

    [SerializeField] Transform gridTransform;
    [SerializeField] Sprite[] sprites;

    [SerializeField] TextMeshProUGUI timerText;

    private List<Sprite> spritePairs;

    Card firstSelected;
    Card secondSelected;
    int matchCounts;

    private void Start()
    {
        PrepareSprites();
        CreateCards();
    }

    void Update()
    {
        Debug.Log(timerText.text);
        if (timerText.text == "05:00")
        {
            PlayerPrefs.SetString("memoryTimer", timerText.text);
            SceneManager.LoadScene("ScoreMemory");
        }
    }

    private void PrepareSprites()
    {
        spritePairs = new List<Sprite>();

        for (int i = 0; i < sprites.Length; i++)
        {
            spritePairs.Add(sprites[i]);
            spritePairs.Add(sprites[i]);
        }

        Debug.Log(sprites.Length);

        ShuffleSprites(spritePairs);
    }


    private void CreateCards()
    {
        for (int i = 0; i < spritePairs.Count; i++)
        {
            Card card = Instantiate(cardPrefab, gridTransform);
            card.SetIconSprite(spritePairs[i]);
            card.controller = this;
        }
    }

    public void SetSelected(Card card)
    {
        if (card.isSelected == false)
        {
            card.Show();

            if (firstSelected == null)
            {
                Debug.Log("First Selected");
                firstSelected = card;
                return;
            }

            if (secondSelected == null)
            {

                Debug.Log("Second Selected");
                secondSelected = card;
                StartCoroutine(CheckMathching(firstSelected, secondSelected));
                firstSelected = null;
                secondSelected = null;
            }

        }
    }

    IEnumerator CheckMathching(Card a, Card b)
    {
        yield return new WaitForSeconds(0.3f);
        if (a.IconSprite == b.IconSprite)
        {
            matchCounts++;
            if (matchCounts == spritePairs.Count / 2)
            {
                PrimeTween.Sequence.Create()
                    .Chain(PrimeTween.Tween.Scale(gridTransform, Vector3.one * 1.2f, 0.2f, ease: PrimeTween.Ease.OutBack))
                    .Chain(PrimeTween.Tween.Scale(gridTransform, Vector3.one, 0.1f));

                yield return new WaitForSeconds(2f);

                // navigate to score scene
                SceneManager.LoadScene("ScoreMemory");
            }

            PlayerPrefs.SetFloat("memorySkor", PlayerPrefs.GetFloat("memorySkor") + 16.6667f);
            PlayerPrefs.SetString("memoryTimer", timerText.text);

            Debug.Log(PlayerPrefs.GetFloat("memorySkor"));
        }
        else
        {
            a.Hide();
            b.Hide();

            Debug.Log("Not Match");
        }
    }

    void ShuffleSprites(List<Sprite> spriteList)
    {
        for (int i = spriteList.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            Sprite temp = spriteList[i];
            spriteList[i] = spriteList[randomIndex];
            spriteList[randomIndex] = temp;

            Debug.Log(spriteList[i]);
        }
    }
}
