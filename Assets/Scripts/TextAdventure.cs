using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TextAdventure : MonoBehaviour
{
    private enum States
    {
        //Main
        Start,
        K1,
        K2,
        K2A,
        K2B1,
        K2AA,
        K2B2,
        reset,
        win,

        //Credits
        FirstCredit,
        SecondCredit,

        //MonicaStoryline
        m1,
        m2,
        m3,
        m4,
        m4a1,

        //m4a2,
        m4b1,
        m4b2,
        m4b2a1,
        m4b2b1,
        m4b2c1,
        m4b2c2,
        m4b2c3,
        m4b2c4,
        m4b2c5,
        m4b2c6,
        m4b2c6a1,
        m4b2c6b1,
        m4b2c6b1a1,
        m4b2c6b1a2,
        m4b2c6b1a3,
        m4b2c6b1a4,
        m4b2c6b1a5,
        m4b2c6b1a5a1,

        //m4b2c6b1a5a2,
        m4b2c6b1a5b1,
        m4b2c6b1a5b2,
        m4b2c6b1a5b3,
        m4b2c6b1a5b4,

        //NatsukiStoyline
        n1,
        n2,
        n3,
        n4,
        n5,
        n6,
        n6a1,
        n6b1,
        n6b2,
        n6b3,
        n6b4,
        n6b5,
        n6b6,
        n6b7,
        n6b7a1,

        ///n6b7a2,
        n6b7b1,
        n6b7b2,
        n6b7b3,
        n6b7b4,
        n6b7b5,
        n6b7b6,
        n6b7b7,
        n6b7b8,

        //n6b7b8a1,
        n6b7b8b1,
        n6b7b8b2,
        n6b7b8b3,
    }

    private States currentState = States.Start; //Keeps track of the current state

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void OnUserInput(string input)
    {
        switch (currentState)
        {
            case States.Start:
                if (input.ToLower() == "start")
                {
                    K1();
                }

                break;
            case States.K2:
                if (input.ToLower() == "ja")
                {
                    K2A();
                }
                else if (input.ToLower() == "nee")
                {
                    K2B1();
                }

                break;
            case States.K2A:
                if (input.ToLower() == "attack on titan")
                {
                    K2AA();
                }

                if (input.ToLower() == "helsing")
                {
                    n1();
                }

                break;

            //monica
            case States.m4:
                if (input.ToLower() == "weerwolven")
                {
                    m4b1();
                }
                else if (input.ToLower() == "slapen")
                {
                    m4a1();
                }

                break;
            case States.m4b2:
                if (input.ToLower() == "weerwolf")
                {
                    m4b2a1();
                }
                else if (input.ToLower() == "jager")
                {
                    m4b2b1();
                }
                else if (input.ToLower() == "burger")
                {
                    m4b2c1();
                }

                break;
            case States.m4b2c6:
                if (input.ToLower() == "nee")
                {
                    m4b2c6a1();
                }
                else if (input.ToLower() == "ja")
                {
                    m4b2c6b1();
                }

                break;
            case States.m4b2c6b1a5:
                if (input.ToLower() == "verliezen")
                {
                    m4b2c6b1a5a1();
                }
                else if (input.ToLower() == "winnen")
                {
                    m4b2c6b1a5b1();
                }

                break;
            //Natsuki
            case States.n6:
                if (input.ToLower() == "worst")
                {
                    n6a1();
                }
                else if (input.ToLower() == "hamburger")
                {
                    n6b1();
                }

                break;
            case States.n6b7:
                if (input.ToLower() == "raft")
                {
                    n6b7a1();
                }
                else if (input.ToLower() == "kano")
                {
                    n6b7b1();
                }

                break;
            case States.n6b7b8:
                if (input.ToLower() == "attack on titan")
                {
                    n6b7b8a1();
                }
                else if (input.ToLower() == "helsing")
                {
                    n6b7b8b1();
                }

                break;
            default:
                Terminal.WriteLine("YOU BROKE THE GAME!!!!!");
                Terminal.WriteLine("Now i will have to fix it.");
                Terminal.WriteLine("Tnx dude.");
                break;
        }
    }

    void Spacebar()
    {
        if (currentState == States.K1 && Input.GetKeyDown(KeyCode.Space))
        {
            K2();
        }
        else if (currentState == States.K2AA && Input.GetKeyDown(KeyCode.Space))
        {
            m1();
        }
        else if (currentState == States.K2B1 && Input.GetKeyDown(KeyCode.Space))
        {
            K2B2();
        }
        else if (currentState == States.K2B2 && Input.GetKeyDown(KeyCode.Space))
        {
            m1();
        }
        else if (currentState == States.n6b7b8b3 && Input.GetKeyDown(KeyCode.Space))
        {
            win();
        }
        else if (currentState == States.m4b2c6b1a5b4 && Input.GetKeyDown(KeyCode.Space))
        {
            win();
        }
        else if (currentState == States.win && Input.GetKeyDown(KeyCode.Space))
        {
            FirstCredit();
        }
        else if (currentState == States.FirstCredit && Input.GetKeyDown(KeyCode.Space))
        {
            SecondCredit();
        }
        else if (currentState == States.SecondCredit && Input.GetKeyDown(KeyCode.Space))
        {
            ShowMainMenu();
        }
        else if (currentState == States.reset && Input.GetKeyDown(KeyCode.Space))
        {
            K1();
        }
    }

    void SpacebarMonica()
    {
        if (currentState == States.m1 && Input.GetKeyDown(KeyCode.Space))
        {
            m2();
        }
        else if (currentState == States.m2 && Input.GetKeyDown(KeyCode.Space))
        {
            m3();
        }
        else if (currentState == States.m3 && Input.GetKeyDown(KeyCode.Space))
        {
            m4();
        }

        else if (currentState == States.m4a1 && Input.GetKeyDown(KeyCode.Space))
        {
            m4a2();
        }

        else if (currentState == States.m4b1 && Input.GetKeyDown(KeyCode.Space))
        {
            m4b2();
        }

        else if (currentState == States.m4b2a1 && Input.GetKeyDown(KeyCode.Space))
        {
            m4b2c2();
        }

        else if (currentState == States.m4b2b1 && Input.GetKeyDown(KeyCode.Space))
        {
            m4b2c2();
        }

        else if (currentState == States.m4b2c1 && Input.GetKeyDown(KeyCode.Space))
        {
            m4b2c2();
        }

        else if (currentState == States.m4b2c2 && Input.GetKeyDown(KeyCode.Space))
        {
            m4b2c3();
        }

        else if (currentState == States.m4b2c3 && Input.GetKeyDown(KeyCode.Space))
        {
            m4b2c4();
        }

        else if (currentState == States.m4b2c4 && Input.GetKeyDown(KeyCode.Space))
        {
            m4b2c5();
        }

        else if (currentState == States.m4b2c5 && Input.GetKeyDown(KeyCode.Space))
        {
            m4b2c6();
        }

        else if (currentState == States.m4b2c6a1 && Input.GetKeyDown(KeyCode.Space))
        {
            m4b2c6b1a1();
        }

        else if (currentState == States.m4b2c6b1 && Input.GetKeyDown(KeyCode.Space))
        {
            m4b2c6b1a1();
        }

        else if (currentState == States.m4b2c6b1a1 && Input.GetKeyDown(KeyCode.Space))
        {
            m4b2c6b1a2();
        }

        else if (currentState == States.m4b2c6b1a2 && Input.GetKeyDown(KeyCode.Space))
        {
            m4b2c6b1a3();
        }

        else if (currentState == States.m4b2c6b1a3 && Input.GetKeyDown(KeyCode.Space))
        {
            m4b2c6b1a4();
        }

        else if (currentState == States.m4b2c6b1a4 && Input.GetKeyDown(KeyCode.Space))
        {
            m4b2c6b1a5();
        }

        else if (currentState == States.m4b2c6b1a5a1 && Input.GetKeyDown(KeyCode.Space))
        {
            m4b2c6b1a5a2();
        }

        else if (currentState == States.m4b2c6b1a5b1 && Input.GetKeyDown(KeyCode.Space))
        {
            m4b2c6b1a5b2();
        }

        else if (currentState == States.m4b2c6b1a5b2 && Input.GetKeyDown(KeyCode.Space))
        {
            m4b2c6b1a5b3();
        }

        else if (currentState == States.m4b2c6b1a5b3 && Input.GetKeyDown(KeyCode.Space))
        {
            m4b2c6b1a5b4();
        }
    }

    void SpacebarNatsuki()
    {
        if (currentState == States.n1 && Input.GetKeyDown(KeyCode.Space))
        {
            n2();
        }

        else if (currentState == States.n2 && Input.GetKeyDown(KeyCode.Space))
        {
            n3();
        }

        else if (currentState == States.n3 && Input.GetKeyDown(KeyCode.Space))
        {
            n4();
        }

        else if (currentState == States.n4 && Input.GetKeyDown(KeyCode.Space))
        {

            n5();
        }

        else if (currentState == States.n5 && Input.GetKeyDown(KeyCode.Space))
        {
            n6();
        }

        else if (currentState == States.n6a1 && Input.GetKeyDown(KeyCode.Space))
        {
            n6a2();
        }

        else if (currentState == States.n6b1 && Input.GetKeyDown(KeyCode.Space))
        {
            n6b2();
        }

        else if (currentState == States.n6b2 && Input.GetKeyDown(KeyCode.Space))
        {
            n6b3();
        }

        else if (currentState == States.n6b3 && Input.GetKeyDown(KeyCode.Space))
        {
            n6b4();
        }

        else if (currentState == States.n6b4 && Input.GetKeyDown(KeyCode.Space))
        {
            n6b5();
        }

        else if (currentState == States.n6b5 && Input.GetKeyDown(KeyCode.Space))
        {
            n6b6();
        }

        else if (currentState == States.n6b6 && Input.GetKeyDown(KeyCode.Space))
        {
            n6b7();
        }

        else if (currentState == States.n6b7a1 && Input.GetKeyDown(KeyCode.Space))
        {
            n6b7a2();
        }

        else if (currentState == States.n6b7b1 && Input.GetKeyDown(KeyCode.Space))
        {
            n6b7b2();
        }

        else if (currentState == States.n6b7b2 && Input.GetKeyDown(KeyCode.Space))
        {
            n6b7b3();
        }

        else if (currentState == States.n6b7b3 && Input.GetKeyDown(KeyCode.Space))
        {
            n6b7b4();
        }

        else if (currentState == States.n6b7b4 && Input.GetKeyDown(KeyCode.Space))
        {
            n6b7b5();
        }

        else if (currentState == States.n6b7b5 && Input.GetKeyDown(KeyCode.Space))
        {
            n6b7b6();
        }

        else if (currentState == States.n6b7b6 && Input.GetKeyDown(KeyCode.Space))
        {
            n6b7b7();
        }

        else if (currentState == States.n6b7b7 && Input.GetKeyDown(KeyCode.Space))
        {
            n6b7b8();
        }

        else if (currentState == States.n6b7b8b1 && Input.GetKeyDown(KeyCode.Space))
        {
            n6b7b8b2();
        }

        else if (currentState == States.n6b7b8b2 && Input.GetKeyDown(KeyCode.Space))
        {
            n6b7b8b3();
        }
    }

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Welkom Bij Doki Doki IT Camp.");
        Terminal.WriteLine("Type START om te beginnen.");
    }

    void K1()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Het is de dag van het kamp.");
        Terminal.WriteLine("Je zit in de trein naast je klasgenoot Natsuki.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te");
        Terminal.WriteLine("gaan.");
        currentState = States.K1;
    }

    void K2()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Natsuki: Lees je manga?");  
        Terminal.WriteLine("");
        Terminal.WriteLine("Type JA of NEE om antwoord te geven");
        currentState = States.K2;
//      Terminal.EmptyLine();
    }

    void K2A()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Natsuki bewonderd je.");
        Terminal.WriteLine("Natsuki; Wat is je favorite manga,");
        Terminal.WriteLine("Attack on titan of Helsing?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Type ATTACK ON TITAN of HELSING");
        Terminal.WriteLine("om andwoord te geven.");
        currentState = States.K2A;
    }

    void K2AA()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Natsuki vind je mening slecht maar accepteert het");
        Terminal.WriteLine("Monica: Ik heb van Attack on titan gehoord. Het is een leuk verhaal.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op SPATIEBALK om verder te gaan.");
        currentState = States.K2AA;
    }

    void K2B1()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Natsuki: Idiot!");
        Terminal.WriteLine("Natsuki staat op en loopt weg");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te");
        Terminal.WriteLine("gaan.");                
        currentState = States.K2B1;
    }

    void K2B2()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Monica komt naast je zitten.");
        Terminal.WriteLine("Monica: Negeer haar maar ze is gewoon geirriteerd als iemand geen manga leest."); //fix geirriteerd... leest.
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te");
        Terminal.WriteLine("gaan.");            
        currentState = States.K2B2;
    }

    // dit is de dood van Natsuki en monika

    void win()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Gefeliciteerd je heb het kamp overleeft!");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te");
        Terminal.WriteLine("gaan.");            
        currentState = States.win;
    }

    //credits
    void FirstCredit()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Storyline geschreven door:");
        Terminal.WriteLine("Dylan van Ginhoven");
        Terminal.WriteLine("Rick van der Kleij");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om de ");
        Terminal.WriteLine("volgende credits pagina te zien.");
        currentState = States.FirstCredit;
    }

    void SecondCredit()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Natsuki-Storyline gemaakt door:");
        Terminal.WriteLine("Rick van der Kleij");
        Terminal.WriteLine("");
        Terminal.WriteLine("Monika-Storyline gemaakt door:");
        Terminal.WriteLine("Roy van de Lubbe");
        Terminal.WriteLine("");
        Terminal.WriteLine("Credits door:");
        Terminal.WriteLine("Marco van Doeland");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om terug ");
        Terminal.WriteLine("te gaan naar het Startscherm");
        currentState = States.SecondCredit;
    }

    //MonicaStoryline
    void m1()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je loopt samen met Monika naar het huis.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te");
        Terminal.WriteLine("gaan.");
        currentState = States.m1;
    }

    void m2()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je komt aan bij het huis.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te");
        Terminal.WriteLine("gaan.");
        currentState = States.m2;
    }

    void m3()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je maakt je bed op.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te");
        Terminal.WriteLine("gaan.");
        currentState = States.m3;
    }

    void m4()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Na het eten kan je het weerwolven");
        Terminal.WriteLine("spel spelen of gaan slapen.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Type WEERWOLVEN om het te spelen.");
        Terminal.WriteLine("Type SLAPEN om te gaan slapen.");
        currentState = States.m4;
    }

    void m4a1()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je gaat slapen.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te");
        Terminal.WriteLine("gaan.");
        currentState = States.m4a1;
    }

    void m4a2()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je wordt in je slaap opgegeten");
        Terminal.WriteLine("door een weerwolf.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om terug te gaan.");
        currentState = States.reset;
    }

    void m4b1()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je gaat het weerwolven spel spelen.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te");
        Terminal.WriteLine("gaan.");
        currentState = States.m4b1;
    }

    void m4b2()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je krijgt de bandiet kaart.");
        Terminal.WriteLine("Wil je de weerwolf, jager of burger ");
        Terminal.WriteLine("kaart.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Type WEERWOLF voor weerwolf.");
        Terminal.WriteLine("Type JAGER voor jager.");
        Terminal.WriteLine("Type BURGER voor Burger.");
        currentState = States.m4b2;
    }

    void m4b2a1()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je bent een weerwolf.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Je wordt vermoord door een jager.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Weerwolven verliezen.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te");
        Terminal.WriteLine("gaan.");
        currentState = States.m4b2a1;
    }

    void m4b2b1()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je bent een jager.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Je wordt vermoord door een weerwolf.");
        Terminal.WriteLine("");
        Terminal.WriteLine("De Town wint dus jij wint ook.");    
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te");
        Terminal.WriteLine("gaan.");
        currentState = States.m4b2b1;
    }

    void m4b2c1()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je bent een burger.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Je wint.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te");
        Terminal.WriteLine("gaan.");
        currentState = States.m4b2c1;
    }

    void m4b2c2()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je bent moe en gaat met Monika slapen");
        Terminal.WriteLine(" in je kamer.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te");
        Terminal.WriteLine("gaan.");
        currentState = States.m4b2c2;
    }

    void m4b2c3()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je wordt wakker door het geklop aan");
        Terminal.WriteLine("de deur.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te");
        Terminal.WriteLine("gaan.");
        currentState = States.m4b2c3;
    }

    void m4b2c4()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je gaat onbijten en maakt je lunch voor later vandaag");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te");
        Terminal.WriteLine("gaan.");
        currentState = States.m4b2c4;
    }

    void m4b2c5()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je fietst samen met Monika naar de rafts toe");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te");
        Terminal.WriteLine("gaan.");
        currentState = States.m4b2c5;
    }

    void m4b2c6()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Mag Yuri mee in de raft?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Type NEE ze mag niet mee als ze niet mee mag");
        Terminal.WriteLine("Type JA ze mag meer als ze wel mee mag");
        currentState = States.m4b2c6;
    }

    void m4b2c6a1()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("De docenten forceren dat ze in jullie raft komt.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te");
        Terminal.WriteLine("gaan.");
        currentState = States.m4b2c6a1;
    }

    void m4b2c6b1()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Jullie gaan raften.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te");
        Terminal.WriteLine("gaan.");
        currentState = States.m4b2c6b1;
    }

    void m4b2c6b1a1()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je komt veel later aan dan de rest. van de groep.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te");
        Terminal.WriteLine("gaan.");
        currentState = States.m4b2c6b1a1;
    }

    void m4b2c6b1a2()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Jij en Monika gaan jullie broodjes eten.");
        Terminal.WriteLine("Daarna gaan julie terug naar het huis.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.m4b2c6b1a2;
    }

    void m4b2c6b1a3()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je gaat chinees eten.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.m4b2c6b1a3;
    }

    void m4b2c6b1a4()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je gaat naar je kamer met Monika.");
        Terminal.WriteLine("Om te mario karten.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.m4b2c6b1a4;
    }

    void m4b2c6b1a5()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Ga je winnen of expres verliezen.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Type WINNEN om te proberen te winnen.");
        Terminal.WriteLine("Type VERLIEZEN om expres te verliezen.");
        currentState = States.m4b2c6b1a5;
    }

    void m4b2c6b1a5a1()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("je Verliest.");
        Terminal.WriteLine("Maar Monika merkt dat je het expres doet en loopt boos de kamer uit.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.m4b2c6b1a5a1;
    }

    void m4b2c6b1a5a2()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je slaapt nu zielig en stikt in je eigen tranen.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om terug te gaan naar de start");
        currentState = States.reset;
    }

    void m4b2c6b1a5b1()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je verliest omdat Monika blijkbaar een prof is.");
        Terminal.WriteLine("Je vraagt om nog een ronde maar kan nooit winnen.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.m4b2c6b1a5b1;
    }

    void m4b2c6b1a5b2()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Jullie vallen na uren mario karten in slaap.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.m4b2c6b1a5b2;
    }

    void m4b2c6b1a5b3()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("je wordt wakker met Monika naast je.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.m4b2c6b1a5b3;
    }

    void m4b2c6b1a5b4()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Jullie gaan samen ontbijten.");
        Terminal.WriteLine("Vervolgens gaan jullie de spullen verzamenlen en naar huis.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.m4b2c6b1a5b4;
    }

    //NatsukiStoryline
    void n1()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Natsuki vind je mening geweldig");
        Terminal.WriteLine("En is het er mee eens.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.n1;
    }

    void n2()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je discussieerd over de manga");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.n2;
    }

    void n3()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je loopt samen met natsuki");
        Terminal.WriteLine("Naar het huis toe.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.n3;
    }

    void n4()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je komt aan bij het huis.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.n4;
    }

    void n5()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je maakt je bed op.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.n5;
    }

    void n6()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Wat ga je eten?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Type HAMBURGER om een hamburger te eten");
        Terminal.WriteLine("Type WORST om een worst te eten");
        currentState = States.n6;
    }

    void n6a1()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je eet de worst in een keer op.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.n6a1;
    }

    void n6a2()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je stikt in je worst.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Je bent dood gegaan type RESET om terug tegaan.");
        currentState = States.reset;
    }

    void n6b1()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Er zit veel te veel vet in de burger.");
        Terminal.WriteLine("Waardoor je last van je maag krijgt.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Je deelt een stuk met Natsuki.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.n6b1;
    }

    void n6b2()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Na het eten ga je met Natsuki op de gang");
        Terminal.WriteLine("praten in de gang. Daarna worden jullie");
        Terminal.WriteLine("naar je kamer gestuurd.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.n6b2;
    }

    void n6b3()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je valt in slaap met Natsuki naast je.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.n6b3;
    }

    void n6b4()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Jullie worden wakker door het geklop.");
        Terminal.WriteLine("Maar gaan weer slapen.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.n6b4;
    }

    void n6b5()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Jullie worden wakker maar telaat om");
        Terminal.WriteLine("te onbijten. Of lunch te maken.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.n6b5;
    }

    void n6b6()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je fietst samen Natsuki naar de rafts toe.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.n6b6;
    }

    void n6b7()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Ga je met een raft met 4 personen.");
        Terminal.WriteLine("Of ga je met de kano met Natsuki.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Type RAFT om met de raft te gaan");
        Terminal.WriteLine("Type KANO om met de kano te gaan");
        currentState = States.n6b7;
    }

    void n6b7a1()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je gaat met Natsuki Monika en Yuri raften.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.n6b7a1;
    }

    void n6b7a2()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Yuri probeert haar zelf neer te steken.");
        Terminal.WriteLine("En steekt in plaats daar van de boot lek.");
        Terminal.WriteLine("Helaas kan je niet zwemmen en verdrink je.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.reset;
    }

    void n6b7b1()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je gaat kanoën");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.n6b7b1;
    }

    void n6b7b2()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je komt veel eerder aan dan de rest van de groep.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.n6b7b2;
    }

    void n6b7b3()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je gaat met Natsuki naar de macdonalds.");
        Terminal.WriteLine("Jij betaald het eten en bend nu blut.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.n6b7b3;
    }

    void n6b7b4()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Jullie gaan terug naar het huis.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.n6b7b4;
    }

    void n6b7b5()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("jullie gaan chinees eten.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.n6b7b5;
    }

    void n6b7b6()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Jullie gaan kaarten.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.n6b7b6;
    }

    void n6b7b7()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je gaat samen met Natsuki manga lezen.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.n6b7b7;
    }

    void n6b7b8()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Welke manga ga je lezen.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Type ATTACK ON TITAN om die te lezen.");
        Terminal.WriteLine("Type HELSING om die te lezen.");
        currentState = States.n6b7b8;
    }

    void n6b7b8a1()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Natsuki loopt boos weg nu ga je huilend");
        Terminal.WriteLine("slapen.");
        Terminal.WriteLine("Je stikt in je eigen tranen.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om terug te gaan");
        Terminal.WriteLine("naar de start.");
        currentState = States.reset;
    }

    void n6b7b8b1()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Jullie lezn de manga en vallen in slaap.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.n6b7b8b1;
    }

    void n6b7b8b2()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je wordt wakker met Natsuki naast je.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.n6b7b8b2;
    }

    void n6b7b8b3()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Jullie gaan samen ontbijten.");
        Terminal.WriteLine("Vervolgens gaan jullie je spullen pakken.");
        Terminal.WriteLine("En naar huis");
        Terminal.WriteLine("");
        Terminal.WriteLine("Druk op de SPATIEBALK om verder te gaan.");
        currentState = States.n6b7b8b3;
        // To win();
    }

    // Update is called once per frame
    void Update()
    {
        print(currentState);
        Spacebar();
        SpacebarMonica();
        SpacebarNatsuki();

    }
}