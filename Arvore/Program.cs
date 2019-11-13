
using System;

namespace Arvore
{
    class Program
    {
        static void Main(string[] args)
        {
            Arvore arvore = new Arvore(10);
            arvore.Inserir(5);
            arvore.Inserir(15);
            arvore.Inserir(3);
            arvore.Inserir(7);
            arvore.Inserir(13);
            arvore.Inserir(18);
            arvore.Inserir(1);
            arvore.Inserir(4);
            arvore.Inserir(6);
            arvore.Inserir(8);
            arvore.Inserir(11);
            arvore.Inserir(14);
            arvore.Inserir(16);
            arvore.Inserir(21);
            arvore.Inserir(9);
            arvore.Inserir(7);

            var no = arvore.BusqueNo(10);
            arvore.RemoveMaiorDaEsquerda(no);

        }
    }
}
