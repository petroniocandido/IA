using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedesNeurais
{
    public class Camada
    {
        public List<Perceptron> Neuronios { get; set; }
        public double[] Saida { get; set; }
        public int NumeroNeuronios        
        {
            get
            {
                return Neuronios.Count;
            }
        }
        
        public Camada(int quantNeuronios, int quantEntradas,
            double n, int maxi, IFuncaoAtivacao a) {
            Neuronios = new List<Perceptron>();
            Saida = new double[quantNeuronios];
            for (int i = 0; i < quantNeuronios; i++) {
                Neuronios.Add(new Perceptron(quantEntradas, 
                    n, maxi, a));
            }
        }

        public double[] Gerar(double[] x) {
            int cont =0; 
            foreach (Perceptron p in Neuronios) {
                Saida[cont] = p.Gerar(x);
                cont++;
            }
            return Saida;
        }

        public void Treinar(double[] x, double[] d) {
            int cont = 0;
            Console.WriteLine("Treinando camada");
            foreach (Perceptron p in Neuronios)
            {
                p.Treinar(x, d[cont]);
                cont++;
            }            
        }

        public void CorrigePesos(double[] x, double[] d)
        {
            int index = 0;
            foreach (Perceptron p in Neuronios)
            {
                double e = d[index] - p.Saida;
                p.CorrigePesos(x, e);
                index++;
            }
        }
    }
}
