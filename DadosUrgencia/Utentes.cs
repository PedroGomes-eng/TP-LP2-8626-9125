/*
 * LPII
 * Pedro Gomes nº8626
 * Tiago Cruz nº9125
 * 
 * Classe de utentes
 * Manipulação de utentes
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
    public class Utentes
    {
        #region Member Variables
        //define uma lista de utentes
        private static List<Utente> todosUtentes;
        #endregion

        #region Constructors
        /// <summary>
        /// Cria uma nova lista de utentes
        /// </summary>
        static Utentes()
        {
            todosUtentes = new List<Utente>();
        }
        #endregion

        #region Functions
        /// <summary>
        /// Adiciona um utente à lista
        /// </summary>
        /// <param name="u">Utente</param>
        /// <returns>true (caso seja adicionado à lista) / false (caso já exista na lista)</returns>
        public static bool AddUtente(Utente u)
        {
            //tenta executar o seguinte código
            try
            {
                //se a lista já contém o utente inserido
                if (todosUtentes.Contains(u))
                {
                    return false;
                }
                //caso a lista não contenha
                todosUtentes.Add(u); //adiciona o utente u à lista
            }
            //caso haja um erro de inserção envia uma mensagem através da exception e
            catch (InsereException e)
            {
                throw e;
            }
            return true;
        }

        /// <summary>
        /// Remove um utente da lista
        /// </summary>
        /// <param name="u">Utente</param>
        /// <returns>true (caso consiga remover com sucesso)/ false (caso não encontre o utente na lista)</returns>
        public static bool RemoveUtente(Utente u)
        {
            //tenta executar o seguinte código
            try
            {
                //se a lista já contém o utente inserido
                if (todosUtentes.Contains(u))
                {
                    todosUtentes.Remove(u); //remove o utente da lista
                }
                else //caso a lista não contenha o utente inserido
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
        /// Altera uma das propriedades do utente na lista
        /// </summary>
        /// <param name="u">Utente</param>
        /// <param name="altera">Propriedade a alterar</param>
        /// <param name="novo">Nova propriedade</param>
        /// <returns>true(caso o utente exista na lista de utentes e a propriedade tenha sido alterada)/ false (caso o utente não exista na lista de utentes) </returns>
        public static bool ChangeUtente(Utente u, int altera, string novo)
        {
            //tenta executar o seguinte código
            try
            {
                //variáveis de auxilio a conversões (ex: int.TryParse(novo, out todosUtentes[i].NumUtente é inválido)
                int a;
                float b;
                bool c;
                //verifica se a lista contém o utente desejado
                if (todosUtentes.Contains(u))
                {
                    //variável que indica a posição do utente u na lista de utentes
                    int i = todosUtentes.IndexOf(u);
                    switch(altera)
                        { 
                        case 1: //caso deseje alterar o nome
                            todosUtentes[i].Nome = novo; // iguala a string inserida ao nome do utente desejado
                            break;

                        case 2://caso deseje alterar o nº de utente
                            int.TryParse(novo, out a); //converte a string "novo" para o inteiro "a"
                            todosUtentes[i].NumUtente = a;//iguala o inteiro "a" ao nº de utente do utente desejado
                            break;

                        case 3:
                            DateTime aux;
                            DateTime.TryParse(novo, out aux); //converte a string "novo" para o DateTime "aux"
                            if (DateTime.TryParse(novo, out aux) == true) //verifica se a conversão foi um sucesso
                            {
                                todosUtentes[i].DataNasc = aux; ////iguala o DateTime "aux" à data de nascimento do utente desejado
                            }
                            break;
                        case 4://caso deseje alterar o peso do utente
                            float.TryParse(novo, out b); //converte a string "novo" para o float "b"
                            todosUtentes[i].Peso = b; //iguala o float "b" ao peso do utente desejado
                            break;

                        case 5://caso deseje alterar a altura do utente 
                            float.TryParse(novo, out b); //converte a string "novo" para o float "b"
                            todosUtentes[i].Altura = b; //iguala o float "b" à altura do utente desejado
                            break;

                        case 6://caso deseje alterar a morada do utente 
                            todosUtentes[i].Morada = novo; //iguala a string "novo" à morada do utente desejado
                            break;

                        case 7://caso deseje alterar o estado do seguro do utente 
                            bool.TryParse(novo, out c); //converte a string "novo" para o booleano "c"
                            todosUtentes[i].Seguro = c; //iguala o booleano "c" ao estado de seguro do utente desejado
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