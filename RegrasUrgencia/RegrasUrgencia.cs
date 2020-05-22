/*
 * LPII
 * Pedro Gomes nº8626
 * Tiago Cruz nº9125
 * 
 * Biblioteca de regras de negócio
 * Funções utilizadas no programa
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DadosUrgencia;
using ObjetosUrgencia;
using Excepcoes;


namespace RegrasUrgencia
{
    public class RegrasUrgencia
    {
        #region Funções Utente

        /// <summary>
        /// Adiciona um utente à lista de utentes
        /// </summary>
        /// <param name="u">Utente</param>
        /// <returns>a função AddUtente (adiciona o utente à lista)</returns>
        public static bool InserirUtente(Utente u)
        {
            try
            {
                return Utentes.AddUtente(u);
            }
            catch (InsereException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Remove um utente da lista de utentes
        /// </summary>
        /// <param name="u">Utente</param>
        /// <return> a função RemoveUtente (remove o utente da lista)></returns>
        public static bool RemoverUtente(Utente u)
        {
            try
            {
                return Utentes.RemoveUtente(u);
            }
            catch (InsereException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Altera uma das propriedades do utente na lista
        /// </summary>
        /// <param name="u">Utente</param>
        /// <param name="escolha">Propriedade a alterar</param>
        /// <param name="entrada">Nova propriedade</param>
        /// <returns>a função ChangeUtente (altera uma propriedade do utente da lista de utentes)</returns>
        public static bool AlterarUtente(Utente u, int escolha, string entrada)
        {
            try
            {
                return Utentes.ChangeUtente(u, escolha, entrada);
            }
            catch (InsereException e)
            {
                throw e;
            }
        }
        #endregion

        #region Funções Médico

        /// <summary>
        /// Adiciona um utente à lista de médicos
        /// </summary>
        /// <param name="m">Médico</param>
        /// <returns>a função AddMedico (adiciona o medico à lista)</returns>
        public static bool InserirMedico(Medico m)
        {
            try
            {
                return Medicos.AddMedico(m);
            }
            catch (InsereException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Remove um médico da lista de médicos
        /// </summary>
        /// <param name="m">Médico</param>
        /// <return> a função RemoveUtente (remove um medico da lista)></returns>
        public static bool RemoverMedico(Medico m)
        {
            try
            {
                return Medicos.RemoveMedico(m);
            }
            catch (InsereException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Altera uma das propriedades do médico na lista
        /// </summary>
        /// <param name="m">Médico</param>
        /// <param name="escolha">Propriedade a alterar</param>
        /// <param name="entrada">Nova propriedade</param>
        /// <returns>a função ChangeMedico (altera uma propriedade do médico da lista de médicos)</returns>
        public static bool AlterarMedico(Medico m, int escolha, string entrada)
        {
            try
            {
                return Medicos.ChangeMedico(m, escolha, entrada);
            }
            catch (InsereException e)
            {
                throw e;
            }
        }
        #endregion

        #region Funções Conjunto de informação

        /// <summary>
        /// Adiciona um conjunto de informações sobre a entrada de um utente nas urgências à lista de conjuntos de informações
        /// </summary>
        /// <param name="i">Conjunto de Informações</param>
        /// <returns>a função AddInfo (adiciona um conjunto de informações à lista)</returns>
        public static bool InserirInformacoes(InfoUrgencia i)
        {
            try
            {
                return InfosUrgencia.AddInfo(i);
            }
            catch (InsereException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Remove um conjunto de informações sobre a entrada de um utente nas urgências à lista de conjuntos de informações
        /// </summary>
        /// <param name="i">Conjunto de Informações</param>
        /// <returns>a função RemoveInfo (remove um conjunto de informações à lista)</returns>
        public static bool RemoverInformacoes(InfoUrgencia i)
        {
            try
            {
                return InfosUrgencia.RemoveInfo(i);
            }
            catch (InsereException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Altera uma das propriedades de um conjunto de informações sobre a entrada de um utente nas urgências na lista de conjunto de informações
        /// </summary>
        /// <param name="i">Conjunto de Informações</param>
        /// <param name="escolha">Propriedade a alterar</param>
        /// <param name="entrada">Nova propriedade</param>
        /// <returns>a função ChangeInfo (altera uma propriedade de um conjunto de informações sobre a entrada de um utente nas urgências na lista de conjunto de informações)</returns>
        public static bool AlterarInformacoes(InfoUrgencia i, int escolha, string entrada)
        {
            try
            {
                return InfosUrgencia.ChangeInfo(i, escolha, entrada);
            }
            catch (InsereException e)
            {
                throw e;
            }
        }
    }
    #endregion
}
