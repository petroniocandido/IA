using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedesNeurais
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*Perceptron p = new Perceptron(2, 0.1, 1000);
            p.Treinar(new double[] { 0, 0 }, 0);
            p.Treinar(new double[] { 1, 0 }, 0);
            p.Treinar(new double[] { 0, 1 }, 0);
            p.Treinar(new double[] { 1, 1 }, 1);*/
            

            double[] um = new double[] { 
                0, 0, 1, 0, 
                0, 0, 1, 0, 
                0, 0, 1, 0, 
                0, 0, 1 ,0,
                0, 1, 1, 0};
            double[] saidasum = new double[] {
                1,0,0,0};

            double[] dois = new double[] { 
                1, 1, 1, 1, 
                0, 0, 0, 1, 
                1, 1, 1, 1,  
                1, 0, 0 ,0,
                1, 1, 1, 1 };
            double[] saidasdois = new double[] {
                0,1,0,0};

            RNA rede = new RNA(new SigmoideBinaria(), 1, 20, 4, 3, 1000, 0.01);
            rede.ConfiguraCamada(0, 20);
            rede.ConfiguraCamada(1, 10);
            rede.ConfiguraCamada(2, 4);

            double[,] conjTreinamento = new double[,]{ 
                { // Um
                0, 0, 1, 0, 
                0, 0, 1, 0, 
                0, 0, 1, 0, 
                0, 0, 1 ,0,
                0, 1, 1, 0}, 
                { // Dois
                1, 1, 1, 1, 
                0, 0, 0, 1, 
                1, 1, 1, 1,  
                1, 0, 0 ,0,
                1, 1, 1, 1 } 
            };
            
            double[,] saidasEsperadas = new double[,]{ 
                {1,0,0,0},
                {0,1,0,0}
            };

            rede.Treinar(2,conjTreinamento, saidasEsperadas);
           
            Console.ReadLine();
            
        }
    }
}
