using System;
using System.Collections.Generic;
using System.Text;

namespace Arvore
{
    public class Arvore
    {
        private No _raiz;

        public Arvore(float valor)
        {
            _raiz = new No();
            _raiz.SetValor(valor);
        }

        public No GetRaiz()
        {
            return _raiz;
        }

        public void Inserir(float valor)
        {
            Inserir(_raiz, valor);
        }

        private void Inserir(No raiz, float valor)
        {
            if (raiz.GetValor() >= valor)
            {
                if (raiz.GetEsquerdo() != null)
                {
                    Inserir(raiz.GetEsquerdo(), valor);
                }
                else
                {
                    No no = new No();
                    no.SetValor(valor);
                    raiz.SetNoEsquerdo(no);
                }
            }
            else
            {
                if (raiz.GetDireito() != null)
                {
                    Inserir(raiz.GetDireito(), valor);
                }
                else
                {
                    No no = new No();
                    no.SetValor(valor);
                    raiz.SetNoDireito(no);
                }
            }
        }


        public List<No> GetNosChildren()
        {
            return _childrens;
        }

        public No BusqueNo(float valor)
        {
            if (_raiz.GetValor() == valor)
            {
                return _raiz;
            }

            if (_raiz.GetValor() > valor)
                return BusqueNo(_raiz.GetEsquerdo(), valor);
            else
                return BusqueNo(_raiz.GetDireito(), valor);
        }

        private No BusqueNo(No no, float valor)
        {
            if (valor == no.GetValor())
                return no;

            if (valor > no.GetValor())
                return BusqueNo(no.GetDireito(), valor);
            else
                return BusqueNo(no.GetDireito(), valor);
        }

        public void RemoveMaiorDaEsquerda(No no)
        {
            if (no.GetEsquerdo() == null)
            {
                return;
            }

            No aux = ObtenhaMaiorDaSubArvoreAEsquerda(no.GetEsquerdo());
            if (aux.GetDireito() != null)
            {
                no.SetValor(aux.GetDireito().GetValor());

            }
            else
            {
                no.SetValor(aux.GetValor());
            }
            
            aux.SetNoDireito(null);
        }

        private No ObtenhaMaiorDaSubArvoreAEsquerda(No no)
        {
            if (no.GetDireito() != null)
            {
                No aux = no.GetDireito();
                No frente = aux.GetDireito();

                if(frente == null || aux == null)
                {
                    return no;
                }

                if (frente.GetEsquerdo() == null && frente.GetDireito() == null)
                {
                    return aux;
                }
            }

            return ObtenhaMaiorDaSubArvoreAEsquerda(no.GetDireito());
        }

        // Outra Forma
        private void RemonteFilhos()
        {
            if (_childrens.Count > 0)
            {
                foreach (No children in _childrens)
                {
                    Inserir(children.GetValor());
                }

                _childrens = new List<No>();
            }
        }

        private List<No> _childrens = new List<No>();
        public void RemoverMenorDaSubADireita(No no)
        {
            if (no.GetDireito() == null && no.GetEsquerdo() == null)
            {
                return;
            }

            No noAuxSubstituto = null;
            No auxSubArvoreDireita = no.GetDireito();

            if (auxSubArvoreDireita != null)
            {
                if (auxSubArvoreDireita.GetEsquerdo() != null)
                {
                    noAuxSubstituto = auxSubArvoreDireita.GetEsquerdo();
                }
            }

            if (noAuxSubstituto != null)
            {
                if (noAuxSubstituto.GetEsquerdo() != null)
                {
                    DesmonteSubArvore(noAuxSubstituto);
                }
            }

            no.SetValor(noAuxSubstituto.GetValor());
            auxSubArvoreDireita.SetNoEsquerdo(null);

            RemonteFilhos();
        }

        private void DesmonteSubArvore(No no)
        {
            if (no.GetEsquerdo() == null
                && no.GetDireito() == null)
            {
                return;
            }

            if (no.GetEsquerdo() != null)
            {
                _childrens.Add(no.GetEsquerdo());
                DesmonteSubArvore(no.GetEsquerdo());
            }

            if (no.GetDireito() != null)
            {
                _childrens.Add(no.GetDireito());
                DesmonteSubArvore(no.GetDireito());
            }

        }

    }
}
