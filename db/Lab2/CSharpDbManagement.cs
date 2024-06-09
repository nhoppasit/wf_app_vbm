using DB_Management.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using PetTagWeb_ws.Models;
using PetTagWeb_ws.Services;

namespace PetTagWeb_ws.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IUserService _userService;

        private IConfiguration _config;
        public PetsController(IConfiguration Configuration)
        {
            _config = Configuration;
        }

        [HttpPost("Add")]
        [Authorize]
        public string AddPet([FromBody] Pet pet)
        {
            try
            {
                using (GenericManagement_MYSQL db = new GenericManagement_MYSQL())
                {
                    Dictionary<string, ParameterStructure_MYSQL> Inputs = new Dictionary<string, ParameterStructure_MYSQL>()
                    {
                        { "@val_petName", new ParameterStructure_MYSQL("@val_petName", MySqlDbType.VarChar, pet.PetName) },
                        { "@val_petTypeID", new ParameterStructure_MYSQL("@val_petTypeID", MySqlDbType.Int32, pet.PetTypeID) },
                        { "@val_petBreedID1", new ParameterStructure_MYSQL("@val_petBreedID1", MySqlDbType.VarChar, pet.PetBreedID1) },
                        { "@val_petBreedID2", new ParameterStructure_MYSQL("@val_petBreedID2", MySqlDbType.VarChar, pet.PetBreedID2) },
                        { "@val_petColor", new ParameterStructure_MYSQL("@val_petColor", MySqlDbType.VarChar, pet.PetColor) },
                        { "@val_petGender", new ParameterStructure_MYSQL("@val_petGender", MySqlDbType.VarChar, pet.PetGender) },
                        { "@val_petDateOfBirth", new ParameterStructure_MYSQL("@val_petDateOfBirth", MySqlDbType.DateTime, pet.PetDateOfBirth) },
                        { "@val_petWeight", new ParameterStructure_MYSQL("@val_petWeight", MySqlDbType.Decimal, pet.PetWeight) },
                        { "@val_petDescription", new ParameterStructure_MYSQL("@val_petDescription", MySqlDbType.VarChar, pet.PetDescription) },
                        { "@val_petCollarColor", new ParameterStructure_MYSQL("@val_petCollarColor", MySqlDbType.VarChar, pet.PetCollarColor) },
                        { "@val_status_system", new ParameterStructure_MYSQL("@val_status_system", MySqlDbType.Int32, pet.StatusSystem) },
                        { "@val_CreatedBy", new ParameterStructure_MYSQL("@val_CreatedBy", MySqlDbType.Int32, pet.CreatedBy) },
                        { "@val_CreatedDate", new ParameterStructure_MYSQL("@val_CreatedDate", MySqlDbType.DateTime, pet.CreatedDate) },
                        { "@val_ModifiedBy", new ParameterStructure_MYSQL("@val_ModifiedBy", MySqlDbType.Int32, pet.ModifiedBy) },
                        { "@val_ModifiedDate", new ParameterStructure_MYSQL("@val_ModifiedDate", MySqlDbType.DateTime, pet.ModifiedDate) },
                        { "@val_petUserID", new ParameterStructure_MYSQL("@val_petUserID", MySqlDbType.Int32, pet.PetUserID) },
                        { "@CodeValue", new ParameterStructure_MYSQL("@CodeValue", MySqlDbType.Int32) },
                        { "@RowCount", new ParameterStructure_MYSQL("@RowCount", MySqlDbType.Int32) },
                        { "@MessageResult", new ParameterStructure_MYSQL("@MessageResult", MySqlDbType.VarChar, null, 1000) }
                    };
                    Dictionary<string, ParameterStructure_MYSQL> Output = new Dictionary<string, ParameterStructure_MYSQL>()
                    {
                        { "@RowCount", new ParameterStructure_MYSQL("@RowCount", MySqlDbType.Int32)},
                        { "@MessageResult", new ParameterStructure_MYSQL("@MessageResult", MySqlDbType.VarChar, null, 200) },
                         { "@CodeValue", new ParameterStructure_MYSQL("@CodeValue", MySqlDbType.Int32) }
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
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { Code = -2, Message = ex.Message });
            }
        }

        [HttpPost("GetByID")]
        [Authorize]
        public string GetPetByID(int petID)
        {
            try
            {
                using (GenericManagement_MYSQL db = new GenericManagement_MYSQL())
                {
                    Dictionary<string, ParameterStructure_MYSQL> Inputs = new Dictionary<string, ParameterStructure_MYSQL>()
                    {
                        { "@val_petID", new ParameterStructure_MYSQL("@val_petID", MySqlDbType.Int32, petID) }
                    };

                    Dictionary<string, ParameterStructure_MYSQL> Output = new Dictionary<string, ParameterStructure_MYSQL>()
                    {
                        { "@RowCount", new ParameterStructure_MYSQL("@RowCount", MySqlDbType.Int32)},
                        { "@MessageResult", new ParameterStructure_MYSQL("@MessageResult", MySqlDbType.VarChar, null, 200) },
                        { "@CodeValue", new ParameterStructure_MYSQL("@CodeValue", MySqlDbType.Int32) }
                    };

                    ResultTypeDS result = new ResultTypeDS();
                    result.DataSetResult = db.ExecuteToDataSet("sp_Pet_GetByID", Inputs, ref Output);

                    // Extract output parameters from Output dictionary
                    int rowCount = Convert.ToInt32(Output["@RowCount"].dbValue);
                    result.Code = Convert.ToInt32(Output["@CodeValue"].dbValue);
                    result.RowCount = rowCount;
                    result.Message = Output["@MessageResult"].dbValue.ToString();
                    result.Flag = result.Code == 0 && rowCount > 0;

                    return JsonConvert.SerializeObject(result);
                }
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { Code = -2, Message = ex.Message });
            }
        }


    }
}

