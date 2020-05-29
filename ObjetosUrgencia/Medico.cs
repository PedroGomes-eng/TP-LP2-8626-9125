using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetosUrgencia
{
    [Serializable]
    public class Medico
    {
        #region Member Variables
        string nome;
        int codigoMed;
        DateTime dataNasc;
        static int totMedico = 1;
        string especialidade;
        #endregion

        #region Constructors
        public Medico(string n, DateTime dn, string es)
        {
            this.CodigoMed = totMedico++;
            this.Nome = n;
            this.DataNasc = dn;
            this.Especialidade = es;
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
            set { codigoMed = value; }
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
        #endregion
    }
}
