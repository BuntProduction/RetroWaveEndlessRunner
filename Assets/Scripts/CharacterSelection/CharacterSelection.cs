using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CharacterSelection : MonoBehaviour
{

    private GameObject[] characterList;
    private int index;

    public CarBlueprint[] cars;
    public Button buyButton;
    public Button confirmButton;
    public Button errorButton;
    public Text totalCoins;
    
    //Text text;

    private void Start()
    {
        foreach(CarBlueprint car in cars)
        {
            if (car.price == 0)
                car.isUnlocked = true;
            else
                car.isUnlocked = PlayerPrefs.GetInt(car.name, 0)==0 ? false: true; //for the 0 value --> difficult
        }


        index = PlayerPrefs.GetInt("CharacterSelected", 0);
        
        characterList = new GameObject[transform.childCount]; //childcount = to count how many models there are.

        //Fill the array with our models
        for(int i = 0; i < transform.childCount; i++)
            characterList[i] = transform.GetChild(i).gameObject;
        
        //we toggle of their renderer
        foreach(GameObject go in characterList)
            go.SetActive(false);//we could just set the first character inactive but this to have more than 2 characters

        //we toggle on the selected character
        if (characterList[index])
            characterList[index].SetActive(true);
        
    }
    
    void Update()
    {
        UpdateUI();
        totalCoins.text = "Total Coins: " + PlayerPrefs.GetInt("Coins");

        //ToggleLeft(); this is the origin of the animation bug
        //ToggleRight();

    }
    public void ToggleLeft()
    {
        // toggle off the current model
        characterList[index].SetActive(false);

        index--;
        if (index < 0)
            index = characterList.Length - 1; // to take the last character of the index if we were on the first character of the index

        
        // toggle on the current model
        characterList[index].SetActive(true);

        CarBlueprint c = cars[index];
        if (c.isUnlocked)
            return;

    }

    public void ToggleRight()
    {
        // toggle off the current model
        characterList[index].SetActive(false);

        index++;
        if (index == characterList.Length)
            index = 0; // to take the first character of the index if we were on the last character of the index

        
        // toggle on the current model
        characterList[index].SetActive(true);

        CarBlueprint c = cars[index];
        if (c.isUnlocked)
            return;

    }

    public void ConfirmButton()
    {
   
        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene("Level");
        
    }

    public void ErrorSound()
    {
        
    } 

    public void UnlockCar()
    {
        CarBlueprint c = cars[index];

        PlayerPrefs.SetInt(c.name, 1);
        PlayerPrefs.SetInt("CharacterSelected", index);
        c.isUnlocked = true;
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins", 0) - c.price);
    }

    private void UpdateUI()
    {
        CarBlueprint c = cars[index];
        if (c.isUnlocked) //c is just a random name
        {
            confirmButton.gameObject.SetActive(true);

            buyButton.gameObject.SetActive(false);

            errorButton.gameObject.SetActive(false);

        }
        else
        {
            confirmButton.gameObject.SetActive(false);

            buyButton.gameObject.SetActive(true);
            errorButton.gameObject.SetActive(true);

            buyButton.GetComponentInChildren<Text>().text = "Buy-" + c.price;
            if(c.price < PlayerPrefs.GetInt("Coins", 0))
            {
                buyButton.interactable = true;
                errorButton.gameObject.SetActive(false);

            }
            else
            {
                buyButton.interactable = false;
                errorButton.interactable = true;

            }
        }

    }
    
}
