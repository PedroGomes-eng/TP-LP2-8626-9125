/*
 * LPII
 * Pedro Gomes nº8626
 * Tiago Cruz nº9125
 * 
 * Classe de datas de urgencia
 * definição de datas
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadosUrgencia
{
    public class InfoUrgencia
    {
        #region Member Variables
        int numUtente;
        int codMed;
        string doenca;
        DateTime dataEntrada;
        DateTime dataSaida;
        string tipoUrgencia;
        float preco;
        #endregion

        #region Constructors
        public InfoUrgencia()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Define a propriedade do nº de utente
        /// </summary>
        public int NumUtente
        {
            get { return numUtente; }
            set { numUtente = value; }
        }
        /// <summary>
        /// Define a propriedade do código de médico
        /// </summary>
        public int CodMed
        {
            get { return codMed; }
            set { codMed = value; }
        }
        /// <summary>
        /// Define a propriedade da data de entrada
        /// </summary>
        public DateTime DataEntrada
        {
            get { return dataEntrada; }
            set
            {
                DateTime aux;
                if (DateTime.TryParse(value.ToString(), out aux) == true)
                {
                    dataEntrada = value;
                }
            }
        }
        /// <summary>
        /// Define a propriedade da data de saída
        /// </summary>
        public DateTime DataSaida
        {
            get { return dataSaida; }
            set
            {
                DateTime aux;
                if (DateTime.TryParse(value.ToString(), out aux) == true)
                {
                    dataSaida = value;
                }
            }
        }
        /// <summary>
        /// Define a propriedade da doneça do utente quando entrou na urgência
        /// </summary>
        public string Doenca
        {
            get { return doenca; }
            set { doenca = value; }
        }
        /// <summary>
        /// Define a propriedade do preço do tratamento do utente
        /// </summary>
        public float Preco
        {
            get { return preco; }
            set { preco = value; }
        }
        /// <summary>
        /// Define a propriedade do tipo de urgência do utente (Verde, Amarelo ou Vermelho)
        /// </summary>
        public string TipoUrgencia
        {
            get { return tipoUrgencia; }
            set { tipoUrgencia = value; }
        }
        #endregion
    }
}