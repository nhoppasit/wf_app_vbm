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

                        { "@val_parametername", new ParameterStructure_MSSQL("@val_parametername", SqlDbType.VarChar, pet.PetName) },

                    };

                    Dictionary<string, ParameterStructure_MSSQL> Output = new Dictionary<string, ParameterStructure_MSSQL>()
                    {
                        { "@RowCount", new ParameterStructure_MYSQL("@RowCount", MySqlDbType.Int32)},
                        { "@MessageResult", new ParameterStructure_MYSQL("@MessageResult", MySqlDbType.VarChar, null, 200) },
                         { "@CodeValue", new ParameterStructure_MYSQL("@CodeValue", MySqlDbType.Int32) }
                    };

                    ResultTypeDS result = new ResultTypeDS();
                    return JsonConvert.SerializeObject(result);
                }
            } catch (Exception ex) {
                return JsonConvert.SerializeObject(new { Code = -2, Message = ex.Message });
            }
        }
    }

}
