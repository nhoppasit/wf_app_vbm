using DB_Management.Generic;
using DB_Management.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;

namespace AccelerometerDatabase {
    public class MeasurementInfo {

        private readonly string _connectionString;

        public MeasurementInfo(string connectionString) {
            _connectionString = connectionString;
        }

        public string AddNew(Models.MeasurementInfoModel measurementInfo) {
            try {
                using (GenericManagement_MSSQL db = new GenericManagement_MSSQL()) {
                    db.ConnectionString = _connectionString;
                    Dictionary<string, ParameterStructure_MSSQL> Inputs = new Dictionary<string, ParameterStructure_MSSQL>(){

                        { "@val_parametername", new ParameterStructure_MSSQL("@val_parametername", SqlDbType.NVarChar, measurementInfo.??) },

                    };

                    Dictionary<string, ParameterStructure_MSSQL> Output = new Dictionary<string, ParameterStructure_MSSQL>()
                    {
                        { "@RowCount", new ParameterStructure_MSSQL("@RowCount", SqlDbType.Int)},
                        { "@MessageResult", new ParameterStructure_MSSQL("@MessageResult", SqlDbType.NVarChar, null, 200) },
                         { "@CodeValue", new ParameterStructure_MSSQL("@CodeValue", SqlDbType.Int) }
                    };

                    ResultTypeDS result = new ResultTypeDS();
                    result.DataSetResult = db.ExecuteToDataSet("sp_Pet_AddNew", Inputs, ref Output);
                    int rowCount = Convert.ToInt32(Output["@RowCount"].dbValue);
                    result.Code = Convert.ToInt32(Output["@CodeValue"].dbValue);
                    result.RowCount = rowCount;
                    result.Message = Output["@MessageResult"].dbValue.ToString();
                    result.Flag = Convert.ToInt32(Output["@CodeValue"].dbValue) == 0 && rowCount > 0 ? true : false;
                    return JsonConvert.SerializeObject(result);
                }
            } catch (Exception ex) {
                return JsonConvert.SerializeObject(new { Code = -2, Message = ex.Message });
            }
        }
    }

}
