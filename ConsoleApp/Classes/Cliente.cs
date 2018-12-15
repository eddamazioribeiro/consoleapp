using System;
using System.Collections.Generic;


namespace ConsoleApp.Classes
{
    public partial class Cliente
    {

        private int _codigo;

        public int Codigo
        {
            get
            {
                return _codigo;
            }
            set
            {
                if (value < 0)
                {
                    _codigo = 0;
                    throw new ConsoleApp.Excecoes.ValidacaoException("O código do cliente não pode ser negativo!");
                    
                }

                _codigo = value;

            }
        }
        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set
            {
                if(value.Length < 5)
                {
                    throw new ConsoleApp.Excecoes.ValidacaoException("O nome deve possuir no mínimo 5 caracteres!");

                }

                _nome = value;
            }
        }

        private int? _tipo;

        public int? Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        private DateTime? _dataCadastro;

        public DateTime? DataCadastro
        {
            get { return _dataCadastro; }
            set { _dataCadastro = value; }
        }

        public List<Contato> Contatos { get; set; }
        
    }
}