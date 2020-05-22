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
    public class Medico
    {
        #region Member Variables
        string nome;
        int codigoMed;
        DateTime dataNasc;
        static int totMedico = 0;
        string especialidade;
        #endregion

        #region Constructors
        public Medico()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Define a propriedade: Nome
        /// </summary>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        /// <summary>
        /// Define a propriedade: código de médico
        /// </summary>
        public int CodigoMed
        {
            get { return codigoMed; }
            set { codigoMed = totMedico++; }
        }
        /// <summary>
        /// Propriedade que indica a data de nascimento do médico
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
        /// Define a propriedade: Especialidade de Medicina
        /// </summary>
        public string Especialidade
        {
            get { return especialidade; }
            set { especialidade = value; }
        }
        #region


    }
}