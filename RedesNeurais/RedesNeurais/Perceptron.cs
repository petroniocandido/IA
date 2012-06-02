using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedesNeurais
{
    public class Perceptron
    {
        private double[] w;

        public double[] Pesos
        {
            get { return w; }
            set { w = value; }
        }
        private double n;
        private int max;
        private double erro = 1;

        public double Erro
        {
            get { return erro; }
            set { erro = value; }
        }
        private double saida = 0;

        public double Saida
        {
            get { return saida; }
            set { saida = value; }
        }
        private double net = 0;

        public double Net
        {
            get { return net; }
            set { net = value; }
        }

        private IFuncaoAtivacao ativacao;     
        

        public Perceptron (int numx, double txaprendizado, int maxit, IFuncaoAtivacao a){
            w = new double[numx + 1];
            Random rnd = new Random(DateTime.Now.Millisecond);
            for(int tmp = 0; tmp <= numx; tmp++)
                w[tmp] = rnd.NextDouble();
            n = txaprendizado;
            ativacao = a;
            max = maxit;            
         }

        public double Gerar(double[] x){
            if (x.Length != w.Length -1){
                throw new Exception("Número de entradas não suportada.");
            }
            
            for (int c = 0; c < x.Length; c++) {
                net += x[c] * w[c];
            }
            net += w[x.Length]*1;
            saida = ativacao.Ativacao(net);
            return saida;
         }

       
        /*public void Treinar(int nn, double[,] x, double[] d)
        {
            int cont = 0;
            while (e != 0 && cont <= max){
                for(int c = 0; c < nn; c++){
                    double[] p = x;
                    Treinar(x,d[c]);
                }
            }
        }*/

             

        public void Treinar(double[] x, double d) {
            erro = 1;
            int cont = 0;
            while (erro != 0 && cont <= max)
            {
                cont++;
                double y = Gerar(x);
                erro = d - y;
                Console.WriteLine("Saida Desejada: " + d + "Saida da Rede:" + y);
                if (erro != 0)
                {
                    
                    Console.WriteLine("erro: " + erro);
                    for (int c = 0; c < x.Length; c++)
                    {
                        w[c] = w[c] + n * x[c] * erro;
                    }
                    w[x.Length] = w[x.Length] + n * 1 * erro;
                    
                }
            }

        }


        public void CorrigePesos(double[] x, double erroAcumulado)
        {
            erro = erroAcumulado ;
            for (int c = 0; c < x.Length; c++)
            {
                w[c] = w[c] + n * erro * x[c];
            }
            w[x.Length] = w[x.Length] + n * erro;
        }

      
    }
}
