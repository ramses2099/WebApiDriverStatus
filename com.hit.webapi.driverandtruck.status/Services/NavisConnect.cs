using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using com.hit.webapi.hpu.dph.ArgoBasicService;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace com.hit.webapi.driverandtruck.status.Services
{
    public class NavisConnect
    {

        private const String XML_DPH_PERMISSON_QUERY = @"<hpu>
                                                        <entities>
                                                            <units>
                                                                <unit-identity id=""{0}"" type=""CONTAINERIZED""/>
	                                                        </units>
                                                        </entities>
                                                        <flags>
		                                                      <flag hold-perm-id=""DPH_PERMISO"" action=""{1}"" note=""{2}""/>
                                                        </flags>
                                                       </hpu>";

        //
        private const String XML_DPH_HOLD_QUERY = @"<hpu>
                                                        <entities>
                                                            <units>
                                                                <unit-identity id=""{0}"" type=""CONTAINERIZED""/>
	                                                        </units>
                                                        </entities>
                                                        <flags>
		                                                      <flag hold-perm-id=""DPH_HOLD"" action=""{1}"" note=""{2}""/>
                                                        </flags>
                                                    </hpu>";

        //        
        public NavisConnect()
        {


        }
        //
        private string User { get { return System.Web.Configuration.WebConfigurationManager.AppSettings["User"].ToString(); } }
        //
        private string Password { get { return System.Web.Configuration.WebConfigurationManager.AppSettings["Password"].ToString(); } }
        //
        private string ConnectionString { get { return System.Web.Configuration.WebConfigurationManager.ConnectionStrings["N4EDIConnectionString"].ToString(); } }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="UnitNbr">Numero de Unidad</param>
        /// <param name="Action">Accion ADD OR REELESE</param>
        /// <param name="Nota">Nota o Comentario</param>
        /// <returns>Execute Generic Invoke DPH_HOLD</returns>
        public string executeGenericInvokeDPH_HOLD(String UnitNbr, String Action, String Nota)
        {
            /*--
            string myXml = string.Format(XML_DPH_HOLD_QUERY, UnitNbr, Action, Nota);

            string rs = string.Empty;
            try
            {
                genericInvoke arg = new genericInvoke();
                ScopeCoordinateIdsWsType scope = new ScopeCoordinateIdsWsType();
                scope.operatorId = "HIT";
                scope.complexId = "SANTO_DOMINGO";
                scope.facilityId = "HAINA_TERMINAL";
                scope.yardId = "HITYRD";

                arg.scopeCoordinateIdsWsType = scope;
                arg.xmlDoc = myXml;

                //
                ExtendedGenericWebservice n4WebService = new ExtendedGenericWebservice();

                byte[] bcred = Encoding.ASCII.GetBytes(User + ":" + Password);

                string b64cred = Convert.ToBase64String(bcred);

                n4WebService.SetRequestHeader("Authorization", "Basic " + b64cred);
                n4WebService.Timeout = -1;

                genericInvokeResponse response = n4WebService.genericInvoke(arg);

                ResponseType commonResponse = response.genericInvokeResponse1.commonResponse;
                string status = commonResponse.Status;


                if (ResponEstatus.ERRORS.Equals(status))
                {
                    rs = "ERROR";
                }
                else
                {

                    String xml = response.genericInvokeResponse1.responsePayLoad;
                    if (!String.IsNullOrEmpty(xml))
                    {
                        rs = "OK";
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            return rs;
            --*/

            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UnitNbr">Numero de Unidad</param>
        /// <param name="Action">Accion ADD OR REELESE</param>
        /// <param name="Nota">Nota o Comentario</param>
        /// <returns>Execute GenericInvoke DPH_PERMISSON</returns>
        public string executeGenericInvokeDPH_PERMISSON(String UnitNbr, String Action, String Nota)
        {
            /*--
            string myXml = string.Format(XML_DPH_PERMISSON_QUERY, UnitNbr, Action, Nota);

            string rs = string.Empty;
            try
            {
                genericInvoke arg = new genericInvoke();
                ScopeCoordinateIdsWsType scope = new ScopeCoordinateIdsWsType();
                scope.operatorId = "HIT";
                scope.complexId = "SANTO_DOMINGO";
                scope.facilityId = "HAINA_TERMINAL";
                scope.yardId = "HITYRD";

                arg.scopeCoordinateIdsWsType = scope;
                arg.xmlDoc = myXml;

                //
                ExtendedGenericWebservice n4WebService = new ExtendedGenericWebservice();

                byte[] bcred = Encoding.ASCII.GetBytes(User + ":" + Password);

                string b64cred = Convert.ToBase64String(bcred);

                n4WebService.SetRequestHeader("Authorization", "Basic " + b64cred);
                n4WebService.Timeout = -1;

                genericInvokeResponse response = n4WebService.genericInvoke(arg);

                ResponseType commonResponse = response.genericInvokeResponse1.commonResponse;
                string status = commonResponse.Status;

                MessageType[] messageCollection = commonResponse.MessageCollector;

                StringBuilder message = new StringBuilder();
                foreach (MessageType mType in messageCollection)
                {
                    message.AppendLine(mType.Message);
                }
                
                //Status                
                if (ResponEstatus.OK.Equals(status))
                {
                    String msg = String.Format("La Unidad {0} Aplico {1} Correctamente", UnitNbr, Action);
                    //
                    rs = String.Format("OK|{0}", msg);
                    //
                    executeTransaction(UnitNbr, Action, Nota, "COMPLETADO", "OK", msg);
                }
                else if (ResponEstatus.INFO.Equals(status))
                {
                    rs = String.Format("INFO|{0}", message.ToString());
                    //
                    executeTransaction(UnitNbr, Action, Nota, "PENDIENTE", "INFO", message.ToString());
                }
                else if (ResponEstatus.WARNINGS.Equals(status))
                {
                    rs = String.Format("WARNINGS|{0}", message.ToString());
                    //
                    executeTransaction(UnitNbr, Action, Nota, "PENDIENTE", "WARNINGS", message.ToString());
                }
                else if (ResponEstatus.ERRORS.Equals(status))
                {
                    rs = String.Format("ERRROS|{0}", message.ToString());
                    //
                    executeTransaction(UnitNbr, Action, Nota, "PENDIENTE", "ERRROS", message.ToString());
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
            return rs;
            --*/

            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        private void executeTransaction(String UnitNbr, String Action, String Nota, String Estatus, String EstatusNavis, String MensajeeNavis)
        {

            try
            {


                using (SqlConnection connetion = new SqlConnection(ConnectionString))
                {

                    if (connetion.State == ConnectionState.Closed)
                    {
                        connetion.Open();
                    }

                    using (SqlCommand _DbCommand = new SqlCommand())
                    {
                        _DbCommand.Connection = connetion;

                        _DbCommand.CommandType = CommandType.StoredProcedure;

                        _DbCommand.CommandText = "[dbo].[CreateTransaccionWebApiHPUDPH]";

                        _DbCommand.Parameters.Add(new SqlParameter() { ParameterName = "@UnitNbr", SqlDbType = SqlDbType.VarChar, Value = UnitNbr });

                        _DbCommand.Parameters.Add(new SqlParameter() { ParameterName = "@Action", SqlDbType = SqlDbType.VarChar, Value = Action });

                        _DbCommand.Parameters.Add(new SqlParameter() { ParameterName = "@Nota", SqlDbType = SqlDbType.VarChar, Value = Nota });

                        _DbCommand.Parameters.Add(new SqlParameter() { ParameterName = "@Estatus", SqlDbType = SqlDbType.VarChar, Value = Estatus });

                        _DbCommand.Parameters.Add(new SqlParameter() { ParameterName = "@EstatusNavis", SqlDbType = SqlDbType.VarChar, Value = EstatusNavis });

                        _DbCommand.Parameters.Add(new SqlParameter() { ParameterName = "@MensajeeNavis", SqlDbType = SqlDbType.VarChar, Value = MensajeeNavis });
                        
                        if (Estatus.Equals("COMPLETADO"))
                        {
                            _DbCommand.Parameters.Add(new SqlParameter() { ParameterName = "@FechaActualizacion", SqlDbType = SqlDbType.DateTime, Value = DateTime.Now });

                        }
                        else
                        {
                            _DbCommand.Parameters.Add(new SqlParameter() { ParameterName = "@FechaActualizacion", SqlDbType = SqlDbType.DateTime, Value = DBNull.Value });

                        }

                        _DbCommand.ExecuteNonQuery();
                    }

                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }




    }
}