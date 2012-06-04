using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedesNeurais
{
    public class RNA 
    {
        private Camada[] camadas;
        private IFuncaoAtivacao ativacao;
        private double taxaAprendizado;
        private double erroGlobal = 1, nivelErro;
        private int numEntradas, numSaidas, numCamadas, maxEpocas;

        public RNA(IFuncaoAtivacao ativacao,
            double taxaAprendizado, int numEntradas,
            int numSaidas, int numCamadas, int mxEpocas, double nlErro) {
                this.ativacao = ativacao;
                this.taxaAprendizado = taxaAprendizado;
                this.numEntradas = numEntradas;
                this.numSaidas = numSaidas;
                this.numCamadas = numCamadas;
                this.nivelErro = nlErro;
                this.maxEpocas = mxEpocas;
                camadas = new Camada[numCamadas];
        }

        public void ConfiguraCamada(int index, int quantNeuronios) { 
            int qtdEntradas;
            if (index == 0)
                   qtdEntradas = numEntradas;
            else{
                   qtdEntradas = camadas[index - 1].NumeroNeuronios;
                } 
            
            camadas[index] = new Camada(quantNeuronios, qtdEntradas,
            taxaAprendizado, 1000, ativacao);
        }

        public double[] Gerar(double[] x) {
            double[] saida = camadas[0].Gerar(x);
            for (int i = 1; i < numCamadas; i++) {
                saida = camadas[i].Gerar(saida);
            }
            return saida;
        }
        
        public void Treinar(int numPadroes, double[,] conjTreinamento, double[,] saidasEsperadas)
        {
            int contEpocas = 0;
            while (erroGlobal > nivelErro && contEpocas < maxEpocas)
            {

                for (int padrao = 0; padrao < numPadroes; padrao++)
                {

                    double[] x = new double[numEntradas];
                    double[] entrada = new double[numEntradas];

                    for (int tmp = 0; tmp < numEntradas; tmp++)
                    {
                        x[tmp] = conjTreinamento[padrao, tmp];
                        entrada[tmp] = conjTreinamento[padrao, tmp];
                    }

                    double[] saidas = new double[numSaidas];
                    for (int tmp = 0; tmp < numSaidas; tmp++)
                    {
                        saidas[tmp] = saidasEsperadas[padrao, tmp];
                    }

                    double erro = 1;
                    int contIteracoes = 0;
                    while (erro > nivelErro) // && contIteracoes < maxEpocas*5)
                    {
                        contIteracoes++;
                        /*
                         * FASE FORWARD
                         */
                        x = new double[numEntradas];
                        entrada.CopyTo(x, 0);
                        
                        foreach (Camada camada in camadas)
                        {
                            x = camada.Gerar(x);
                        }

                        /*
                         * FASE BACKWARD
                         */

                        // Calcula o erro global
                        erro = 0;
                        String outStr = "";
                        for (int saida = 0; saida < numSaidas; saida++)
                        {
                            double e = saidas[saida] - x[saida];
                            outStr += " " + x[saida];
                            erro = erro + Math.Abs(e);
                            //erroGlobal = erroGlobal + ((e * e)/2);
                        }
                        erroGlobal = erroGlobal + (erro * erro) / 2;
                        erroGlobal = erroGlobal / 2;

                        Console.WriteLine("Epoca:" + contEpocas + "\tIteração:" + contIteracoes + "\tPadrao:" + padrao + "\t\tErro:" + erro + " " + outStr);

                        //Atualiza pesos da última camada

                        camadas[numCamadas - 1].CorrigePesos(camadas[numCamadas - 2].Saida, saidas);

                        // Atualiza pesos das camadas intermediárias

                        for (int indiceCamada = numCamadas - 2; indiceCamada >= 0; indiceCamada--)
                        {
                            Camada camada = camadas[indiceCamada];
                            Camada camadaAnterior = camadas[indiceCamada + 1];
                            double[] entradaCamada;
                            if (indiceCamada != 0)
                                entradaCamada = camadas[indiceCamada - 1].Saida;
                            else
                                entradaCamada = entrada;

                            for (int neuronio = 0; neuronio < camada.NumeroNeuronios; neuronio++)
                            {
                                double err = 0;
                                for (int neuronioAnt = 0; neuronioAnt < camadaAnterior.NumeroNeuronios; neuronioAnt++)
                                {
                                    err = err
                                        + (camadaAnterior.Neuronios[neuronioAnt].Erro
                                        * camadaAnterior.Neuronios[neuronioAnt].Pesos[neuronio]);
                                }

                                err = ativacao.Derivada(camada.Neuronios[neuronio].Net) * err;

                                camada.Neuronios[neuronio].CorrigePesos(entradaCamada, err);
                            }
                        }

                    }
                }

                contEpocas++;
            }
        }
    }
}
