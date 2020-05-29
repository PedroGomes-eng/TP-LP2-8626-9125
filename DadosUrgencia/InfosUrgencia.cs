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
using System.IO;
using System.Xml;
using Excepcoes;
using Newtonsoft.Json;
using ObjetosUrgencia;
using System.Runtime.Serialization.Formatters.Binary;

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

        #region Adiciona Entrada
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
        #endregion

        #region Remove Entrada
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
        #endregion

        #region Devolve lista
        /// <summary>
        /// Devolve a lista de entradas para ser utilizada fora da camada de dados
        /// </summary>
        /// <returns>uma cópia da lista de entradas nas urgências</returns>
        public static List<InfoUrgencia> DevolveListainfos()
        {
            List<InfoUrgencia> copiainfos = todasInfos;
            return copiainfos;
        }
        #endregion

        #region Alterar Utentes

        #region Alterar Data de entrada
        /// <summary>
        /// Altera a data de entrada nas urgências cujo número de utente e código de médico são inseridos pertencem
        /// </summary>
        /// <param name="nUtente">numero de utente desejado para alteração</param>
        /// <param name="codMed">código de médico desejado para alteração</param>
        /// <param name="dataEntrada">nova data de entrada</param>
        /// <returns>true (se for efetuada a alteração)/false (se não for efetuada a alteração)</returns>
        public static bool AlteraDataEntradaInfos(int nUtente, int codMed, DateTime dataEntrada)
        {
            try
            {
                foreach (InfoUrgencia i in todasInfos)
                {
                    if (i.NumUtente == nUtente && i.CodMed == codMed)
                    {
                        i.DataEntrada = dataEntrada; //iguala a data de entrada do utente para o dateTime de entrada
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

        #region Alterar Data de saída
        /// <summary>
        /// Altera a data de saída das urgências cujo número de utente e código de médico são inseridos pertencem
        /// </summary>
        /// <param name="nUtente">numero de utente desejado para alteração</param>
        /// <param name="codMed">código de médico desejado para alteração</param>
        /// <param name="dataSaida">nova data de saída</param>
        /// <returns>true (se for efetuada a alteração)/false (se não for efetuada a alteração)</returns>
        public static bool AlteraDataSaidaInfos(int nUtente, int codMed, DateTime dataSaida)
        {
            try
            {
                foreach (InfoUrgencia i in todasInfos)
                {
                    if (i.NumUtente == nUtente && i.CodMed == codMed)
                    {
                        i.DataSaida = dataSaida; //iguala a data de saida do utente para o dateTime de entrada
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

        #region Alterar tipo de urgência
        /// <summary>
        /// Altera o tipo de urgência cujo número de utente e código de médico são inseridos pertencem
        /// </summary>
        /// <param name="nUtente">numero de utente desejado para alteração</param>
        /// <param name="codMed">código de médico desejado para alteração</param>
        /// <param name="tipoUrgencia">novo tipo de urgência</param>
        /// <returns>true (se for efetuada a alteração)/false (se não for efetuada a alteração)</returns>
        public static bool AlteraTipoUrgenciaInfos(int nUtente, int codMed, string tipoUrgencia)
        {
            try
            {
                foreach (InfoUrgencia i in todasInfos)
                {
                    if (i.NumUtente == nUtente && i.CodMed == codMed)
                    {
                        i.TipoUrgencia = tipoUrgencia; //iguala a data de saida do utente para o dateTime de entrada
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

        #region Alterar Doença
        /// <summary>
        /// Altera a doneça cujo número de utente e código de médico são inseridos pertencem
        /// </summary>
        /// <param name="nUtente">numero de utente desejado para alteração</param>
        /// <param name="codMed">código de médico desejado para alteração</param>
        /// <param name="doenca">nova doenca</param>
        /// <returns>true (se for efetuada a alteração)/false (se não for efetuada a alteração)</returns>
        public static bool AlteraDoencaInfos(int nUtente, int codMed, string doenca)
        {
            try
            {
                foreach (InfoUrgencia i in todasInfos)
                {
                    if (i.NumUtente == nUtente && i.CodMed == codMed)
                    {
                        i.Doenca = doenca; //iguala a data de saida do utente para o dateTime de entrada
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

        #region Alterar preço
        /// <summary>
        /// Altera o preço a pagar pelo utente cujo número de utente e código de médico são inseridos pertencem
        /// </summary>
        /// <param name="nUtente">numero de utente desejado para alteração</param>
        /// <param name="codMed">código de médico desejado para alteração</param>
        /// <param name="preco">novo tipo de urgência</param>
        /// <returns>true (se for efetuada a alteração)/false (se não for efetuada a alteração)</returns>
        public static bool AlteraPrecoInfos(int nUtente, int codMed, double preco)
        {
            try
            {
                foreach (InfoUrgencia i in todasInfos)
                {
                    if (i.NumUtente == nUtente && i.CodMed == codMed)
                    {
                        i.Preco = preco; //iguala a data de saida do utente para o dateTime de entrada
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

        #region Escreve entradas BIN
        /// <summary>
        /// Insere as entradas nas urgências registadas num ficheiro binário
        /// </summary>
        /// <returns>true</returns>
        public static bool EscreveBinInfos()
        {
            FileStream fs = new FileStream("Entradas.bin", FileMode.Create); //cria ficheiro binário
            BinaryFormatter bf = new BinaryFormatter(); //cria serializador
            bf.Serialize(fs, todasInfos); //serializa a lista
            fs.Flush();
            fs.Close(); //solta todos os recursos utilizados pela stream
            return true;
        }
        #endregion

        #region Carrega BIN Entradas
        /// <summary>
        /// Carrega o ficheiro Bin
        /// </summary>
        /// <param name="fileName">Ficheiro a ser Carregado</param>
        /// <returns></returns>
        public static bool LoadInfosBin(string fileName)
        {
            try
            {
                //Hashtable aux = null;
                Stream s = File.Open(fileName, FileMode.Open, FileAccess.Read);
                BinaryFormatter b = new BinaryFormatter();
                todasInfos = (List<InfoUrgencia>)b.Deserialize(s);
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

        #region Escreve entradas em XML
        /// <summary>
        /// Escreve a lista de entradas nas urgências num ficheiro .xml
        /// </summary>
        /// <returns>true</returns>
        public static bool EscreveXMLInfos()
        {
            XmlDocument xmlDoc = new XmlDocument(); //Cria um novo ficheiro XML
            XmlNode rootNode = xmlDoc.CreateElement("entradasurg"); //Cria um nodo Raiz com o nome "entradasurg"
            xmlDoc.AppendChild(rootNode);  //fecha o nodo raíz
            foreach (InfoUrgencia i in todasInfos)
            {
                XmlNode infoNode = xmlDoc.CreateElement("entradaurg"); //cria um nodo filho de "entradasurg" com o nome "entradaurg"
                XmlNode nutNode = xmlDoc.CreateElement("numeroutente"); //cria um nodo filho de "entradaurg" com o nome "numeroutente"
                nutNode.InnerText = i.NumUtente.ToString(); //adiciona a propriedade "NumUtente" como texto interior do nodo "numerountente"
                infoNode.AppendChild(nutNode); //fecha o nodo "numeroutente"
                XmlNode cmedNode = xmlDoc.CreateElement("codigomedico");
                cmedNode.InnerText = i.CodMed.ToString();
                infoNode.AppendChild(cmedNode);
                XmlNode dentNode = xmlDoc.CreateElement("dataentrada");
                dentNode.InnerText = i.DataEntrada.ToString();
                infoNode.AppendChild(dentNode);
                XmlNode dsaiNode = xmlDoc.CreateElement("datasaida");
                dsaiNode.InnerText = i.DataSaida.ToString();
                infoNode.AppendChild(dsaiNode);
                XmlNode turgNode = xmlDoc.CreateElement("tipourgencia");
                turgNode.InnerText = i.TipoUrgencia;
                infoNode.AppendChild(turgNode);
                XmlNode doeNode = xmlDoc.CreateElement("doenca");
                doeNode.InnerText = i.Doenca;
                infoNode.AppendChild(doeNode);
                XmlNode precoNode = xmlDoc.CreateElement("preco");
                precoNode.InnerText = i.Preco.ToString();
                infoNode.AppendChild(precoNode);
                rootNode.AppendChild(infoNode);

            }
            xmlDoc.Save("Utentes.xml");
            return true;
        }
        #endregion

        #region Escreve entradas em JSON
        /// <summary>
        /// Escreve a lista de entradas nas urgências num ficheiro JSON
        /// </summary>
        /// <returns>true</returns>
        public static bool EscreveJSONInfos()
        {
            TextWriter file = new StreamWriter("Entradas.json"); //inicia o gravador de texto e cria um ficheiro json com o nome de "Entradas"
            string json = JsonConvert.SerializeObject(todasInfos, Newtonsoft.Json.Formatting.Indented); //converte numa string e serializa a lista "todasInfos" para formato json"
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
