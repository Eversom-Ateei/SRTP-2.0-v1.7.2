using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication4.Context;
using WebApplication4.DAO;
using WebApplication4.Models;
using WebApplication4.Util;

namespace WebApplication4.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        private TemplateContext _context;
        public static List<SerialBatchNum> serialBatchNums = new List<SerialBatchNum>();
        public static List<SerialBatchNum> serialbyorders = new List<SerialBatchNum>();

        public static ItemMasterData itemMasterData = new ItemMasterData();


        public int user;
        // GET: QualityControl
        public OrdersController(TemplateContext context)
        {
            _context = context;
        }



        public ActionResult Index()
        {






            return View();
        }
        public System.Data.Common.DbDataReader Connect(string query)
        {

            var command = _context.Database.GetDbConnection().CreateCommand();
            command.CommandText = query;
            _context.Database.CloseConnection();
            _context.Database.OpenConnection();
            var res = command.ExecuteReader();
            return res;
        }

        public ActionResult Routers()
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                ViewBag.userSession = "false";
            }
            else
            {

                var userInfo2 = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));
                string user = userInfo2.EmpID.ToString();
                ViewBag.userSession = userInfo2.EmpID.ToString();
                ViewBag.userName = userInfo2.FirstName;


            }


            return View();

        }

        public string RoutersView()
        {
            try
            {
                string ret = "";

                if (HttpContext.Session.GetString("user") == null)
                {

                }
                else
                {
                    string query = "SELECT T0.DocNum, T0.ItemCode, T1.ItemCode as Resource, t0.PlannedQty , (ROW_NUMBER() OVER(PARTITION BY T0.DocEntry ORDER BY t1.U_Pos_Id  ASC)) as Sequence,t1.U_Pos_id as PosId,(select(case when sum((case when QUANTIDADE IS null then 0 else QUANTIDADE end)) IS null then 0 else sum((case when QUANTIDADE IS null then 0 else QUANTIDADE end)) end) as IndicateQty from ATEEI_SRTP_RG_TEMPO X where X.ORDEM = T0.DocEntry and X.PosId = t1.U_Pos_id) AS IndicateQty FROM OWOR T0 INNER JOIN WOR1 T1 ON T0.DocEntry = T1.DocEntry WHERE Itemtype = 290 and t0.Status not in ('L','C','P')  ORDER BY T0.DocEntry,T1.U_Pos_Id asc";
                    SQLConnection con = new SQLConnection(_context);
                    System.Data.Common.DbDataReader data = con.Connect(query);
                    var userInfo2 = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));
                    string user = userInfo2.EmpID.ToString();

                    int count = 1;
                    while (data.Read())
                    {

                        ret = ret + " <tr ondblclick = \"OpenTimeRegister(" + user + "," + data["DocNum"] + ",'" + data["Resource"] + "'," + data["Sequence"] + "," + data["PosId"] + ")\" >" +
                                    " <td class=\"font-weight-bold\" > " + count + " </td> " +
                                    " <td> " + data["DocNum"] + " </td> " +
                                    " <td> " + data["ItemCode"] + " </td> " +
                                    " <td> " + data["Resource"] + " </td> " +
                                    " <td> " + data["IndicateQty"] + " </td> " +
                                    " <td> " + data["PlannedQty"] + " </td> " +
                                    " <td> <div style = \"display: inline-block;\"> " +
                                    " <div style = \"background-image: url('../img/IconTimeRegister.png');\" class=\"icon20x20\" id=\"linkCloseTimeRegiste\" style=\"color: black ; font-size: 15px; \" onclick=\"TimeRegisters(" + data["DocNum"] + "," + data["Sequence"] + "," + data["PosId"] + ")\"  data-toggle=\"modal\" data-target=\"#ModalTimeReg\"></div> " +
                                    " </div> </td> " +
                                     " <td> <div style = \"display: inline-block;\"> " +
                                      " <div style = \"background-image: url('../img/IconQrCode.png');\" class=\"icon20x20\" id=\"linkCloseTimeRegiste\" style=\"color: black ; font-size: 15px; \" onclick=\"SerialBySeq(" + data["DocNum"] + "," + data["Sequence"] + "," + data["PosId"] + ")\"  data-toggle=\"modal\" data-target=\"\"></div> " +

                                    " </div> </td>  </tr> ";
                        count++;

                    }

                    data.Close();

                }
                return ret;
            }
            catch (Exception e)
            {

                return MessageLog.LOAD_PAGE_ERROR;

            }
        }

        public ActionResult OrdersOn()
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                ViewBag.userSession = "false";
            }
            else
            {

                var userInfo2 = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));

                string user = userInfo2.EmpID.ToString();

                ViewBag.userSession = HttpContext.Session.GetString("user").ToString();
                ViewBag.userName = HttpContext.Session.GetString("userName").ToString();

                string query = " SELECT t0.*, t1.CardCode, t2.CardName FROM ATEEI_SRTP_RG_TEMPO t0 inner join OWOR t1 on t0.ORDEM = t1.DocNum left join ocrd t2 on t1.CardCode = t2.cardcode WHERE USUARIO = " + user + " AND TERMINO is null ";

                ViewBag.data = Connect(query);


            }
            return View();


        }
        public string OpenTimeRegister(int usercode, int docEntry, string resource, int sequence, int posId)
        {
            try
            {
                string validate = "SELECT TOP 1 1 FROM ATEEI_SRTP_RG_TEMPO WHERE TERMINO IS NULL AND ORDEM =" + docEntry + " AND RECURSO = '" + resource + "' AND SEQUENCIA = " + sequence + " and usuario =" + usercode + "";
                string query = " INSERT INTO ATEEI_SRTP_RG_TEMPO (ORDEM, RECURSO,INICIO,USUARIO,SEQUENCIA,ID_RG_SETUP,PosId) VALUES(" + docEntry + ", '" + resource + "',Getdate()," + usercode + "," + sequence + ", {ID_RG_TEMPO}, " + posId + " )";

                var conn = new SQLConnection(_context);
                var result = conn.Connect(validate);
                if (!result.HasRows)
                {
                    result.Close();

                    ProductionSetupController Ps = new ProductionSetupController(_context);

                    if (Ps.VerifySetupOnline(docEntry, resource, sequence) != "false")
                    {
                        conn.SqlNonQuery(query.Replace("{ID_RG_TEMPO}", Ps.VerifySetupOnline(docEntry, resource, sequence).ToString()));
                        return MessageLog.ADDTIMEREGISTER;

                    }
                    else
                    {
                        Ps.CreateSetup(docEntry, resource, usercode, sequence, posId);
                        conn.SqlNonQuery(query.Replace("{ID_RG_TEMPO}", Ps.VerifySetupOnline(docEntry, resource, sequence).ToString()));
                        return MessageLog.ADDTIMEREGISTER;
                    }

                }
                else
                {
                    return MessageLog.ADDTIMEREGISTER_ERROR_1;
                }
            }
            catch (Exception e)
            {
                return "Exceção Lançada: " + e.Message.ToString() + "!!!";

            }
        }
        public string CloseTimeRegisterCondiction(int timeRegisterID, double quantity)
        {
            string condiction = "true";

            try
            {

                string docEntry = "-1";
                string sequence = "-1";
                string posId = "-1";
                string resource = "-1";
                string idRgSetup = "-1";
                string user = "-1";
                var conn = new SQLConnection(_context);

                var data = Connect("SELECT ORDEM, RECURSO,INICIO,TERMINO,(CASE WHEN QUANTIDADE IS null then 0 else QUANTIDADE END) as QUANTIDADE,USUARIO,ID,SEQUENCIA,PosId,ID_RG_SETUP FROM ATEEI_SRTP_RG_TEMPO  WHERE ID = " + timeRegisterID + "");

                while (data.Read())
                {
                    docEntry = (data["ORDEM"].ToString());
                    sequence = (data["SEQUENCIA"].ToString());
                    posId = (data["PosId"].ToString());
                    resource = data["RECURSO"].ToString();
                    idRgSetup = (data["ID_RG_SETUP"].ToString());
                    user = (data["USUARIO"].ToString());
                }
                data.Close();


                if (VerifyIsOrderMngSerial(int.Parse(docEntry)) == 2 || VerifyIsOrderMngSerial(int.Parse(docEntry)) == 1)
                {
                    /* if (VerifyIsLastRout(int.Parse(docEntry), int.Parse(sequence)) || (VerifySerialScanned(timeRegisterID) == "true"))
                     {
                         condiction = "../Orders/ScannerSerialOnRout?docEntry=" + docEntry + "&sequence=" + sequence + "&posId=" + posId + "&idRgSetup=" + idRgSetup + "&timeRegisterId=" + timeRegisterID + "&resource=" + resource + "&user=" + user;

                     }*/
                    if ((resource != "SEP.ALM" && VerifyIsOrderMngSerial(int.Parse(docEntry)) == 1) || VerifyIsLastRout(int.Parse(docEntry), int.Parse(sequence)))
                    {
                        condiction = "../Orders/ScannerSerialOnRout?docEntry=" + docEntry + "&sequence=" + sequence + "&posId=" + posId + "&idRgSetup=" + idRgSetup + "&timeRegisterId=" + timeRegisterID + "&resource=" + resource + "&user=" + user;
                    }
                    /*}*/
                }

                return condiction;

            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public string VerifySerialScanned(int timeRegisterId)
        {
            try
            {
                var conn = new SQLConnection(_context);
                var data = Connect("  SELECT * FROM ATEEI_SRTP_RG_N_SERIE_RECURSO WHERE ID_RG_TEMPO =" + timeRegisterId.ToString());

                // System.Diagnostics.Debug.WriteLine("SELECT TOP 1 1 FROM ATEEI_SRTP_RG_N_SERIE_RECURSO WHERE ID_RG_TEMPO = 02"+timeRegisterId.ToString() +"-"+ "teste: "+data.HasRows);
                if (data.HasRows)
                {
                    return "true";
                }
                else
                {
                    return "false";
                }
                data.Close();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string CloseTimeRegister(int timeRegisterID, decimal quantity)
        {
            try
            {
                string res = "";
                int docEntry = -1;
                int sequence = -1;
                string itemCode = "";
                int posId = -1;

                var conn = new SQLConnection(_context);

                var data = Connect("SELECT ORDEM,SEQUENCIA,T1.ItemCode,t0.PosId FROM ATEEI_SRTP_RG_TEMPO T0 INNER JOIN OWOR T1 ON T0.ORDEM = T1.DocEntry  WHERE ID = " + timeRegisterID + "");

                while (data.Read())
                {
                    docEntry = int.Parse(data["ORDEM"].ToString());
                    sequence = int.Parse(data["SEQUENCIA"].ToString());
                    itemCode = data["ItemCode"].ToString();
                    posId = int.Parse(data["PosId"].ToString());
                }

                data.Close();

                ////arrumar aqui tirar o ultima rota
                if (VerifyIsOrderMngSerial(docEntry) == 2 || VerifyIsOrderMngSerial(docEntry) == 1)
                {
                    /* if (VerifyIsLastRout(docEntry, sequence))
                     {*/
                    /// quantity = 0;
                    var result = conn.Connect("select (case when sum(Quantity) IS null then 0 else sum(Quantity) end ) as Quantity  from ATEEI_SRTP_RG_N_SERIE_RECURSO where ID_RG_TEMPO =" + timeRegisterID);
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            if (result.GetDecimal("Quantity") > ((decimal)(0.00000)))
                            {
                                quantity = result.GetDecimal("Quantity");
                            }
                        }
                    }
                    /* else
                     {
                         quantity = 0;
                     }*/

                    result.Close();

                }


                if (decimal.Parse(VerifyPlannedQtyOrder(docEntry, sequence).ToString()) - (VerifyQuantityOrder(docEntry, sequence) + quantity) >= 0)
                {
                    decimal orderQty = (VerifyQuantityOrder(docEntry, sequence) + quantity);
                    decimal aqlQty = VerifyAQLtable(itemCode, orderQty + quantity);
                    if (VerifyOnlineInspectPlan(itemCode, posId, docEntry, sequence) >= aqlQty)
                    {
                        ///Online Spector Status

                        if (VerifyOnlineInspectStatus(docEntry, sequence, posId) == "Y" || quantity == 0 || !VerifyIsExistInspectPlan(itemCode, posId))
                        {
                            ///Teste plans
                            if (VerifyTestInspect(docEntry, sequence) == "Y" || VerifyTestInspect(docEntry, sequence) == null || quantity == 0)
                            {

                                ///Quantity last sector
                                if (QuantityLastSector(docEntry, sequence - 1) >= (VerifyQuantityOrder(docEntry, sequence) + quantity) || sequence == 1)
                                {
                                    string query = "UPDATE ATEEI_SRTP_RG_TEMPO SET QUANTIDADE = " + quantity.ToString().Replace(",", ".") + " , termino = getdate() where  ID = " + timeRegisterID + " ";
                                    conn.SqlNonQuery(query);


                                    ///if last rout then is creted product inspect
                                    if (VerifyIsLastRout(docEntry, sequence))
                                    {
                                        if (quantity > 0)
                                        {
                                            CreateProductInspect(timeRegisterID);


                                            return "Registro de tempo Adicionado!  Planos Criados!";

                                        }
                                        else
                                        {
                                            return "Registro de tempo Adicionado!  Sem Planos Criados!";


                                        }
                                    }
                                    else
                                    {

                                        return "Registro de tempo Adicionado!";
                                    }

                                }
                                else
                                {
                                    return "Quantidade superior ao do ultimo setor";
                                }
                            }
                            else
                            {
                                return "Quantidade superior ao da ordem de produção!";
                            }
                        }
                        else
                        {
                            return "Placas inspecionadas não aprovadas ou não realizadas!";
                        }

                        return "true";

                    }
                    else
                    {
                        return "Verificar a quantidade de placa inspecionadas! tem que estar de acordo com as definições da AQL! Verificar Cadastro de Planos nas Rotas!";


                    }

                }
                else
                {
                    return "Quantidade Superior a da Ordem de Produção! Disponível Ainda :" + ((VerifyQuantityOrder(docEntry, sequence) + quantity) - VerifyPlannedQtyOrder(docEntry, sequence)).ToString();
                }

            }
            catch (Exception e)
            {
                return "Exceção Lançada: " + e.Message.ToString() + "!!!";

            }
        }


        public string SetItems(int idRgSetup, int docEntry)
        {
            try
            {
                SQLConnection con = new SQLConnection(_context);
                /*var res = con.Connect($@"SELECT t4.ItemCode as ItemCode, 
                                                    t4.ItemName,
                                                    (case when t6.UomCode IS null then 'Manual' else t6.UomCode end) as UomCode,
                                                    t4.InvntryUom,
                                                   (CASE WHEN t3.Quantity IS null THEN(CASE WHEN t7.Quantity is null THEN 0 ELSE t7.Quantity  END) ELSE t3.Quantity END) as Quantity,
                                         (CASE WHEN t3.DistNumber IS null THEN(CASE WHEN t7.batchnum is null THEN '' ELSE t7.batchnum  END) ELSE t3.distnumber END) AS BatchNum                                        
                                         from dbo.B1_SnBAllocateDocView t0 
                                         left join OWOR t1 on t0.SnBAllocateViewDocEntry = t1.DocEntry and t0.SnBAllocateViewDocType = 202                                    
                                         left join OITM t4 on t0.SnBAllocateViewItemCode = t4.ItemCode 
                                         left join OSRn t3 on t0.SnBAllocateViewSnbSysNum = t3.SysNumber and t3.ItemCode = t4.ItemCode 
                                         left join WOR1 t6 on t1.DocEntry = t6.DocEntry and t6.LineNum = t0.SnBAllocateViewDocLine 
                                         left join OIBT t7 on t0.SnBAllocateViewSnbSysNum = t7.SysNumber and t7.ItemCode = t4.ItemCode and t7.WhsCode = t0.SnBAllocateViewLocCode 
                                         where SnBAllocateViewDocEntry = {docEntry} and SnBAllocateViewDocType = 202 and t0.SnBAllocateViewAllocQty > 0 
                                         union all                                         
                                         SELECT t3.ItemCode as ItemCode,
                                                t6.ItemName,
                                                (case when t3.UomCode IS null then 'Manual' else t3.UomCode end) as UomCode,
                                                t6.InvntryUom,
                                                (CASE WHEN T0.Quantity < 0 THEN - 1 * t1.Quantity ELSE T1.Quantity END) as Quantity,
                                                (CASE when t7.sysserial is null  then t1.BatchNum else t7.IntrSerial end) as Lote

                    FROM WTR1 T0

                    LEFT JOIN IBT1_LINK T1 ON T0.DocEntry = T1.BaseEntry AND T1.BaseType = 67  AND T1.ItemCode = T0.ItemCode AND T0.WhsCode = T1.WhsCode
                    INNER JOIN WOR1 t3 on T0.U_SRTP_BaseOrd = T3.DocEntry and T0.U_Pos_id = T3.U_Pos_id and t3.ItemCode = t1.ItemCode
                    INNER JOIN owor T4 ON T3.DocEntry = T4.DocEntry
                    INNER JOIN OITM T5 ON T4.ItemCode = T5.ItemCode
                    INNER JOIN OITM T6 ON T3.ItemCode = T6.ItemCode
                    LEFT JOIN OSRI t7 on t1.BatchNum = cast(t7.SysSerial as Varchar) and t3.ItemCode = t7.ItemCode
                    WHERE T4.DocEntry ={docEntry}" );

                */

                /*  while (res.Read())
                  {
                      serialBatchNums.Add(new SerialBatchNum { BatchNum = res["BatchNum"].ToString(), ItemCode = res["ItemCode"].ToString(), Quantity = decimal.Parse(res["Quantity"].ToString().Replace(",",".")) });
                  }

                  res.Close();*/

                string html = " <tr> " +
                           " <th> Item</th>  <th> Serial </th> <th> Quantidade </th><th> Posição</th>  " +
                           " </tr> ";

                string query = " select * from ATEEI_SRTP_SET_ITEMS where ID_RG_SETUP =" + idRgSetup + " order by ID desc ";
                System.Data.Common.DbDataReader data = con.Connect(query);
                while (data.Read())
                {
                    html = html + "<tr>" +
                                    "<td>" + data["ItemCode"] + "</td>" +
                                    "<td>" + data["BatchNum"] + "</td> " +
                                    "<td>" + data["Quantity"] + "</td>" +
                                    "<td>" + data["PosId"] + "</td>" +
                                    "<td><div onclick=\"DeleteSetItems(" + data["ID"] + ", " + data["ID_RG_SETUP"] + " )\"> Excluir<div></td>" +
                                  "</tr> ";
                }

                return html;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string DeleteSetItems(int id, int idRgSetup)
        {
            try
            {
                string query = " DELETE FROM ATEEI_SRTP_SET_ITEMS WHERE ID =" + id;

                string html = " <tr> " +
                               " <th> Item</th>  <th> Serial </th> <th> Quantidade </th><th> Posição</th>  " +
                               " </tr> ";

                SQLConnection con = new SQLConnection(_context);

                query = query + " select * from ATEEI_SRTP_SET_ITEMS where ID_RG_SETUP =" + idRgSetup + " order by ID desc ";

                System.Data.Common.DbDataReader data = con.Connect(query);
                while (data.Read())
                {
                    html = html + "<tr>" +
                                    "<td>" + data["ItemCode"] + "</td>" +
                                    "<td>" + data["BatchNum"] + "</td> " +
                                    "<td>" + data["Quantity"] + "</td>" +
                                    "<td>" + data["PosId"] + "</td>" +
                                    "<td><div onclick=\"DeleteSetItems(" + data["ID"] + ", " + data["ID_RG_SETUP"] + " )\"> Excluir<div></td>" +
                                  "</tr> ";
                }



                return html;
            }
            catch (Exception e)
            {
                return e.Message;

            }


        }

        public string AddSetItems(int docEntry, string itemCode, string batchNum, int idRgSetup, decimal quantity, int posId)
        {
            try
            {
                List<SetupItems> n_Serie = new List<SetupItems>();

                SQLConnection con = new SQLConnection(_context);
                System.Data.Common.DbDataReader datax = con.Connect(" select * from ATEEI_SRTP_SET_ITEMS where PosId=" + posId + " and ID_RG_SETUP =" + idRgSetup);

                while (datax.Read())
                {
                    n_Serie.Add(new SetupItems { Id = int.Parse(datax["ID"].ToString()), BatchNum = datax["BatchNum"].ToString(), ItemCode = datax["ItemCode"].ToString(), IdRgSetup = int.Parse(datax["ID_RG_SETUP"].ToString()), PosId = int.Parse(datax["PosId"].ToString()), Quantity = double.Parse(datax["Quantity"].ToString().Replace(".", ",")) });
                }

                /* 
                  foreach (var batch in serialBatchNums.FindAll(x => x.ItemCode == itemCode && x.BatchNum == batchNum ))
                  {

                      qty = batch.Quantity;
                      ///command = command +qty.ToString();
                  }
                  if (qty >= quantity)
                  {*/

                bool serial_aponted = false;
                string bat = "";
                double Qty_02 = 0;

                foreach (var item in n_Serie.FindAll(x => x.PosId == posId))
                {
                    bat = item.BatchNum;
                    Qty_02 += item.Quantity;

                    if (batchNum == bat)
                    {
                        serial_aponted = true;
                    }

                }

                if ((!datax.HasRows || Qty_02 == 0) && !serial_aponted)
                {
                    datax.Close();
                    string html = " <tr> " +
                                  " <th> Item</th>  <th> Serial </th> <th> Quantidade </th><th> Posição</th>  " +
                                  " </tr> ";

                    string query = " INSERT INTO ATEEI_SRTP_SET_ITEMS(ID_RG_SETUP,ItemCode,BatchNum,Quantity,PosId) Values(" + idRgSetup + ",'" + itemCode + "','" + batchNum + "'," + quantity.ToString().Replace(",", ".") + "," + posId + " ) ";

                    query = query + " select * from ATEEI_SRTP_SET_ITEMS where ID_RG_SETUP =" + idRgSetup + " order by ID desc ";

                    System.Data.Common.DbDataReader data = con.Connect(query);
                    while (data.Read())
                    {
                        html = html + "<tr>" +
                                        "<td>" + data["ItemCode"] + "</td>" +
                                        "<td>" + data["BatchNum"] + "</td> " +
                                        "<td>" + data["Quantity"] + "</td>" +
                                        "<td>" + data["PosId"] + "</td>" +
                                         "<td><div onclick=\"DeleteSetItems(" + data["ID"] + ", " + data["ID_RG_SETUP"] + " )\"> Excluir<div></td>" +
                                      "</tr> ";
                    }
                    data.Close();
                    return html;

                }
                else if (datax.HasRows)
                {
                    string return_ = "";
                    datax.Close();
                    string query_WO = "SELECT * FROM WOR1 WHERE DocEntry = " + docEntry + " and ItemCode = '" + itemCode + "'";
                    System.Data.Common.DbDataReader data_WO = con.Connect(query_WO);
                    while (data_WO.Read())
                    {
                        if (Convert.ToSingle(data_WO["BaseQty"]) > Qty_02)
                        {

                            if (!serial_aponted)
                            {

                                data_WO.Close();
                                string html = " <tr> " +
                                          " <th> Item</th>  <th> Serial </th> <th> Quantidade </th><th> Posição</th>  " +
                                          " </tr> ";

                                string query = " INSERT INTO ATEEI_SRTP_SET_ITEMS(ID_RG_SETUP,ItemCode,BatchNum,Quantity,PosId) Values(" + idRgSetup + ",'" + itemCode + "','" + batchNum + "'," + quantity.ToString().Replace(",", ".") + "," + posId + " ) ";

                                query = query + " select * from ATEEI_SRTP_SET_ITEMS where ID_RG_SETUP =" + idRgSetup + " order by ID desc ";

                                System.Data.Common.DbDataReader data = con.Connect(query);
                                while (data.Read())
                                {
                                    html = html + "<tr>" +
                                                    "<td>" + data["ItemCode"] + "</td>" +
                                                    "<td>" + data["BatchNum"] + "</td> " +
                                                    "<td>" + data["Quantity"] + "</td>" +
                                                    "<td>" + data["PosId"] + "</td>" +
                                                     "<td><div onclick=\"DeleteSetItems(" + data["ID"] + ", " + data["ID_RG_SETUP"] + " )\"> Excluir<div></td>" +
                                                  "</tr> ";
                                }
                                data.Close();
                                return_ = "";
                                return html;
                            }
                            else
                            {
                                return_ = "ERROR4";
                            }
                            return return_;

                        }
                        else
                        {
                            return_ = "ERROR3";
                        }


                    }
                    data_WO.Close();
                    return return_;

                }

                else
                {
                    return "ERROR1";
                }

            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        public string ListTraceBatch(string batchNum)
        {
            try
            {
                SQLConnection con = new SQLConnection(_context);


                string html = " <tr> " +
                           " <th>Ordem de Produção</th>  <th>Componente Aplicado</th> <th>N° Serie Comp</th><th> Quantidade </th>  " +
                           " </tr> ";

                string query = @" SELECT 	
                                    T0.[DocEntry],
	                                (SELECT[ItemCode] FROM OWOR WHERE[DocNum] = T0.[DocEntry]) AS Cod_Item_Acab,
	                                T0.[SerialNumber],
	                                (SELECT[firstName] FROM OHEM WHERE[empID] = T0.[UserAssembly]) AS Usuario,
	                                (CONVERT(varchar, T0.[DateAssembly], 103) + ' ' + CONVERT(varchar, T0.[DateAssembly], 108)) AS Data_Mont,
	                                T1.[ItemCode] AS ItemCode_Comp,
	                                T1.[BatchNum] AS BatchNum_Comp,
	                                REPLACE(T1.[Quantity], '.', ',') AS Qty_Comp
                                FROM
                                     ATEEI_SRTP_PRODUCT_TRACE_WO T0
                                     INNER JOIN ATEEI_SRTP_PRODUCT_TRACE_BATCH T1 ON T0.[ID] = T1.[ID_PRODUCT_TRACE_WO]
                                WHERE

                                     T0.[SerialNumber] = '" + batchNum + "' order by ItemCode_Comp DESC";

                System.Data.Common.DbDataReader data = con.Connect(query);
                while (data.Read())
                {
                   

                    html = html + "<tr>" +
                                    "<td>" + data["DocEntry"] + "</td>" +
                                    "<td>" + data["ItemCode_Comp"] + "</td> " +
                                    "<td>" + data["BatchNum_Comp"] + "</td>" +
                                    "<td>" + data["Qty_Comp"] + "</td>" +
                                    
                                  "</tr> ";
                }

                return html;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }



        public string ReopenTimeRegister(int id)
        {
            try
            {
                if (VerifyUserFunction() == "L")
                {
                    SQLConnection con = new SQLConnection(_context);
                    string query = "UPDATE ATEEI_SRTP_RG_TEMPO SET TERMINO = NULL , QUANTIDADE=NULL WHERE ID=" + id.ToString();
                    con.SqlNonQuery(query);

                    return "true";
                }
                else
                {
                    return "O Usuário conectado não pode executar essa ação!";
                }
            }
            catch (Exception e)
            {

                return e.Message;

            }

        }
        public string DelProdInspByTReg(int TimeRegisterId)
        {
            try
            {
                if (VerifyUserFunction() == "L")
                {
                    SQLConnection con = new SQLConnection(_context);
                    con.SqlNonQuery("IF(select COUNT(*) from ATEEI_SRTP_PLACAS_INSPECIONADAS where ID_RG_TEMPO = " + TimeRegisterId + " and APROVADO != 'N')=0 " +
                                    " begin " +
                                    " DELETE T1 from ATEEI_SRTP_PLACAS_INSPECIONADAS T0 INNER JOIN ATEEI_SRTP_PLACAS_INSPECIONADAS_PARAMETRO T1 ON T0.ID = T1.ID_PLACAS_INSPECIONADAS WHERE T0.ID_RG_TEMPO = " + TimeRegisterId + " AND T0.APROVADO = 'N' " +
                                    " DELETE T0 from ATEEI_SRTP_PLACAS_INSPECIONADAS T0  WHERE T0.ID_RG_TEMPO = " + TimeRegisterId + "  AND T0.APROVADO = 'N'" +
                              " end ");

                    return "true";
                }
                else
                {
                    return "O Usuário conectado não pode executar essa ação!";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string TimeRegSerial(int timeRegisterId)
        {
            try
            {
                string html = " <tr> " +
                     " <th> # </th> " +
                              " <th> Serial </th> " +
                              " <th> Data </th> " +
                              " </tr> ";

                SQLConnection con = new SQLConnection(_context);
                string query = " SELECT * FROM ATEEI_SRTP_RG_N_SERIE_RECURSO WHERE ID_RG_TEMPO =" + timeRegisterId;

                System.Data.Common.DbDataReader data = con.Connect(query);
                int c = 1;
                while (data.Read())
                {
                    html = html + " <tr> " +
                                  " <td>" + c.ToString() + " </td> " +
                                  " <td>" + data["N_SERIE"] + " </td> " +
                                  " <td>" + data["DATA"] + " </td> " +
                                  " </tr> ";
                    c++;
                }
                data.Close();

                return html;
            }
            catch (Exception e)
            {
                return e.Message;
            }


        }
        public string TimeRegisters(int docentry, int sequence, int posId)
        {
            try
            {
                string html = " <tr> " +
                              " <th> Id </th>  <th> Usuário</th>  <th> Quantidade </th> <th> Inicio </th> <th> Final </th> " +
                              " </tr> ";
                SQLConnection con = new SQLConnection(_context);
                string query = " SELECT T2.ID_RG_TEMPO,T1.FirstName,T0.Id,T0.QUANTIDADE AS Quantity,T0.inicio as DateIni, termino as DateFin  FROM ATEEI_SRTP_RG_TEMPO T0 INNER JOIN OHEM t1 on t0.USUARIO = t1.empID LEFT JOIN (SELECT DISTINCT ID_RG_TEMPO FROM  ATEEI_SRTP_PLACAS_INSPECIONADAS) T2 ON T0.ID = T2.ID_RG_TEMPO WHERE t0.ORDEM = " + docentry + " and SEQUENCIA=" + sequence + " and t0.PosId = " + posId + " order by termino asc  ";
                System.Data.Common.DbDataReader data = con.Connect(query);
                while (data.Read())
                {
                    html = html + "<tr>" +
                                  "<td>" + data["Id"] + "</td>" +
                                  "<td>" + data["FirstName"] + "</td>" +
                                  "<td>" + data["Quantity"] + "</td> " +
                                  "<td>" + data["DateIni"] + "</td>" +
                                  "<td>" + data["Datefin"] + "</td>";

                    if (data["Datefin"].ToString().Trim() != "")
                    {
                        if (data["ID_RG_TEMPO"].ToString().Trim() == "")
                        {
                            html = html + "<td> <a href=\"#\" onclick='ReopenTimeRegister(" + data["Id"] + ")' >Abrir Registro</a></td>";
                        }
                        else
                        {
                            html = html + "<td> <a href=\"#\" onclick='alert('Planos já criados')' >Abrir Registro</a></td>";
                        }
                    }
                    else
                    {
                        html = html + "<td> <a href=\"#\" >Abrir Registro</a></td>";
                    }
                    html = html + "<td> <div style =\"background-image: url('../img/IconQrCode.png'); \" class=\"icon20x20\"   data-toggle=\"modal\" data-target=\"#ModalSerial\"  onclick=\"TimeRegSerial(" + data["Id"] + ")\"            ></div> </td>";
                    ///   html = html + " <td> <a href=\"#\" id=\"linkSerial"+ data["Id"] + "\" style=\"color: black; font - size: 15px; \" data-toggle=\"modal\" data-target=\"#ModalSerial\"  onclick=\"TimeRegSerial(" + data["Id"] + ")\"  >Nº de serie</a></td> ";



                }
                data.Close();

                return html;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string SerialBySeq(int docentry, int sequence, int posId)
        {
            try
            {
                string html = " <tr> " +
                              " <th> # </th> " +

                              " <th> Serial </th> " +
                              " <th> Quantidade </th> " +
                              " <th> Data </th>  " +
                              " </tr> ";
                SQLConnection con = new SQLConnection(_context);
                string query = " SELECT T1.Id,t0.N_SERIE,t1.Quantity,T1.DATA FROM ATEEI_SRTP_RESERVA_N_SERIE t0 left join ATEEI_SRTP_RG_N_SERIE_RECURSO t1 on t0.N_SERIE = t1.N_SERIE and t1.SEQUENCIA = " + sequence + "  where t0.ORDEM = " + docentry + "" +
                    "union select Id, N_SERIE, Quantity, DATA from ATEEI_SRTP_RG_N_SERIE_RECURSO where ORDEM = " + docentry + " and SEQUENCIA = " + sequence + " " +

                    " order by n_serie asc ";


                System.Data.Common.DbDataReader data = con.Connect(query);
                int c = 1;
                while (data.Read())
                {
                    html = html + "<tr>" +
                            "<td>" + c + "</td>" +

                                  "<td>" + data["N_SERIE"] + "</td>" +
                                  "<td>" + data["Quantity"] + "</td> " +
                                  "<td> " + data["DATA"] + "</td> ";


                    if (data["Id"].ToString() == "")
                    {
                        html = html + "<td> <div style =\"background-image: url('../img/IconBlock.png'); \" class=\"icon20x20\"></div> </td>";
                    }
                    else
                    {
                        html = html + "<td> <div style =\"background-image: url('../img/IconCheck.png'); \" class=\"icon20x20\"></div> </td>";

                    }
                    html = html + "</tr>";
                    c++;
                }
                data.Close();

                return html;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public bool VerifyIsExistInspectPlan(string itemCode, int posId)
        {
            bool ret = false;

            try
            {
                var conn = new SQLConnection(_context);
                var result = conn.Connect("select * from ITT1 T0 WHERE T0.Father='" + itemCode + "' and u_pos_Id = " + posId + " and (U_INSP_PLAN_R IS NOT NULL OR U_INSP_PLAN_R != '' ) AND TYPE = 290");
                if (result.HasRows)
                {
                    ret = true;
                }
                result.Close();
            }
            catch (Exception e)
            {
                ret = true;
            }

            return ret;

        }

        public decimal VerifyAQLtable(string itemcode, decimal quantity)
        {
            decimal ret = 0;
            try
            {
                var conn = new SQLConnection(_context);
                var result = conn.Connect("SELECT * FROM ATEEI_SRTP_ADDON_AQL T0 INNER JOIN ATEEI_SRTP_ADDON_PAS T1 ON T1.SampleCode = T0.SampleCode LEFT JOIN OITM t2 on t2.U_SrtpPASon = CodeAQL AND U_SrtpNIon = CodePas WHERE T1.\"From\" <= " + quantity.ToString().Replace(",", ".") + " AND T1.\"To\" >= " + quantity.ToString().Replace(",", ".") + "  AND T2.ItemCode = '" + itemcode + "'");
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        ret = result.GetDecimal("SampleSize");
                    }
                }
                else
                {
                    ret = 0;
                }
                result.Close();
            }
            catch (Exception e)
            {
                ret = -1;
            }

            return ret;
        }
        public int VerifyIsOrderMngSerial(int docEntry)
        {
            int ret = -1;

            try
            {
                var conn = new SQLConnection(_context);

                var resultManItem = conn.Connect("SELECT ManSerNum, ManBtchNum, ManOutOnly FROM OWOR T0 INNER JOIN OITM T1 ON T0.ItemCode = T1.ItemCode where T0.DocEntry = " + docEntry);
                while (resultManItem.Read())
                {
                    itemMasterData.ManBtchNum = resultManItem["ManBtchNum"].ToString();
                    itemMasterData.ManSerNum = resultManItem["ManSerNum"].ToString();
                }
                resultManItem.Close();
                


                if (itemMasterData.ManSerNum == "Y")
                {
                    ret = 2;
                }
                else
                {
                    if (itemMasterData.ManBtchNum == "Y")
                    {
                        ret = 1;
                    }
                    else
                    {
                        ret = 0;
                    }
                }
            }
            catch (Exception e)
            {
                ret = 0;
            }
            return ret;
        }

        public decimal VerifyQuantityOrder(int docEntry, int sequence)
        {
            decimal quantity = 0;
            try
            {
                var conn = new SQLConnection(_context);
                var result = conn.Connect("select ( SUM(Case when t0.QUANTIDADE IS null then 0 else t0.QUANTIDADE end)) as PlannedQty  from ATEEI_SRTP_RG_TEMPO t0 inner join OWOR t1 on t0.ORDEM = t1.DocEntry  where t1.docentry =" + docEntry + " and t0.SEQUENCIA = " + sequence + " group by t1.PlannedQty ");
                while (result.Read())
                {
                    quantity = result.GetDecimal("PlannedQty");
                }

                result.Close();
            }
            catch (Exception e)
            {
                quantity = -1;
            }
            return quantity;
        }
        public decimal VerifyPlannedQtyOrder(int docEntry, int sequence)
        {
            try
            {
                decimal quantity = 0;
                var conn = new SQLConnection(_context);
                var result = conn.Connect("select  PlannedQty  from ATEEI_SRTP_RG_TEMPO t0 inner join OWOR t1 on t0.ORDEM = t1.DocEntry  where t1.docentry =" + docEntry + " and t0.SEQUENCIA = " + sequence + " group by t1.PlannedQty ");
                while (result.Read())
                {
                    quantity = result.GetDecimal("PlannedQty");
                }
                result.Close();
                return quantity;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public bool VerifyIsLastRout(int docEntry, int sequence)
        {
            try
            {
                bool ret = false;
                var conn = new SQLConnection(_context);
                var result = conn.Connect("SELECT TOP 1 sequence from (select (ROW_NUMBER()over(PARTITION by  docentry order by u_pos_id asc  )) as sequence from WOR1 where ItemType = 290 and docentry = " + docEntry + ") T0 where t0.sequence >" + sequence + "");
                if (!result.HasRows)
                {
                    ret = true;
                }
                else
                {
                    ret = false;
                }
                result.Close();
                return ret;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        /// return -1 like error
        public decimal QuantityLastSector(int docEntry, int sequence)
        {
            try
            {
                decimal quantity = 0;
                string query = "SELECT ORDEM,RECURSO,SEQUENCIA,SUM((CASE WHEN QUANTIDADE IS NULL THEN 0 ELSE QUANTIDADE END)) AS QUANTIDADE FROM ATEEI_SRTP_RG_TEMPO WHERE ORDEM = " + docEntry + " AND SEQUENCIA = " + sequence + " GROUP BY ORDEM,RECURSO,SEQUENCIA ";
                var data = Connect(query);
                while (data.Read())
                {
                    quantity = data.GetDecimal("QUANTIDADE");
                }
                data.Close();
                return quantity;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public decimal VerifyOnlineInspectPlan(string itemCode, int posId, int docEntry, int sequence)
        {
            decimal ret = -1;
            try
            {
                SQLConnection conn = new SQLConnection(_context);
                string query = "select Code from ITT1 t0 where U_INSP_PLAN_R != '' and Father = '" + itemCode + "' and U_Pos_id = " + posId.ToString() + " and Type = 290";
                var data = conn.Connect(query);
                if (data.HasRows)
                {
                    data.Close();
                    data = conn.Connect("select (case when sum(t1.SampleQty ) IS null then 0 else sum(t1.SampleQty) end)  as Qty from ATEEI_SRTP_RG_N_SERIE_RECURSO t0 left join  ATEEI_SRTP_RG_SERIE_ON_SETUP t1 on t0.ID = t1.ID_N_SERIE_RECURSO where ORDEM = " + docEntry.ToString() + " and SEQUENCIA = " + sequence.ToString());
                    while (data.Read())
                    {
                        ret = data.GetDecimal("Qty");
                    }
                    data.Close();
                }
                else
                {
                    ret = 0;
                }
                data.Close();
            }
            catch (Exception e)
            {
                ret = e.HResult;
            }
            return ret;
        }
        public string VerifyOnlineInspectStatus(int docEntry, int sequence, int posId)
        {
            try
            {
                string status = "N";
                string query = " SELECT * FROM ATEEI_SRTP_ASSEMBLY_WORKORDER t0 inner join ATEEI_SRTP_ASSEMBLY_WORKORDER_PARAMETERS t1 ON T0.ID = T1.ID_ASSEMBLY_WORKORDER " +
                               " inner join ATEEI_SRTP_RG_N_SERIE_RECURSO T2 ON T0.ID_N_SERIE_RECURSO = T2.ID " +
                               " left join WOR1 t3 on t3.DocEntry = t0.docentry  and t3.U_Pos_id = t0.PosId " +
                               " WHERE t0.DocEntry = " + docEntry + " AND T2.sequencia = " + sequence + " and t3.U_AssemblyRout = " + posId + " AND Status != 'Y' ";


                ///  string query = "SELECT * FROM ATEEI_SRTP_PRIMEIRA_INSPECAO WHERE ORDEM= "+docEntry+" AND SEQUENCIA="+sequence+"";

                var data = Connect(query);
                if (!data.HasRows)
                {
                    status = "Y";
                }
                else
                {
                    status = "N";
                }

                data.Close();

                return status;
            }
            catch (Exception e)
            {
                return "-1";
            }
        }
        public string VerifyTestInspect(int docEntry, int sequence)
        {
            try
            {
                string status = null;
                ///string query = "SELECT * FROM ATEEI_SRTP_PRODUCT_TEST WHERE ORDEM= " + docEntry + " AND SEQUENCIA=" + sequence + "";
                string query = "select 'Y' as aprovado";
                var data = Connect(query);
                while (data.Read())
                {
                    status = data["APROVADO"].ToString();
                }
                data.Close();
                return status;
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
            return "Y";
        }
        public string CreateProductInspectLines(int productInspectID)
        {
            try
            {
                SQLConnection conn = new SQLConnection(_context);
                System.Data.Common.DbDataReader query;
                query = conn.Connect("select * from ATEEI_SRTP_PLACAS_INSPECIONADAS where ID=" + productInspectID);
                int id = 0;
                string command = "";
                string itemCode = "";
                while (query.Read())
                {
                    id = int.Parse(query["id"].ToString());
                    itemCode = query["ITEM"].ToString();
                }
                query.Close();
                command = "SELECT * FROM \"@PLANO_INSP_L\" T1 LEFT JOIN OITT t4 on t1.Code = t4.U_INSP_PLAN  WHERE T4.Code ='" + itemCode + "'";
                query = conn.Connect(command);
                command = "";
                while (query.Read())
                {
                    command = command + (" INSERT INTO ATEEI_SRTP_PLACAS_INSPECIONADAS_PARAMETRO (ID_PLACAS_INSPECIONADAS,COD_PARAMETRO,PARAMETRO,APROVADO,OBS,DATA,USUARIO,QUANTIDADE_BLOQUEADA,MOTIVO_STATUS,RELEVANTE,VALOR) VALUES(" + productInspectID + ",'" + query["LineId"].ToString() + "','" + query["U_ATRIBUTOS"].ToString() + "','N','',GETDATE(),null,0,'', '" + query["U_RELEVANTE"].ToString() + "','" + query["U_OBS"].ToString() + "')  ");
                }
                query.Close();
                conn.SqlNonQuery(command);
                return "true";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string CreateProductInspect(int timeRegisterID)
        {
            try
            {
                double quantity = 0;
                string query = "  SELECT T1.DocEntry AS ORDEM,N_SERIE AS LOTE,X0.USUARIO,X0.RECURSO,DATA,X0.SEQUENCIA,x0.ID as ID_RG_TEMPO,T1.ItemCode,x0.QUANTIDADE,T2.ManBtchNum ,T2.ManSerNum FROM ATEEI_SRTP_RG_TEMPO X0 " +
                               "  LEFT JOIN ATEEI_SRTP_RG_N_SERIE_RECURSO T0 ON X0.ID = T0.ID_RG_TEMPO LEFT JOIN OWOR T1 ON X0.ORDEM = T1.DocEntry " +
                               "  LEFT JOIN OITM T2 ON T1.ItemCode = T2.ItemCode WHERE X0.ID = " + timeRegisterID;
                int docEntry = 0;
                string serial;
                string status;
                string itemCode;
                string admType = "";
                int id_rg_tempo = 0;

                var conn = new SQLConnection(_context);
                var data = conn.Connect(query);
                string command = "";

                while (data.Read())
                {
                    docEntry = int.Parse(data["ORDEM"].ToString());
                    serial = data["LOTE"].ToString();

                    if (data["ManSerNum"].ToString() == "Y")
                    {
                        serial = data["LOTE"].ToString();
                        quantity = 1;
                        admType = "SERIE";
                    }
                    else
                    {
                        if (data["ManBtchNum"].ToString() == "Y")
                        {
                            serial = data["LOTE"].ToString();
                            quantity = double.Parse(data["QUANTIDADE"].ToString().Replace(".", ","));
                            admType = "LOTE";
                        }
                        else
                        {
                            if (data["ManBtchNum"].ToString() == "N" && data["ManSerNum"].ToString() == "N")
                            {
                                serial = "NENHUM";
                                quantity = double.Parse(data["QUANTIDADE"].ToString().Replace(".", ","));
                                admType = "NENHUM";
                            }
                            else
                            {
                                serial = "ERROR";
                                quantity = 0;
                                admType = "ERROR";
                            }
                        }
                    }

                    status = "N";
                    itemCode = data["ItemCode"].ToString();
                    id_rg_tempo = int.Parse(data["ID_RG_TEMPO"].ToString());

                    command = command + (" INSERT INTO ATEEI_SRTP_PLACAS_INSPECIONADAS (ORDEM,N_SERIE,APROVADO,ITEM,DATA,QUANTIDADE,ADM_TYPE,ID_RG_TEMPO)  Values(" + docEntry + ",'" + serial + "','" + status + "','" + itemCode + "',null," + quantity.ToString().Replace(",", ".") + ",'" + admType + "'," + id_rg_tempo + ")");


                }
                data.Close();

                if (admType != "NENHUM")
                {
                    command = command + (" INSERT INTO ATEEI_SRTP_PLACAS_INSPECIONADAS_PARAMETRO(ID_PLACAS_INSPECIONADAS,COD_PARAMETRO,PARAMETRO,APROVADO,RELEVANTE,VALOR,QUANTIDADE_BLOQUEADA)  " +
                                            " SELECT(SELECT TOP 1 ID FROM ATEEI_SRTP_PLACAS_INSPECIONADAS P WHERE P.ORDEM = T3.ORDEM AND P.N_SERIE = T3.N_SERIE AND ITEM = (SELECT XX.ITEMCODE FROM OWOR XX WHERE XX.DocEntry = T3.ORDEM) order by ID desc), " +
                                            " LineId , U_atributos,('N') , T1.U_RELEVANTE, T1.U_obs,  0 " +
                                            " FROM \"@PLANO_INSP\" T0 " +
                                            " INNER JOIN \"@PLANO_INSP_L\" T1 ON T0.Code = T1.Code  INNER JOIN OITT T2 ON T0.Code = T2.U_insp_plan  INNER JOIN ATEEI_SRTP_RG_N_SERIE_RECURSO T3 ON  T3.ID_RG_TEMPO = " + id_rg_tempo + " " +
                                            " WHERE T2.Code = (SELECT XX.ITEMCODE FROM OWOR XX WHERE XX.DocEntry = T3.ORDEM) ");

                }
                else
                {
                    command = command + (" INSERT INTO ATEEI_SRTP_PLACAS_INSPECIONADAS_PARAMETRO(ID_PLACAS_INSPECIONADAS,COD_PARAMETRO,PARAMETRO,APROVADO,RELEVANTE,VALOR,QUANTIDADE_BLOQUEADA)  " +
                                            " SELECT(SELECT TOP 1 ID FROM ATEEI_SRTP_PLACAS_INSPECIONADAS P WHERE P.ORDEM = " + docEntry + " AND ITEM = (SELECT XX.ITEMCODE FROM OWOR XX WHERE XX.DocEntry = " + docEntry + ") order by ID desc), " +
                                            " LineId , U_atributos,('N') , T1.U_RELEVANTE, T1.U_obs,  0 " +
                                            " FROM \"@PLANO_INSP\" T0 " +
                                            " INNER JOIN \"@PLANO_INSP_L\" T1 ON T0.Code = T1.Code " +
                                            " INNER JOIN OITT T2 ON T0.Code = T2.U_insp_plan  " +
                                            " WHERE T2.Code = (SELECT XX.ITEMCODE FROM OWOR XX WHERE XX.DocEntry = " + docEntry + ") ");
                }

                conn.SqlNonQuery(command);

                return command;
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
        public ActionResult ScannerSerialOnRout(int docEntry, int sequence, int posId, int idRgSetup, int timeRegisterId, string resource, int user)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                ViewBag.userSession = "false";
            }
            else
            {
                var userInfo2 = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));
                string userSession = userInfo2.EmpID.ToString();
                ViewBag.userSession = userInfo2.EmpID.ToString();
                ViewBag.userName = userInfo2.FirstName;
                string userx = ViewBag.userSession;
                if (userx == user.ToString())
                {

                    SQLConnection conn = new SQLConnection(_context);
                    var dtserial = conn.Connect("SELECT * FROM ATEEI_SRTP_RESERVA_N_SERIE WHERE ORDEM =" + docEntry);
                    serialbyorders.Clear();
                    while (dtserial.Read())
                    {
                        serialbyorders.Add(new SerialBatchNum { BatchNum = dtserial["N_SERIE"].ToString() });
                    }
                    dtserial.Close();
                    var resultManItem = conn.Connect("SELECT ManSerNum, ManBtchNum, ManOutOnly FROM OWOR T0 INNER JOIN OITM T1 ON T0.ItemCode = T1.ItemCode where T0.DocEntry = " + docEntry);
                    while (resultManItem.Read())
                    {
                        itemMasterData.ManBtchNum = resultManItem["ManBtchNum"].ToString();
                        itemMasterData.ManSerNum = resultManItem["ManSerNum"].ToString();
                    }
                    resultManItem.Close();

                    System.Data.Common.DbDataReader query = conn.Connect("  SELECT * FROM  ATEEI_SRTP_RG_TEMPO WHERE id = " + timeRegisterId + " and termino is not null ");

                    string timeRegisterIsClosed = "0";

                    if (query.HasRows)
                    {
                        timeRegisterIsClosed = "1";
                    }

                    query.Close();

                    ViewBag.data = conn.Connect(" SELECT T0.*,(CASE WHEN TERMINO IS NOT NULL THEN 1 ELSE 0 END) AS IsClose FROM ATEEI_SRTP_RG_N_SERIE_RECURSO T0 INNER JOIN ATEEI_SRTP_RG_TEMPO T1 ON T0.ID_RG_TEMPO = T1.ID WHERE T0.ORDEM = " + docEntry + " AND T0.SEQUENCIA = " + sequence + " and T0.PosId = " + posId + " and T0.id_rg_setup = " + idRgSetup + " and T0.ID_RG_TEMPO = " + timeRegisterId + " order by data desc");

                    ViewBag.TimeRegisterIsClosed = timeRegisterIsClosed;
                    ViewBag.docEntry = docEntry;
                    ViewBag.sequence = sequence;
                    ViewBag.posId = posId;
                    ViewBag.idRgSetup = idRgSetup;
                    ViewBag.timeRegisterId = timeRegisterId;
                    ViewBag.resource = resource;
                }
                else
                {
                    ViewBag.TimeRegisterIsClosed = "1";
                }
            }
            return View();
        }

        public string AddSerialRout(int docEntry, int sequence, int posId, int idRgSetup, int timeRegisterId, string resource, string serial, double quantity)
        {
            try
            {
                int mandatorySerial = 1;
                SQLConnection conn = new SQLConnection(_context);
                var userInfo2 = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));
                string user = userInfo2.EmpID.ToString();

                if (VerifyIsOrderMngSerial(docEntry) == 2)
                {
                    quantity = 1;
                    if (VerifySerialOnLastRout(docEntry, serial, sequence) || mandatorySerial == 1)
                    {
                        if (VerifySerialBelongOrder(docEntry, serial))
                        {
                            if (!VerifyIsExistOnRout(docEntry, serial, sequence))
                            {
                                conn.SqlNonQuery(" INSERT INTO ATEEI_SRTP_RG_N_SERIE_RECURSO(ORDEM,N_SERIE,USUARIO,RECURSO,DATA,SEQUENCIA,ID_RG_TEMPO,PosId,ID_RG_SETUP,Quantity) VALUES (" + docEntry + ",'" + serial + "'," + user + ",'" + resource + "',getdate()," + sequence + "," + timeRegisterId + "," + posId + "," + idRgSetup + "," + quantity.ToString().Replace(",", ".") + ") ");

                                conn.SqlNonQuery(" if (select COUNT(*) from ATEEI_SRTP_PRODUCT_TRACE_WO where SerialNumber = '" + serial + "')< 1 begin " +
                                                     " insert ATEEI_SRTP_PRODUCT_TRACE_WO (ItemCode,PosId,DocEntry,SerialNumber,Quantity,AssemblyRout) " +
                                                     " select T1.ItemCode,U_Pos_id,t1.DocEntry,'" + serial + "',(T1.BaseQty * " + quantity.ToString().Replace(",", ".") + ") as BaseQty ,U_AssemblyRout from OWOR T0 " +
                                                     " INNER JOIN WOR1 T1 ON T0.DocEntry = T1.DocEntry " +
                                                     " WHERE T0.DocEntry = " + docEntry + " " +
                                                     " AND(U_alternativo_linha = U_Pos_id OR(U_alternativo_linha IS NULL AND U_Pos_id IS NOT NULL)) AND ItemType = 4 " +
                                                     " end ");
                                string html = "";

                                var data = conn.Connect(" SELECT * FROM ATEEI_SRTP_RG_N_SERIE_RECURSO T0  WHERE T0.ORDEM = " + docEntry + " AND T0.SEQUENCIA = " + sequence + " and T0.PosId = " + posId + " and T0.id_rg_setup = " + idRgSetup + " and T0.ID_RG_TEMPO = " + timeRegisterId + "   order by data desc ");

                                int line = 1;
                                while (data.Read())
                                {
                                    html = html + " <tr> " +
                                                     " <td> " + line + " </td> " +
                                                     " <td data-bs-toggle=\"tooltip\" data-bs-html=\"true\" title = \"ATEEI_SRTP_RG_N_SERIE_RECURSO.N_SERIE\" > " + data["N_serie"] + " </td> " +
                                                     " <td data-bs-toggle=\"tooltip\" data-bs-html=\"true\" title = \"ATEEI_SRTP_RG_N_SERIE_RECURSO.Quantity\" > " + data["Quantity"] + " </td > " +
                                                     " <td> <div style = \"background-image: url('../img/IconTrace.png');\" class=\"icon20x20\" style=\"color: black ; font-size: 15px;\" onclick=\"ProductTrace('" + data["N_serie"] + "'," + data["PosId"] + "," + docEntry + ")\"></div></td> " +
                                                     " <td> <div style=  \"background - image: url('../img/consulta.png'); \" class=\"icon20x20\" id=\"linkCloseTimeRegiste\" style=\"color: black; font - size: 15px; \" onclick=\"ListTraceBatch( '" + serial + "')\"></div></td> " +
                                                     " <td> <div style = \"background-image: url('../img/IconTest.png');\" class=\"icon20x20\" id=\"linkCloseTimeRegiste\" style=\"color: black ; font-size: 15px; \" onclick=\"alert()\"></div></td> " +
                                                     " <td> <div style = \"background-image: url('../img/IconError.png');\" class=\"icon20x20\" id=\"linkCloseTimeRegiste\" style=\"color: black ; font-size: 15px; \" data-toggle=\"modal\" data-target=\"#id_" + data["ID"] + "\" ondblclick=\"ProductionFlaw('" + data["N_serie"] + "','" + resource + "'," + docEntry + "," + posId + ")\"></div> " +
                                                     " <td> <div style = \"background-image: url('../img/delete.png');\" class=\"icon20x20\" id=\"linkCloseTimeRegiste\" style=\"color: black ; font-size: 15px; \" data-toggle=\"modal\" data-target=\"#id_" + data["ID"] + "\" ondblclick=\" DeleteSerialRout('" + data["ID"] + "')\"></div> " +
                                                     " </tr > ";
                                    line++;
                                }
                                data.Close();

                                string ret = DoTraceSerial(serial, docEntry, user, posId, idRgSetup);

                                if (ret != "true")
                                {
                                    return ret;
                                }
                                else
                                {
                                    return html;
                                }
                            }
                            else
                            {
                                return "3";
                            }
                        }
                        else
                        {
                            return "1";
                        }
                    }
                    else
                    {
                        return "2";
                    }
                }
                else
                {
                    //string QtdOk;
                    //if (VerifyQtyOnLastRout(docEntry, sequence, quantity) == "1"){
                    //    QtdOk = "1";
                    //}
                    //else
                    //{
                    //    QtdOk = "0";
                    //}
                    

                    ////exigir o serial na ultima rota 0 sim 1 não
                    if ((VerifySerialOnLastRout(docEntry, serial, sequence)) || (sequence - 1 == 1)/* || (VerifyLastRout(docEntry, sequence) == "1")*/)
                    {
                        if ((!VerifyIsExistOnRout(docEntry, serial, sequence)) || (VerifyBatchQuantity(docEntry, serial, sequence, quantity)))
                        {

                            if (VerifyBatchQuantity(docEntry, serial, sequence, quantity) || (sequence - 1 == 1)/*VerifyLastRout(docEntry, sequence) == "1"*/)
                            {
                                conn.SqlNonQuery(" insert into ATEEI_SRTP_RG_N_SERIE_RECURSO(ORDEM,N_SERIE,USUARIO,RECURSO,DATA,SEQUENCIA,ID_RG_TEMPO,PosId,ID_RG_SETUP,Quantity) values (" + docEntry + ",'" + serial + "'," + user + ",'" + resource + "',getdate()," + sequence + "," + timeRegisterId + "," + posId + "," + idRgSetup + "," + quantity.ToString().Replace(",", ".") + ") ");

                                conn.SqlNonQuery(" if (select COUNT(*) from ATEEI_SRTP_PRODUCT_TRACE_WO where SerialNumber = '" + serial + "')< 1 begin " +
                                                 " insert ATEEI_SRTP_PRODUCT_TRACE_WO (ItemCode,PosId,DocEntry,SerialNumber,Quantity,AssemblyRout) " +
                                                 " select T1.ItemCode,U_Pos_id,t1.DocEntry,'" + serial + "',(T1.BaseQty * " + quantity.ToString().Replace(",", ".") + ") as BaseQty ,U_AssemblyRout from OWOR T0 " +
                                                 " INNER JOIN WOR1 T1 ON T0.DocEntry = T1.DocEntry " +
                                                 " WHERE T0.DocEntry = " + docEntry + " " +
                                                 " AND(U_alternativo_linha = U_Pos_id OR(U_alternativo_linha IS NULL AND U_Pos_id IS NOT NULL)) AND ItemType = 4 " +
                                                 " end ");

                                var data = conn.Connect(" SELECT top 1 T0.*,(CASE WHEN TERMINO IS NOT NULL THEN 1 ELSE 0 END) AS IsClose FROM ATEEI_SRTP_RG_N_SERIE_RECURSO T0 INNER JOIN ATEEI_SRTP_RG_TEMPO T1 ON T0.ID_RG_TEMPO = T1.ID WHERE T0.ORDEM = " + docEntry + " AND T0.SEQUENCIA = " + sequence + " and T0.PosId = " + posId + " and T0.id_rg_setup = " + idRgSetup + " and T0.ID_RG_TEMPO = " + timeRegisterId + "  order by data desc ");
                                string html = "";
                                int line = 1;
                                while (data.Read())
                                {
                                    html = html + " <tr> " +
                                      " <td> " + line + " </td> " +
                                      " <td data-bs-toggle=\"tooltip\" data-bs-html=\"true\" title = \"ATEEI_SRTP_RG_N_SERIE_RECURSO.N_SERIE\" > " + data["N_serie"] + " </td> " +
                                      " <td data-bs-toggle=\"tooltip\" data-bs-html=\"true\" title = \"ATEEI_SRTP_RG_N_SERIE_RECURSO.Quantity\" > " + data["Quantity"] + " </td > " +
                                      " <td> <div style = \"background-image: url('../img/IconTrace.png');\" class=\"icon20x20\" style=\"color: black ; font-size: 15px;\" onclick=\"ProductTrace('" + data["N_serie"] + "'," + data["PosId"] + "," + docEntry + ")\"></div></td> " +
                                      " <td> <div style = \"background-image: url('../img/IconTest.png');\" class=\"icon20x20\" id=\"linkCloseTimeRegiste\" style=\"color: black ; font-size: 15px; \" onclick=\"alert()\"></div></td> " +
                                      " <td> <div style = \"background-image: url('../img/IconError.png');\" class=\"icon20x20\" id=\"linkCloseTimeRegiste\" style=\"color: black ; font-size: 15px; \" data-toggle=\"modal\" data-target=\"#id_" + data["ID"] + "\" ondblclick=\"ProductionFlaw('" + data["N_serie"] + "','" + resource + "'," + docEntry + "," + posId + ")\"></div> " +
                                      " <td> <div style = \"background-image: url('../img/delete.png');\" class=\"icon20x20\" id=\"linkCloseTimeRegiste\" style=\"color: black ; font-size: 15px; \" data-toggle=\"modal\" data-target=\"#id_" + data["ID"] + "\" ondblclick=\" DeleteSerialRout('" + data["ID"] + "')\"></div> " +
                                      " </tr> ";

                                    line++;
                                }

                                data.Close();

                                string ret = DoTraceSerialBatch(serial, docEntry, user, posId, idRgSetup, quantity);

                                if (ret != "true")
                                {
                                    return ret;
                                }
                                else
                                {
                                    return html;
                                }
                            }
                            else
                            {
                                return "6";

                            }
                        }
                        else
                        {
                            return "3";
                        }
                    }
                    else
                    {

                        return "2";

                    }
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string VerifyQtyOnLastRout(int docEntry, int rout, double qty)
        {

            string ret = "";
            double qtyOnLastRout = 0;
            try
            {

                var conn = new SQLConnection(_context);
                string query = "SELECT * FROM ATEEI_SRTP_RG_TEMPO WHERE ORDEM = " + docEntry + " AND SEQUENCIA = " + 1 + " ";
                var QtyOnLastRoat = conn.Connect(query);
                while (QtyOnLastRoat.Read())
                {
                    qtyOnLastRout = double.Parse(QtyOnLastRoat["QUANTIDADE"].ToString()) + qtyOnLastRout;
                }
                QtyOnLastRoat.Close();

               
              
            }
            catch (Exception e)
            {
                ret = "0";
            }
            return ret;
        }

        public string VerifyLastRout(int docEntry, int rout)
        {
            string ret = "0";
            int lastRout = 0;
           
            try
            {
                
                var conn = new SQLConnection(_context);
                var LastRout = conn.Connect("SELECT TOP 1 SEQUENCIA FROM ATEEI_SRTP_RG_TEMPO WHERE ORDEM = " + docEntry + " ORDER BY SEQUENCIA DESC");
                while (LastRout.Read())
                {
                    lastRout = int.Parse(LastRout["SEQUENCIA"].ToString());

                } LastRout.Close();
                 if (lastRout == 1)
                {
                    ret = "1";
                }
            }
            catch (Exception e)
            {
                ret = "0";
            }
            return  ret;
        }

        public string DoTraceSerialBatch(string serial, int docEntry, string user, int pos, int idRgSetup, double quantitybatch)
        {
            SQLConnection conn = new SQLConnection(_context);
            List<SetupItems> setupItems = new List<SetupItems>();
            var data = conn.Connect("SELECT T1.* FROM ATEEI_SRTP_RG_SETUP t0 inner join ATEEI_SRTP_SET_ITEMS t1 on t0.ID = t1.ID_RG_SETUP  where DocEntry = " + docEntry + " AND T0.PosId=" + pos);
            string ret = data.HasRows.ToString();

            if (!data.HasRows)
            {
                ret = "Erro na configuração do SETUP verifique se o Registro de tempo foi aberto corretamente!";
            }

            bool setOn = false;

            while (data.Read())
            {
                setupItems.Add(new SetupItems { Id = int.Parse(data["ID"].ToString()), BatchNum = data["BatchNum"].ToString(), ItemCode = data["ItemCode"].ToString(), IdRgSetup = int.Parse(data["ID_RG_SETUP"].ToString()), PosId = int.Parse(data["PosId"].ToString()), Quantity = double.Parse(data["Quantity"].ToString().Replace(".", ",")) });
            }
            data.Close();

            var datax = conn.Connect("SELECT t0.*,x.BaseQty  from ATEEI_SRTP_PRODUCT_TRACE_WO t0 " +
" left join(select ID_PRODUCT_TRACE_WO, SUM(Quantity) as Quantity from ATEEI_SRTP_PRODUCT_TRACE_BATCH group by ID_PRODUCT_TRACE_WO) t1 on t0.ID = t1.ID_PRODUCT_TRACE_WO  " +
" left join(select DocEntry, (case when U_alternativo_linha IS not null OR U_alternativo_linha != '' then U_alternativo_linha else U_Pos_id end) U_Pos_id , SUM(BaseQty) as BaseQty from WOR1 t0 where ItemType = 4 group by (case when U_alternativo_linha IS not null OR U_alternativo_linha != '' then U_alternativo_linha else U_Pos_id end) ,DocEntry ) x on t0.DocEntry = x.docEntry and x.U_Pos_id = t0.PosId " +
 " where SerialNumber = '" + serial + "'  and (case when t1.Quantity IS null then 0 else t1.Quantity end) < t0.Quantity  ");

            string command = "";

            while (datax.Read())
            {
                string bat = "";
                string sysnum = "";
                double quantity = -1;
                int idset = 0;
                double batchqty = 0;
                string itemcode = "";
                setOn = false;

                double qtytoinsert;

                foreach (var batch in setupItems.FindAll(x => x.PosId == int.Parse(datax["PosId"].ToString())))
                {
                    setOn = true;
                    bat = batch.BatchNum;
                    sysnum = "null";
                    batchqty = batch.Quantity;
                    quantitybatch = double.Parse(datax["BaseQty"].ToString()) * quantitybatch;
                    if (quantitybatch < double.Parse(datax["Quantity"].ToString()))
                    {
                        quantity = batch.Quantity - quantitybatch;


                        System.Diagnostics.Debug.WriteLine("one" + quantitybatch.ToString());

                    }
                    else
                    {

                        quantity = batch.Quantity - double.Parse(datax["Quantity"].ToString());

                        System.Diagnostics.Debug.WriteLine("two");

                    }
                    idset = batch.Id;
                    itemcode = batch.ItemCode;
                }

                if (quantity >= 0 && setOn)
                {
                    command = command + ("  INSERT INTO ATEEI_SRTP_PRODUCT_TRACE_BATCH(ID_PRODUCT_TRACE_WO,ItemCode,BatchNum,SysNumber,Quantity,DateAssembly,UserAssembly) VALUES(" + datax["ID"] + ",'" + itemcode + "','" + bat + "',null," + quantitybatch.ToString().Replace(",", ".") + ", getdate()," + user + ") ");
                    command = command + ("  UPDATE ATEEI_SRTP_PRODUCT_TRACE_WO set ItemCode ='" + itemcode + "' , UserAssembly=" + user + ", AssemblyRout=" + pos + ", DateAssembly=getdate() where  id = " + datax["ID"].ToString());
                    command = command + ("  UPDATE  ATEEI_SRTP_SET_ITEMS SET Quantity = " + quantity.ToString().Replace(",", ".") + " where id =" + idset);

                    System.Diagnostics.Debug.WriteLine(" INSERT INTO ATEEI_SRTP_PRODUCT_TRACE_BATC");

                    if ((quantity - double.Parse(datax["Quantity"].ToString())) <= 0)
                    {
                        ///error 6 "Material do Setup insuficiente para proximo item!"
                        ret = "6";
                    }
                }
                else
                {
                    if (setOn)
                    {
                        ///error 4 "Material do Setup precisa ser revisado !"
                        ret = "4";
                    }
                }
            }


            datax.Close();
            conn.Connect(command);
            return ret.ToLower();
        }

        public string DoTraceSerial(string serial, int docEntry, string user, int pos, int idRgSetup)
        {
            string ret = "false";
            try
            {
                SQLConnection conn = new SQLConnection(_context);
                List<SetupItems> setupItems = new List<SetupItems>();
                var data = conn.Connect("SELECT T1.PosId as IdPos, T1.* FROM ATEEI_SRTP_RG_SETUP t0 inner join ATEEI_SRTP_SET_ITEMS t1 on t0.ID = t1.ID_RG_SETUP  where DocEntry = " + docEntry + " AND T0.PosId=" + pos + " and Quantity > 0");
                ret = "true";

                /*if (!data.HasRows)
                {
                    ret = "Erro na configuração do SETUP verifique se o Registro de tempo foi aberto corretamente!";
                }*/

                bool setOn = false;
                while (data.Read())
                {
                    setupItems.Add(new SetupItems { Id = int.Parse(data["ID"].ToString()), BatchNum = data["BatchNum"].ToString(), ItemCode = data["ItemCode"].ToString(), IdRgSetup = int.Parse(data["ID_RG_SETUP"].ToString()), PosId = int.Parse(data["IdPos"].ToString()), Quantity = double.Parse(data["Quantity"].ToString().Replace(".", ",")) });
                }
                data.Close();
                var datax = conn.Connect("SELECT t0.* FROM ATEEI_SRTP_PRODUCT_TRACE_WO t0 left join ATEEI_SRTP_PRODUCT_TRACE_BATCH t1 on t0.ID = t1.ID_PRODUCT_TRACE_WO where SerialNumber = '" + serial + "' and t1.ID is null");

                string command = "";

                while (datax.Read())
                {
                    double qtyOnSetup = 0;
                    string bat = "";
                    string sysnum = "";
                    double quantity = -1;
                    int idset = 0;
                    double batchqty = 0;
                    string itemcode = "";
                    setOn = false;

                    foreach (var batch in setupItems.FindAll(x => x.PosId == int.Parse(datax["PosId"].ToString())))
                    {

                        setOn = true;
                        bat = batch.BatchNum;
                        sysnum = "null";
                        batchqty = batch.Quantity;
                        quantity = batch.Quantity - double.Parse(datax["Quantity"].ToString());
                        idset = batch.Id;
                        itemcode = batch.ItemCode;
                        break;
                    }
                    if (quantity < 0 && batchqty != 0)
                    {
                        double QtyOnSetup = 0.0d;

                        foreach (var item in setupItems.FindAll(x => x.ItemCode == datax["ItemCode"].ToString()))
                        {
                            QtyOnSetup += double.Parse(item.Quantity.ToString());
                        }

                        if (QtyOnSetup == double.Parse(datax["Quantity"].ToString()))
                        {
                            foreach (var item in setupItems.FindAll(x => x.ItemCode == datax["ItemCode"].ToString()))
                            {
                                double quantity_02 = 0;

                                command = command + ("  INSERT INTO ATEEI_SRTP_PRODUCT_TRACE_BATCH(ID_PRODUCT_TRACE_WO,ItemCode,BatchNum,SysNumber,Quantity,DateAssembly,UserAssembly) VALUES(" + datax["ID"] + ",'" + item.ItemCode + "','" + item.BatchNum + "',null," + item.Quantity + ", getdate()," + user + ") ");
                                command = command + ("  UPDATE ATEEI_SRTP_PRODUCT_TRACE_WO set ItemCode ='" + item.ItemCode + "' , UserAssembly=" + user + ", AssemblyRout=" + item.PosId + ", DateAssembly=getdate() where  id = " + datax["ID"].ToString());
                                command = command + ("  UPDATE  ATEEI_SRTP_SET_ITEMS SET Quantity = " + quantity_02 + " where id =" + item.Id);
                            }

                        }
                        else
                        {
                            ///error 5 "Quantidade do componente inferior a consumida por placa!"
                            ret = "5";
                            setOn = false;

                        }
                    }

                    else if (quantity >= 0 && setOn)
                    {

                        command = command + ("  INSERT INTO ATEEI_SRTP_PRODUCT_TRACE_BATCH(ID_PRODUCT_TRACE_WO,ItemCode,BatchNum,SysNumber,Quantity,DateAssembly,UserAssembly) VALUES(" + datax["ID"] + ",'" + itemcode + "','" + bat + "',null," + datax["Quantity"].ToString().Replace(",", ".") + ", getdate()," + user + ") ");
                        command = command + ("  UPDATE ATEEI_SRTP_PRODUCT_TRACE_WO set ItemCode ='" + itemcode + "' , UserAssembly=" + user + ", AssemblyRout=" + pos + ", DateAssembly=getdate() where  id = " + datax["ID"].ToString());
                        command = command + ("  UPDATE  ATEEI_SRTP_SET_ITEMS SET Quantity = " + quantity.ToString().Replace(",", ".") + " where id =" + idset);

                        if ((quantity - double.Parse(datax["Quantity"].ToString())) <= 0)
                        {
                            ///error 6 "Material do Setup insuficiente para proximo item!"
                            ret = "6";
                        }
                    }
                    else
                    {
                        if (setOn)
                        {
                            ///error 4 "Material do Setup precisa ser revisado !"
                            ret = "4";
                        }
                        //else
                        //{
                        //    return ret;
                        //}
                    }
                }
                datax.Close();
                conn.Connect(command);


            }
            catch (Exception e)
            {
                ret = "Erro na configuração do SETUP verifique se o Registro de tempo foi aberto corretamente!";


            }
            return ret.ToLower();
        }



        public bool VerifyBatchQuantity(int docEntry, string serial, int sequence, double quantity)
        {
            try
            {
                SQLConnection conn = new SQLConnection(_context);
                string query = ("  select * from  (SELECT ORDEM, RECURSO, SEQUENCIA as SEQUENCIA, N_SERIE, SUM(Quantity) AS Quantidade FROM ATEEI_SRTP_RG_N_SERIE_RECURSO where ORDEM = {1} GROUP BY ORDEM, RECURSO, SEQUENCIA, N_SERIE) t0  left join(SELECT ORDEM, RECURSO, SEQUENCIA, N_SERIE, SUM(Quantity) AS Quantidade FROM ATEEI_SRTP_RG_N_SERIE_RECURSO where ORDEM = {1} GROUP BY ORDEM, RECURSO, SEQUENCIA, N_SERIE) t1 on t0.SEQUENCIA + 1 = t1.SEQUENCIA  AND T0.N_SERIE = T1.N_SERIE  where   t0.ORDEM = {1} and t0.SEQUENCIA = {3}-1 and t0.N_serie = '{2}' and t0.Quantidade  >= ((case when t1.Quantidade IS null then  0 else t1.Quantidade end) +{4}) ");
                query = query.Replace("{1}", docEntry.ToString()).Replace("{2}", serial).Replace("{3}", sequence.ToString()).Replace("{4}", quantity.ToString().Replace(",", "."));
                System.Diagnostics.Debug.WriteLine(query);
                System.Data.Common.DbDataReader result = conn.Connect(query);
                bool res = result.HasRows;
                System.Diagnostics.Debug.WriteLine(res.ToString());
                result.Close();
                if (res)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool VerifySerialOnLastRout(int docEntry, string serial, int sequence)
        {
            bool ret = false;
            try
            {
                SQLConnection conn = new SQLConnection(_context);
                var result = conn.Connect("SELECT top 1 ID FROM ATEEI_SRTP_RG_N_SERIE_RECURSO WHERE ORDEM = " + docEntry + " AND N_SERIE='" + serial + "' AND SEQUENCIA = " + (sequence - 1).ToString() + "");

                
                    if (result.HasRows)
                    {
                        ret = true;
                    }
                    else
                    {
                        if (sequence == 1)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                    
  
                }
                
                result.Close();

            }
            catch (Exception e)
            {
                ret = false;
            }
            return ret;
        }
        public bool VerifySerialOnNextRout(int docEntry, string serial, int sequence)
        {
            bool ret = false;
            try
            {
                SQLConnection conn = new SQLConnection(_context);

                var result = conn.Connect("select top 1 ID from ATEEI_SRTP_RG_N_SERIE_RECURSO WHERE ORDEM = " + docEntry + " AND N_SERIE='" + serial + "' AND SEQUENCIA = " + (sequence + 1).ToString() + "");

                if (result.HasRows)
                {
                    ret = true;
                }
                else
                {
                    ret = false;
                }

                result.Close();
            }
            catch (Exception e)
            {
                ret = false;

            }

            return ret;

        }
        public string DeleteSerialRout(int id)
        {
            try
            {
                SQLConnection conn = new SQLConnection(_context);
                var result = conn.Connect("select * from ATEEI_SRTP_RG_N_SERIE_RECURSO WHERE ID =" + id);
                int docEntry = 0;
                int sequence = 0;
                string serial = "";

                while (result.Read())
                {
                    docEntry = int.Parse(result["ORDEM"].ToString());
                    sequence = int.Parse(result["SEQUENCIA"].ToString());
                    serial = result["N_SERIE"].ToString();
                }
                result.Close();

                if (!VerifySerialOnNextRout(docEntry, serial, sequence))
                {
                    if (!VerifySerialOnlineInspect(id))
                    {

                        conn.SqlNonQuery("DELETE FROM ATEEI_SRTP_RG_N_SERIE_RECURSO WHERE ID =" + id);

                        return "true";
                    }
                    else
                    {
                        return "Já está registrado na Inpeção de Rota ";
                    }
                }
                else
                {
                    return "Já está registrado na Próxima Rota ";
                }
                result.Close();
            }
            catch (Exception e)
            {

                return e.Message;
            }

        }

        /*  public bool VerifySerialBelongOrder(int docEntry, string serial)
          {
              bool ret = false;
              try
              {
                  if (serialbyorders.FindAll(x => x.BatchNum == serial).Count > 0)
                  {
                      ret = true;
                  }
                  else
                  {
                      ret = false;
                  }
              }
              catch (Exception e)
              {
                  ret = false;
              }
              return ret;
          }
        */


        public bool VerifySerialBelongOrder(int docEntry, string serial)
        {
            bool ret = false;
            try
            {
                SQLConnection conn = new SQLConnection(_context);

                var result = conn.Connect("SELECT ORDEM FROM ATEEI_SRTP_RESERVA_N_SERIE where N_SERIE = '" + serial + "' and ORDEM = " + docEntry + "");

                if (result.HasRows)
                {
                    ret = true;
                }
                else
                {
                    ret = false;
                }
                result.Close();
            }
            catch (Exception e)
            {
                ret = false;
            }
            return ret;
        }


        public bool VerifyIsExistOnRout(int docEntry, string serial, int sequence)
        {
            bool ret = true;
            try
            {
                SQLConnection conn = new SQLConnection(_context);

                var result = conn.Connect("SELECT * FROM ATEEI_SRTP_RG_N_SERIE_RECURSO where N_SERIE = '" + serial + "' and SEQUENCIA = " + sequence + " and ORDEM = " + docEntry + "");

                if (result.HasRows)
                {
                    ret = true;
                }
                else
                {
                    ret = false;
                }
                result.Close();
            }
            catch (Exception e)
            {
                ret = true;
            }
            return ret;
        }
        public bool VerifySerialOnlineInspect(int id)
        {
            bool ret = false;
            try
            {
                SQLConnection conn = new SQLConnection(_context);
                var result = conn.Connect("SELECT id FROM ATEEI_SRTP_ASSEMBLY_WORKORDER where ID_N_SERIE_RECURSO =" + id);
                if (result.HasRows)
                {
                    ret = true;
                }
                else
                {
                    ret = false;
                }

                result.Close();
            }
            catch (Exception e)
            {
                ret = true;
            }

            return ret;

        }
        public string VerifyUserFunction()
        {
            string ret = "M";

            User userInfo2 = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));

            string userSession = userInfo2.EmpID.ToString();
            SQLConnection conn = new SQLConnection(_context);
            System.Data.Common.DbDataReader data = conn.Connect("select * from HTM1 where empID =" + userSession);
            while (data.Read())
            {
                if (data["role"].ToString() == "L")
                {
                    ret = data["role"].ToString();
                }
            }
            data.Close();
            return ret;
        }
    }
}

