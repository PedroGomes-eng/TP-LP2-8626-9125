/*
 * LPII
 * Pedro Gomes nº8626
 * Tiago Cruz nº9125
 * 
 * Classe de utente
 * Definição de utente
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadosUrgencia
{
    public class Utente
    {
        #region Member Variables
        int numUtente;
        string nome;
        DateTime dataNasc;
        float peso;
        float altura;
        string morada;
        bool seguro;
        #endregion


        #region Constructors
        public Utente()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Propriedade que indica o nº de utente
        /// </summary>
        public int NumUtente
        {
            get { return numUtente; }
            set { numUtente = value; }
        }
        /// <summary>
        /// Propriedade que inidica o nome do utente
        /// </summary>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        /// <summary>
        /// Propriedade que indica a data de nascimento do utente
        /// </summary>
        public DateTime DataNasc
        {
            get { return dataNasc; }
            set
            {
                DateTime aux;
                if (DateTime.TryParse(value.ToString(), out aux) == true)
                {
                    dataNasc = value;
                }
            }
        } 
        /// <summary>
        /// Propriedade que indica o peso do utente
        /// </summary>
        public float Peso
        {
            get { return peso; }
            set { peso = value; }
        }
        /// <summary>
        /// Propriedade que indica a morada do utente
        /// </summary>
        public string Morada
        {
            get { return morada; }
            set { morada = value; }
        }
        /// <summary>
        /// Propriedade que indica a altura do utente
        /// </summary>
        public float Altura
        {
            get { return altura; }
            set { altura = value; }
        }

        /// <summary>
        /// Propriedade que indica se o utente possui seguro
        /// </summary>
        public bool Seguro
        {
            get { return seguro; }
            set { seguro = value; }
        }
        #endregion

    }
}
