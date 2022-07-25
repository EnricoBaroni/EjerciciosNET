using System;
using System.Collections.Generic;
using System.Text;

namespace EjerciciosNET
{
    class Program
    {
        static void Main(string[] args)
        {            
            Menu();            
        }
        public static void Menu()
        {
            int opcionElegir;
            do
            {
                Console.WriteLine("Escriba numero de Programa y presione enter: ");
                Console.WriteLine(" 0: Salir");
                Console.WriteLine(" 1: CamelCase");
                Console.WriteLine(" 2: Palindromo");
                Console.WriteLine(" 3: Ejercicio Simple");
                Console.WriteLine(" 4: Tres En Raya");

                opcionElegir = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (opcionElegir)
                {
                    case 0:
                        Console.WriteLine("Saliendo del programa");
                        break;

                    case 1:
                        CamelCase();

                        break;

                    case 2:
                        Palindromo();

                        break;

                    case 3:
                        EjercicioSimple();

                        break;

                    case 4:
                        TresEnRaya();
                        //Esto no va aun la victoria ni el empate

                        //Pero tu te cree que a mi me importa
                        break;

                    default:
                        Console.WriteLine("Introduce una opcion correcta");
                        break;
                }
                if (opcionElegir != 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Presiona Enter para volver");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (opcionElegir != 0);
        }
        public static void CamelCase()
        {
            Console.WriteLine("1: CamelCase");
            Console.WriteLine(" Introduzca texto a convertir: ");
            string textoCamel = Console.ReadLine();

            string textoResultado = "";
            int longitudText = textoCamel.Length;
            int y = 0;
            int cantidadEspacios;

            for (int i = 0; i < longitudText - 1; i++)
            {
                cantidadEspacios = 0;

                for (int j = y; j < longitudText - 1; j++)
                {
                    if (textoCamel[j] == ' ')
                        cantidadEspacios += 1;
                    else
                        break;
                }

                if (y <= longitudText - 1)
                {
                    if (textoCamel[y] == ' ')
                    {
                        textoResultado += Char.ToUpper(textoCamel[y + cantidadEspacios]);
                        y += cantidadEspacios + 1;
                    }
                    else
                    {
                        if (i == 0)
                            textoResultado += Char.ToUpper(textoCamel[y]);
                        else
                            textoResultado += textoCamel[y];

                        cantidadEspacios = 0;
                        y += 1;
                    }
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Transformación CamelCase: " + textoResultado);
        }
        public static void Palindromo()
        {
            Console.WriteLine("2: Palindromo");
            Console.WriteLine(" Introduzca texto a analizar: ");
            string textoPalindromo = Console.ReadLine();

            string textoEscrito = "";
            string textoReverso = "";
            string textoResultado = "";

            for (int j = 0; j < textoPalindromo.Length; j++)
            {
                if (Char.IsWhiteSpace(textoPalindromo[j]) == false)
                    textoEscrito += textoPalindromo[j];
            }

            for (int i = textoEscrito.Length - 1; i > -1; i--)
                textoReverso += textoEscrito[i];

            if (textoEscrito == textoReverso)
                textoResultado = "El texto SI es palindromo ";
            else
                textoResultado = "El texto NO es palindromo ";

            Console.WriteLine("");
            Console.WriteLine(textoResultado);
        }
        public static void EjercicioSimple()
        {
            Console.WriteLine("3: Ejercicio Simple");
            float var1 = 12;
            float var2 = 10;
            float suma = var1 + var2;
            float resta = var1 - var2;
            float division = var1 / var2;
            float modulo = var1 % var2;

            Console.WriteLine(" Suma: " + suma + " / Resta: " + resta + " / Division: " + division + " / Modulo: " + modulo);
        }
        public static void TresEnRaya() 
        {
            Console.WriteLine("4: Tres En Raya");
            Console.WriteLine("Posiciones del tablero a elegir");
           
            string[] ValoresDisponibles = new string[] { "1","2","3","4","5","6","7","8","9"};
            int value = 0;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(ValoresDisponibles[value] + " | " + ValoresDisponibles[value + 1] + " | " + ValoresDisponibles[value + 2]);
                value += 3;
            }
            int[,] ArrayVictoria = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 1, 4, 7 },
            { 2, 5, 8 }, { 3, 6, 9 },{ 1, 5, 9 }, { 3, 5, 7 }};
            int[] ArrayPlayer1 = new int[5];
            int[] ArrayPlayer2 = new int[5];
            bool end = false;
            string valorIntroducido;
            int valorConvertido = 0;
            bool valorIntroducidoCorrecto = false;
            int contadorTurnos = 0;
            do
            {
                for (int i = 0; i < 6; i++)
                {
                    do {
                        Console.WriteLine("Jugador 1 (X) Elige casilla");
                        valorIntroducido = Console.ReadLine();
                        Console.WriteLine("");
                        if (valorIntroducido != "1" && valorIntroducido != "2" &&
                            valorIntroducido != "3" && valorIntroducido != "4" &&
                            valorIntroducido != "5" && valorIntroducido != "6" &&
                            valorIntroducido != "7" && valorIntroducido != "8" &&
                            valorIntroducido != "9")
                        {
                            Console.WriteLine("Introduce un valor válido");
                            valorIntroducidoCorrecto = false;
                        }
                        else
                        {
                            if (ValoresDisponibles[Convert.ToInt32(valorIntroducido) - 1] == "X" || ValoresDisponibles[Convert.ToInt32(valorIntroducido) - 1] == "0")
                            {
                                Console.WriteLine("Ese valor ya esta cogido");
                                valorIntroducidoCorrecto = false;
                            }
                            else
                            {
                                valorConvertido = Convert.ToInt32(valorIntroducido);
                                valorIntroducidoCorrecto = true;
                            }
                        }                         
                    } while(valorIntroducidoCorrecto == false);
                    ArrayPlayer1[i] = valorConvertido;
                    ValoresDisponibles[valorConvertido - 1] = "X";
                    value = 0;
                    contadorTurnos += 1;
                    int numerosEnRayaPlayer1 = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        Console.WriteLine(ValoresDisponibles[value] + " | " + ValoresDisponibles[value + 1] + " | " + ValoresDisponibles[value + 2]);
                        value += 3;
                    }
                    for (int j = 0; j < 8; j++)
                    {
                        numerosEnRayaPlayer1 = 0;
                        for (int k = 0; k < 3; k++)
                        {
                            for (int l = 0; l < 5; l++)
                            {
                                if (ArrayVictoria[j, k] == ArrayPlayer1[l])
                                {
                                    numerosEnRayaPlayer1 += 1;
                                    if (numerosEnRayaPlayer1 == 3)
                                    {
                                        Console.WriteLine("Victoria Player 1 (X)");
                                        end = true;
                                    }
                                }
                            }
                        }
                    }
                    if (end == true)
                    {
                        break;
                    }
                    if (contadorTurnos == 9)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Empate");
                        end = true;
                        break;
                    }                    
                    if (!end)
                    {
                        do { 
                            Console.WriteLine("Jugador 2 (0) Elige casilla");
                            valorIntroducido = Console.ReadLine();
                            Console.WriteLine("");

                            if (valorIntroducido != "1" && valorIntroducido != "2" &&
                            valorIntroducido != "3" && valorIntroducido != "4" &&
                            valorIntroducido != "5" && valorIntroducido != "6" &&
                            valorIntroducido != "7" && valorIntroducido != "8" &&
                            valorIntroducido != "9")
                            {
                                Console.WriteLine("Introduce un valor válido");
                                valorIntroducidoCorrecto = false;
                            }
                            else
                            {
                                if (ValoresDisponibles[Convert.ToInt32(valorIntroducido) - 1] == "X" || ValoresDisponibles[Convert.ToInt32(valorIntroducido) - 1] == "0")
                                {
                                    Console.WriteLine("Ese valor ya esta cogido");
                                    valorIntroducidoCorrecto = false;
                                }
                                else
                                {
                                    valorConvertido = Convert.ToInt32(valorIntroducido);
                                    valorIntroducidoCorrecto = true;
                                }
                            }
                        } while (valorIntroducidoCorrecto == false) ;
                        ArrayPlayer2[i] = valorConvertido;
                        ValoresDisponibles[valorConvertido - 1] = "0";
                        value = 0;
                        contadorTurnos += 1;
                        int numerosEnRayaPlayer2 = 0;
                        for (int j = 0; j < 3; j++)
                        {
                            Console.WriteLine(ValoresDisponibles[value] + " | " + ValoresDisponibles[value + 1] + " | " + ValoresDisponibles[value + 2]);
                            value += 3;
                        }
                        for (int j = 0; j < 8; j++)
                        {
                            numerosEnRayaPlayer2 = 0;
                            for (int k = 0; k < 3; k++)
                            {
                                for (int l = 0; l < 5; l++)
                                {
                                    if (ArrayVictoria[j, k] == ArrayPlayer2[l])
                                    {
                                        numerosEnRayaPlayer2 += 1;
                                        if (numerosEnRayaPlayer2 == 3)
                                        {
                                            Console.WriteLine("Victoria Player 2 (0)");
                                            end = true;
                                        }
                                    }
                                }
                            }
                        }
                        if (end == true)
                        {
                            break;
                        }
                    }
                }
            } while (end == false);            
        }     
    }
}
