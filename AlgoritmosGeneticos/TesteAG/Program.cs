using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AlgoritmosGeneticos;
using QuadroHorarios;
using ProblemaMochila;

namespace TesteAG
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            GeraQuadroHorarios qh = new GeraQuadroHorarios()
            {
                TamanhoPopulacao = 10,
                TaxaCruzamento = 0.5f,
                TaxaMutacao = 0.3f,
                TaxaSelecao = 0.5f                
            };

            qh.AddHorario("SEG12");
            qh.AddHorario("SEG34");
            qh.AddHorario("TER12");
            qh.AddHorario("TER34");
            qh.AddHorario("QUA12");
            qh.AddHorario("QUA34");
            qh.AddHorario("QUI12");
            qh.AddHorario("QUI34");
            qh.AddHorario("SEX12");
            qh.AddHorario("SEX34");

            qh.AddProfessor("P1");
            qh.AddProfessor("P2");
            qh.AddProfessor("P3");
            qh.AddProfessor("P4");
            qh.AddProfessor("P5");

            qh.AddRestricao("P1", "SEG12");
            qh.AddRestricao("P1", "TER12");
            qh.AddRestricao("P1", "QUI12");

            qh.AddRestricao("P2", "SEX34");
            qh.AddRestricao("P2", "QUI34");
            qh.AddRestricao("P2", "TER34");

            qh.AddRestricao("P3", "QUA12");
            qh.AddRestricao("P3", "QUA34");
            qh.AddRestricao("P3", "TER34");

            qh.AddRestricao("P4", "SEX34");
            qh.AddRestricao("P4", "QUI12");
            qh.AddRestricao("P4", "SEG12");

            qh.AddRestricao("P5", "TER12");
            qh.AddRestricao("P5", "QUI12");
            qh.AddRestricao("P5", "QUA12");

            
            qh.Executar();

            String h1 = "|";
            String v1 = "|";
            String h2 = "|";
            String v2 = "|";
            for (int hor = 0; hor < qh.Horarios.Count; hor += 2)
            {
                h1 = h1 + "\t" + qh.Horarios[hor] + "\t|";
                v1 = v1 + "\t" + qh.Solucao.Cromossomos[hor] + "\t|";
                h2 = h2 + "\t" + qh.Horarios[hor+1] + "\t|";
                v2 = v2 + "\t" + qh.Solucao.Cromossomos[hor+1] + "\t|";
            }
            Console.Write(h1 + "\n" + v1 + "\n" + h2 + "\n" + v2 + "\n");
            Console.Write("Gerações: " + qh.Geracoes);

            Console.ReadLine();
            */

            GeraMochila gm = new GeraMochila(45)
            {
                TamanhoPopulacao = 10,
                TaxaCruzamento = 0.5f,
                TaxaMutacao = 0.3f,
                TaxaSelecao = 0.5f
            };

            gm.AddItem(new Item() { Descricao = "Lanterna", Peso = 3, Utilidade = 15 });
            gm.AddItem(new Item() { Descricao = "Canivete Suíço", Peso = 1, Utilidade = 10 });
            gm.AddItem(new Item() { Descricao = "Jaca", Peso = 30, Utilidade = 3 });
            gm.AddItem(new Item() { Descricao = "Panela", Peso = 5, Utilidade = 15 });
            gm.AddItem(new Item() { Descricao = "Carne", Peso = 10, Utilidade = 20 });
            gm.AddItem(new Item() { Descricao = "Arroz", Peso = 7, Utilidade = 20 });
            gm.AddItem(new Item() { Descricao = "Feijão", Peso = 8, Utilidade = 20 });
            gm.AddItem(new Item() { Descricao = "Cerveja", Peso = 15, Utilidade = 8 });
            gm.AddItem(new Item() { Descricao = "Mapa", Peso = 1, Utilidade = 15 });
            gm.AddItem(new Item() { Descricao = "Celular", Peso = 3, Utilidade = 9 });
            gm.AddItem(new Item() { Descricao = "Barraca", Peso = 8, Utilidade = 60 });
            gm.AddItem(new Item() { Descricao = "Cobertor", Peso = 8, Utilidade = 25 });
            gm.AddItem(new Item() { Descricao = "Jornal", Peso = 3, Utilidade = 5 });
            gm.AddItem(new Item() { Descricao = "Papel Higiênico", Peso = 2, Utilidade = 14 });
            gm.AddItem(new Item() { Descricao = "Carvão", Peso = 8, Utilidade = 15 });
            gm.AddItem(new Item() { Descricao = "Repelente", Peso = 2, Utilidade = 5 });
            gm.AddItem(new Item() { Descricao = "Vara de Pescar", Peso = 3, Utilidade = 2 });
            gm.AddItem(new Item() { Descricao = "Pente", Peso = 1, Utilidade = 1 });
            gm.AddItem(new Item() { Descricao = "Espelho", Peso = 1, Utilidade = 1 });
            gm.AddItem(new Item() { Descricao = "Sabão", Peso = 2, Utilidade = 7 });
            gm.AddItem(new Item() { Descricao = "Xampu", Peso = 4, Utilidade = 5 });
            gm.AddItem(new Item() { Descricao = "Luvas", Peso = 1, Utilidade = 2 });
            gm.AddItem(new Item() { Descricao = "Violão", Peso = 15, Utilidade = 4 });
            gm.AddItem(new Item() { Descricao = "Fósforo", Peso = 1, Utilidade = 7 });
            gm.AddItem(new Item() { Descricao = "Isqueiro", Peso = 1, Utilidade = 9 });
            gm.AddItem(new Item() { Descricao = "Bússola", Peso = 2, Utilidade = 14 });
            gm.AddItem(new Item() { Descricao = "Roupa", Peso = 5, Utilidade = 28 });
            gm.AddItem(new Item() { Descricao = "Sapatos", Peso = 3, Utilidade = 11 });
            gm.AddItem(new Item() { Descricao = "Protetor Solar", Peso = 2, Utilidade = 6 });
            gm.AddItem(new Item() { Descricao = "Pratos", Peso = 5, Utilidade = 12 });
            gm.AddItem(new Item() { Descricao = "Colheres", Peso = 1, Utilidade = 8 });
            gm.AddItem(new Item() { Descricao = "Facas", Peso = 1, Utilidade = 13 });
            gm.AddItem(new Item() { Descricao = "Binóculos", Peso = 5, Utilidade = 3 });
            gm.AddItem(new Item() { Descricao = "GPS", Peso = 5, Utilidade = 20 });
            gm.AddItem(new Item() { Descricao = "Notebook", Peso = 15, Utilidade = 5 });
            gm.AddItem(new Item() { Descricao = "Som", Peso = 16, Utilidade = 8 });
            gm.AddItem(new Item() { Descricao = "Livro", Peso = 3, Utilidade = 3 });
            gm.AddItem(new Item() { Descricao = "Corda", Peso = 5, Utilidade = 15 });
            gm.AddItem(new Item() { Descricao = "Lixa Unha", Peso = 1, Utilidade = 1 });
            gm.AddItem(new Item() { Descricao = "Esmalte", Peso = 1, Utilidade = 1 });
            gm.AddItem(new Item() { Descricao = "Alicate", Peso = 2, Utilidade = 8 });
            gm.AddItem(new Item() { Descricao = "Machado", Peso = 15, Utilidade = 50 });
            gm.AddItem(new Item() { Descricao = "Linha", Peso = 1, Utilidade = 1 });
            gm.AddItem(new Item() { Descricao = "Agulha", Peso = 1, Utilidade = 1 });
            gm.AddItem(new Item() { Descricao = "Band Aid", Peso = 1, Utilidade = 12 });
            gm.AddItem(new Item() { Descricao = "Mertiolate", Peso = 1, Utilidade = 11 });
            gm.AddItem(new Item() { Descricao = "Gaze", Peso = 1, Utilidade = 13 });
            gm.AddItem(new Item() { Descricao = "Perfume", Peso = 1, Utilidade = 1 });
            gm.AddItem(new Item() { Descricao = "Leite", Peso = 4, Utilidade = 10 });
            gm.AddItem(new Item() { Descricao = "Biscoitos", Peso = 4, Utilidade = 10 });
            gm.AddItem(new Item() { Descricao = "Sucrilhos", Peso = 3, Utilidade = 7 });
            gm.AddItem(new Item() { Descricao = "Bombons", Peso = 3, Utilidade = 5 });
            gm.AddItem(new Item() { Descricao = "Meias", Peso = 1, Utilidade = 2 });
            gm.AddItem(new Item() { Descricao = "Chapeu", Peso = 3, Utilidade = 7 });
            gm.AddItem(new Item() { Descricao = "Estilingue", Peso = 1, Utilidade = 4 });
            gm.AddItem(new Item() { Descricao = "Martelo", Peso = 6, Utilidade = 12 });
            gm.AddItem(new Item() { Descricao = "Arame", Peso = 6, Utilidade = 15 });

            gm.Executar();

            int index = 0;
            foreach (object o in gm.Solucao.Cromossomos)
            {
                int it = (int)o;
                if (it == 1)
                {
                    Console.WriteLine("Item: " + gm.Itens[index].Descricao +
                        "\tPeso: " + gm.Itens[index].Peso + "\tUtil: " + gm.Itens[index].Utilidade);
                }
                index++;
            }
            Mochila m = (Mochila)gm.Solucao;
            Console.WriteLine("Utilidade: " + m.Utilidade);
            Console.WriteLine("Peso: " + m.Peso);
            Console.WriteLine("Gerações: " + gm.Geracoes);
            Console.ReadLine();
        }
    }
}
