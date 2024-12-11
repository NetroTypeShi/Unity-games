using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class comportamientos : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject greenImage;
    public GameObject redImage;
    // Efecto verde y rojo al acertar o fallar

    [SerializeField] TMP_Text frameTime;
    [SerializeField] TMP_Text referenceNumber;
    [SerializeField] TMP_Text scoreCounter;
    [SerializeField] TMP_Text recordCounter;
    [SerializeField] TMP_Text startupScreen;
    //Instrucción de Texto

    [SerializeField] float timeCounter = 0;
    [SerializeField] float timeLimiter = 1;
    [SerializeField] int showNumber = 0;
    [SerializeField] int randomNumber = 0;
    [SerializeField] int score = 0;
    [SerializeField] int highScore = 0;
    bool gameison = false;
    //Para que aparezcan las ranuras y que existan las variables

    void Start()
    {
        randomNumber = Random.Range(1, 15);
        gameison = false;
        greenImage.SetActive(false);
        redImage.SetActive(false);
        startupScreen.text = "PRESS A TO PLAY";
    }

    // Update is called once per frame
    void Update()
    {
        if (gameison == true)
        {
            referenceNumber.text = randomNumber.ToString();
            time();
            //tiempo

            print("time counter =" + timeCounter);
            //Referencia de frames en consola 

            restartGame();
            // Reiniciar al llegar a 14 o si te pasas

            stopInthenumber();
            //Interactuar con el número

            setRecord();
        }
        if (gameison == false)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                gameison = true;
                startupScreen.text = " ";
                scoreCounter.text = "SCORE = " + score.ToString();
                recordCounter.text = "HIGHSCORE = " + highScore.ToString();
            }
        }

    }
    void time()
    {
        timeCounter = timeCounter + Time.deltaTime;
        //Contar tiempo

        if (timeCounter >= timeLimiter)
        //(Si el contador es igual al limitador)
        {
            showNumber = showNumber + 1;
            // Cambiar el número a aparecer

            frameTime.text = showNumber.ToString();
            //Poner Texto en ranura

            timeCounter = 0;
            //Reiniciar

        }
    }
    void restartGame()
    {
        if (showNumber > 14)
        {
            restartNumbers();
        }
        if (randomNumber < showNumber)
        {
            restartNumbers();
        }
    }
    void restartNumbers()
    {
        onRedlight();
        Invoke("offRedlight", 0.25f);
        timeLimiter = 1;
        score = 0;
        scoreCounter.text = "SCORE = " + score.ToString();
        showNumber = 0;
        randomNumber = Random.Range(1, 15);
        referenceNumber.text = randomNumber.ToString();
        //Reiniciar
    }
    void pointWon()
    {
        score = score + 1;
        scoreCounter.text = "SCORE = " + score.ToString();
        // Sumar un punto
    }
    void stopInthenumber()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (showNumber == randomNumber)
            {
                onGreenlight();
                Invoke("offGreenLight", 0.25f);
                pointWon();
                showNumber = 0;
                randomNumber = Random.Range(1, 15);
                referenceNumber.text = randomNumber.ToString();
                timeLimiter = timeLimiter - 0.1f;
                // Que aciertes en el número

            }
            else if (randomNumber > showNumber)
            {
                restartNumbers();
                // reiniciar si clickas mal
            }
        }
    }
    void setRecord()
    {
        if (score > highScore)
        {
            highScore = score;
            recordCounter.text = "HIGHSCORE = " + highScore.ToString();
        }

    }
    void onRedlight()
    {
        redImage.SetActive(true);
    }
    void onGreenlight()
    {
        greenImage.SetActive(true);
    }
    void offRedlight()
    {
        redImage.SetActive(false);
    }
    void offGreenLight()
    {
        greenImage.SetActive(false);
    }

}

