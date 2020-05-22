/*
 * LPII
 * Pedro Gomes nº8626
 * Tiago Cruz nº9125
 * 
 * Classe de medicos
 * Manipulação de medicos
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

    public class Medicos
    {
        #region Member Variables
        //Lista de todos os médicos
        private static List<Medico> todosMedicos;
        #endregion

        #region Constructors
        static Medicos()
        {
            todosMedicos = new List<Medico>();
        }
        #endregion

        #region Functions
        /// <summary>
        /// Adiciona um médico à lista de médicos
        /// </summary>
        /// <param name="m">Médico</param>
        /// <returns>true (se o médico inserido não estava contido na lista e foi adicionado) / false (se o médico estava contido na lista) </returns>
        public static bool AddMedico(Medico m)
        {
            //tenta executar o seguinte código
            try
            {
                //verifica se o médico inserido está contido na lista
                if (todosMedicos.Contains(m))
                {
                    return false;
                }

                todosMedicos.Add(m); // adiciona o médico à lista de médicos
            }
            catch (InsereException e) //caso haja um erro de inserção envia uma mensagem com a exception e
            {
                throw e;
            }
            return true;
        }
        /// <summary>
        /// Remove um médico da lista de médicos
        /// </summary>
        /// <param name="m">Médico</param>
        /// <returns>true (se o a lista continha o médico inserido e foi removido) e false (se a lista não continha o médico inserido)</returns>
        public static bool RemoveMedico(Medico m)
        {
            try
            {
                //verifica se o médico inserido está contido na lista
                if (todosMedicos.Contains(m))
                {
                    todosMedicos.Remove(m); //remove o médico da lista
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
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="altera"></param>
        /// <param name="novo"></param>
        /// <returns></returns>
        public static bool ChangeMedico(Medico m, int altera, string novo)
        {
            try
            {
                int a; //variável de auxílio à conversão para inteiros (ex: int.TryParse(novo, out todosMedicos[i].CodMedico é inválido)

                if (todosMedicos.Contains(m))
                {
                    //variável que indica a posição do médico m na lista de médicos
                    int i = todosMedicos.IndexOf(m);
                    switch (altera)
                    {
                        case 1: //caso seja desejado alterar o nome do médico inserido
                            todosMedicos[i].Nome = novo; //iguala a string "novo" à propriedade de "nome" do médico inserido
                            break;
                        case 2://caso seja desejado alterar o código de médico do médico inserido
                            int.TryParse(novo, out a); //converte a string "novo" num inteiro a
                            todosMedicos[i].CodigoMed = a; //iguala o inteiro "a" à propriedade de "código de médico" do médico inserido
                            break;

                        case 3:
                            DateTime aux;
                            DateTime.TryParse(novo, out aux); //converte a string "novo" para o DateTime "aux"
                            if (DateTime.TryParse(novo, out aux) == true) //verifica se a conversão foi um sucesso
                            {
                                todosMedicos[i].DataNasc = aux; ////iguala o DateTime "aux" à data de nascimento do médico inserido
                            }
                            break;

                        case 4://caso seja desejado alterar a especialidade do médico inserido
                            todosMedicos[i].Especialidade = novo; //iguala a string "novo" à propriedade de "especialidade" do médico inserido
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
