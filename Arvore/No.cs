using System;
using System.Collections.Generic;
using System.Text;

namespace Arvore
{
    public class No
    {
        private float _valor; 
        private No _esquerdo;
        private No _direito;
        public No()
        {
            _valor = 0;
        }

        public float GetValor()
        {
            return _valor;
        }

        public void SetValor(float valor)
        {
            _valor = valor;
        }

        public No GetDireito()
        {
            return _direito;
        }

        public void SetNoDireito(No no)
        {
            _direito = no;
        }

        public No GetEsquerdo()
        {
            return _esquerdo;
        }

        public void SetNoEsquerdo(No no)
        {
            _esquerdo = no;
        }
    }
}
