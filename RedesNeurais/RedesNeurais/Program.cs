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
     
            
            RNA rede = new RNA(
                // Função de Ativação
                new SigmoideBinaria(), 
                // Taxa de Aprendizagem
                0.5, 
                // Número de Entradas da Rede
                20, 
                // Número de Saídas
                4, 
                // Número de Camadas
                3, 
                // Número de Épocas
                1000, 
                // Taxa de Erro
                0.000001);

            rede.ConfiguraCamada(0, 4);
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
                1, 1, 1, 1 },
                { // Tres
                1, 1, 1, 1, 
                0, 0, 0, 1, 
                1, 1, 1, 1,  
                0, 0, 0 ,1,
                1, 1, 1, 1 },
                { // Quatro
                1, 0, 0, 1, 
                1, 0, 0, 1, 
                1, 1, 1, 1,  
                0, 0, 0 ,1,
                0, 0, 0, 1 }
            };
            
            double[,] saidasEsperadas = new double[,]{ 
                {1,0,0,0},
                {0,1,0,0},
                {0,0,1,0},
                {0,0,0,1}
            };

            rede.Treinar(
                // Número de Padrões
                4,
                // Conjunto de Entradas
                conjTreinamento, 
                // Conjunto das Saídas Esperadas 
                saidasEsperadas);
           
            Console.ReadLine();
            
        }
    }
}
