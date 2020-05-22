/*
 * LPII
 * Pedro Gomes nº8626
 * Tiago Cruz nº9125
 * 
 * Classe de conjuntos de informações de internamento nas urgências
 * Manipulação de conjuntos de informações de internamento nas urgências
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepcoes;
using ObjetosUrgencia;

namespace DadosUrgencia
{
    public class InfosUrgencia
    {
        #region Member Variables
        //Lista de todos os conjuntos de informação sobre o internamento do utente nas urgências
        private static List<InfoUrgencia> todasInfos;
        #endregion

        #region Constructors
        static InfosUrgencia()
        {
            todasInfos = new List<InfoUrgencia>();
        }
        #endregion

        #region Functions
        /// <summary>
        /// Adiciona um Conjunto de informações sobre o internamento de um utente nas urgências
        /// </summary>
        /// <param name="i">Conjunto de Informações</param>
        /// <returns>true (se o conjunto de informações não estava contido na lista e foi adicionado) / false (se o conjunto de informações estava contido na lista) </returns>
        public static bool AddInfo(InfoUrgencia i)
        {
            //tenta executar o seguinte código
            try
            {
                //verifica se o conjunto de informações inserido está contido na lista
                if (todasInfos.Contains(i))
                {
                    return false;
                }

                todasInfos.Add(i); // adiciona  o conjunto de informações à lista de médicos
            }
            catch (InsereException e) //caso haja um erro de inserção envia uma mensagem com a exception e
            {
                throw e;
            }
            return true;
        }
        /// <summary>
        /// Remove um conjunto de informações da lista de informações
        /// </summary>
        /// <param name="i">Conjunto de Informações</param>
        /// <returns>true (se o a lista continha o conjunto de informações inserido e foi removido) e false (se a lista não continha o conjunto de informações inserido)</returns>
        public static bool RemoveInfo(InfoUrgencia i)
        {
            try
            {
                //verifica se o conjunto de informações inserido está contido na lista
                if (todasInfos.Contains(i))
                {
                    todasInfos.Remove(i); //remove o conjunto de informações da lista
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (InsereException e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Altera uma das propriedades do conjunto de informações contido na lista
        /// </summary>
        /// <param name="i">Conjunto de Informações</param>
        /// <param name="altera">Propriedade a alterar</param>
        /// <param name="novo">Nova propriedade</param>
        /// <returns></returns>
        public static bool ChangeInfo(InfoUrgencia i, int altera, string novo)
        {
            try
            {
                int a; //variável de auxílio à conversão para inteiros (ex: int.TryParse(novo, out todasInfos[i].CodMedico é inválido)
                float b;
                DateTime aux;
                if (todasInfos.Contains(i))
                {
                    //variável que indica a posição do conjunto de informações "i" na lista de infos
                    int k = todasInfos.IndexOf(i);
                    switch (altera)
                    {
                        case 1: //caso seja desejado alterar o nº de untente da info inserida
                            int.TryParse(novo, out a);
                            todasInfos[k].NumUtente = a; //iguala a string "novo" à propriedade de "número de utente" do conjunto de informações inserido
                            break;

                        case 2://caso seja desejado alterar o código de médico do conjunto de informações inserido
                            int.TryParse(novo, out a); //converte a string "novo" num inteiro a
                            todasInfos[k].CodMed = a; //iguala o inteiro "a" à propriedade de "código de médico" do conjunto de informações inserido
                            break;

                        case 3://Caso seja desejado alterar a data de entrada do utente nas urgências do conjunto de informações inserido
                            DateTime.TryParse(novo, out aux); //converte a string "novo" para o DateTime "aux"
                            if (DateTime.TryParse(novo, out aux) == true) //verifica se a conversão foi um sucesso
                            {
                                todasInfos[k].DataEntrada = aux; ////iguala o DateTime "aux" à data de entrada do utente nas urgências do conjunto de informações inserido
                            }
                            break;

                        case 4://caso seja desejado alterar a data de saída do utente das urgências do conjunto de informações inserido
                            DateTime.TryParse(novo, out aux); //converte a string "novo" para o DateTime "aux"
                            if (DateTime.TryParse(novo, out aux) == true) //verifica se a conversão foi um sucesso
                            {
                                todasInfos[k].DataSaida = aux; //iguala o DateTime "aux" à data de saída do utente do conjunto de informações inserido
                            }
                            break;

                        case 5://caso seja desejado alterar a doença do utente do conjunto de informações inserido
                            todasInfos[k].Doenca = novo; //iguala a string "novo" à propriedade de "Doença" do utente do conjunto de informações inserido
                            break;

                        case 6://caso seja desejado alterar o preço pago pelo utente do conjunto de informações inserido
                            float.TryParse(novo, out b); //converte a string "novo" para o float "b"
                            todasInfos[k].Preco = b; //iguala o float "b" à propriedade de "nome" do conjunto de informações inserido
                            break;

                        case 7://caso seja desejado alterar o tipo de urgência (Verde, Amarelo,Vermelho) do conjunto de informações inserido

                            if (novo == "Verde" || novo == "Amarelo" || novo == "Vermelho") todasInfos[k].TipoUrgencia = novo; //caso a string inserida seja igual às apresentadas, iguala a mesma à propriedade de "TipoUrgência" do conjunto de informações inserido
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (InsereException e)
            {
                throw e;
            }
        }
        #endregion
    }
}
