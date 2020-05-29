/*
 * LPII
 * Pedro Gomes nº8626
 * Tiago Cruz nº9125
 * 
 * Classe de medicos
 * Manipulação de medicos
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using ObjetosUrgencia;
using Excepcoes;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;


namespace DadosUrgencia
{

    public class Medicos
    {
        #region Member Variables
        //Lista de todos os médicos
        public static List<Medico> todosMedicos;
        #endregion

        #region Constructors
        static Medicos()
        {
            todosMedicos = new List<Medico>();
        }
        #endregion

        #region Functions

        #region Adiciona medico
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
        #endregion

        #region Remove medico
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
        #endregion

        #region Devolve lista
        /// <summary>
        /// Devolve a lista de medicos para ser utilizada fora da camada de dados
        /// </summary>
        /// <returns>uma cópia da lista de medicos</returns>
        public static List<Medico> DevolveListaMedicos()
        {
            List<Medico> copiamedicos = todosMedicos;
            return copiamedicos;
        }
        #endregion

        #region Alterar Medico

        #region Alterar Nome
        /// <summary>
        /// Altera o nome do medico cujo código de médico é inserido
        /// </summary>
        /// <param name="codMed">código de médico desejado para alteração</param>
        /// <param name="nome">novo nome</param>
        /// <returns>true (se for efetuada a alteração)/false (se não for efetuada a alteração)</returns>
        public static bool AlteraNomeMedico(int codMed, string nome)
        {
            try
            {
                foreach (Medico m in todosMedicos)
                {
                    if (m.CodigoMed == codMed)
                    {
                        m.Nome = nome; //iguala o nome do médico para a string de entrada
                    }
                    else return false;
                }
                return true;
            }
            catch (InsereException e)
            {
                throw e;
            }
        }
        #endregion

        #region Alterar Data de nascimento
        /// <summary>
        /// Altera a data de nascimento do médico cujo código de médico é inserido
        /// </summary>
        /// <param name="codMed">código de médico desejado para alteração</param>
        /// <param name="dataNasc">nova data de nascimento</param>
        /// <returns>true (se for efetuada a alteração)/false (se não for efetuada a alteração)</returns>
        public static bool AlteraDataNascMedico(int codMed, DateTime dataNasc)
        {
            try
            {
                foreach (Medico m in todosMedicos)
                {
                    if (m.CodigoMed == codMed)
                    {
                        m.DataNasc = dataNasc; //iguala a data de nascimento do médico para o dateTime de entrada
                    }
                    else return false;
                }
                return true;
            }
            catch (InsereException e)
            {
                throw e;
            }
        }
        #endregion

        #region Alterar Especialidade
        /// <summary>
        /// Altera especialidade do médico cujo número de utente é inserido
        /// </summary>
        /// <param name="codMed">código de médico desejado para alteração</param>
        /// <param name="especialidade">nova especialidade</param>
        /// <returns>true (se for efetuada a alteração)/false (se não for efetuada a alteração)</returns>
        public static bool AlteraEspecialidadeMedico(int codMed, string especialidade)
        {
            try
            {
                foreach (Medico m in todosMedicos)
                {
                    if (m.CodigoMed == codMed)
                    {
                        m.Especialidade = especialidade; //iguala a especialidade do médico para a string de entrada
                    }
                    else return false;
                }
                return true;
            }
            catch (InsereException e)
            {
                throw e;
            }
        }
        #endregion

        #endregion

        #region Escreve medicos em binário
        /// <summary>
        /// Insere os médicos registados num ficheiro binário
        /// </summary>
        /// <returns>true</returns>
        public static bool EscreveBinMedicos()
        {
            try
            {
                FileStream fs = new FileStream("Utentes.bin", FileMode.Create, FileAccess.ReadWrite); //cria ficheiro binário
                BinaryFormatter bf = new BinaryFormatter(); //cria serializador
                bf.Serialize(fs, todosMedicos); //serializa a lista
                fs.Flush();
                fs.Close();
                fs.Dispose(); //solta todos os recursos utilizados pela stream
            }
            catch (Exception e)
            {
                throw e;
            }

            return true;
        }
        #endregion

        #region Carrega BIN medicos
        /// <summary>
        /// Carrega o ficheiro Bin
        /// </summary>
        /// <param name="fileName">Ficheiro a ser Carregado</param>
        /// <returns></returns>
        public static bool LoadMedicosBin(string fileName)
        {
            try
            {
                //Hashtable aux = null;
                Stream s = File.Open(fileName, FileMode.Open, FileAccess.Read);
                BinaryFormatter b = new BinaryFormatter();
                todosMedicos = (List<Medico>)b.Deserialize(s);
                s.Flush();
                s.Close();
                s.Dispose();
                return true;
            }
            catch
            {
                throw new Exception("Erro");
            }
        }

        #endregion

        #region Escreve médicos em XML
        /// <summary>
        /// Escreve a lista de médicos registados num ficheiro .xml
        /// </summary>
        /// <returns>true</returns>
        public static bool EscreveXMLMedicos()
        {
            XmlDocument xmlDoc = new XmlDocument();  //Cria um novo ficheiro XML
            XmlNode rootNode = xmlDoc.CreateElement("medicos"); //Cria um nodo Raiz com o nome "medicos"
            xmlDoc.AppendChild(rootNode); //fecha o nodo raíz
            foreach (Medico m in todosMedicos)
            {
                XmlNode medicoNode = xmlDoc.CreateElement("medico");  //cria um nodo filho de "medicos" com o nome "medico"
                XmlNode cmedNode = xmlDoc.CreateElement("codigomedico"); //cria um nodo filho de "medicos" com o nome "codigomedico"
                cmedNode.InnerText = m.CodigoMed.ToString();//adiciona a propriedade "CodigoMed" como texto interior do nodo "codigomedico"
                medicoNode.AppendChild(cmedNode); //fecha o nodo "numeroutente"
                XmlNode nomeNode = xmlDoc.CreateElement("nome");
                nomeNode.InnerText = m.Nome;
                medicoNode.AppendChild(nomeNode);
                XmlNode dnacNode = xmlDoc.CreateElement("datanascimemnto");
                dnacNode.InnerText = m.DataNasc.ToString();
                medicoNode.AppendChild(dnacNode);
                XmlNode espNode = xmlDoc.CreateElement("peso");
                espNode.InnerText = m.Especialidade;
                medicoNode.AppendChild(espNode);
                rootNode.AppendChild(medicoNode);
            }
            xmlDoc.Save("Medicos.xml");
            return true;
        }
        #endregion

        #region Escreve Medicos em JSON
        /// <summary>
        /// Escreve a lista de utentes registados num ficheiro JSON
        /// </summary>
        /// <returns>true</returns>
        public static bool EscreveJSONMedicos()
        {
            TextWriter file = new StreamWriter("Medicos.json"); //inicia o gravador de texto e cria um ficheiro json com o nome de "Medicos"
            string json = JsonConvert.SerializeObject(todosMedicos, Newtonsoft.Json.Formatting.Indented); //converte numa string e serializa a lista "todosMedicos" para formato json"
            file.Write(json); //escreve a string convertida
            Object aux = JsonConvert.DeserializeObject(json); //desserializa a string que foi convertida
            file.Flush(); //limpa todos os buffers e faz com que quaisquer dados armazenados em buffer sejam gravados no dispositivo subjacente
            file.Close(); //fecha o gravador e limpa todos os recursos do sistema associados ao gravador
            return true;
        }
        #endregion

        

        #endregion
    }
}
