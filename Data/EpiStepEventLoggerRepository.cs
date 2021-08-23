using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace NLogApi.Data
{
    public class EpiStepEventLoggerRepository : IEpiStepEventLoggerRepository
    {
        private IConfiguration _config;

        public EpiStepEventLoggerRepository(IConfiguration config)
        {
            _config = config;
        }

        public bool InsertEpiStepLog(EpiplexStep epiplexStep)
        {
            string connectionString = _config.GetConnectionString("EpiEventConnectionString");
            if (string.IsNullOrEmpty(connectionString))
            {
                return false;
            }


            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;

                    command.CommandText = @"INSERT INTO [dbo].[EpiplexSteps]
                                           ([longdate],[machinename],[username],[logtype],[message],[Event],[ControlName],[ControlType],[DialogName],[ControlValue],[applicationname],[StepTimeStamp],[TabID])
			                                VALUES
                                           (@longdate,@machinename,@username,@logtype,@message,@Event,@ControlName,@ControlType,@DialogName,@ControlValue,@applicationname,@StepTimeStamp,@TabID)";

                    command.Parameters.Add("@longdate", SqlDbType.NVarChar, int.MaxValue);
                    command.Parameters.Add("@machinename", SqlDbType.NVarChar, int.MaxValue);
                    command.Parameters.Add("@username", SqlDbType.NVarChar, int.MaxValue);
                    command.Parameters.Add("@logtype", SqlDbType.NVarChar, int.MaxValue);
                    command.Parameters.Add("@message", SqlDbType.NVarChar, int.MaxValue);
                    command.Parameters.Add("@Event", SqlDbType.NVarChar, int.MaxValue);
                    command.Parameters.Add("@ControlName", SqlDbType.NVarChar, int.MaxValue);
                    command.Parameters.Add("@ControlType", SqlDbType.NVarChar, int.MaxValue);
                    command.Parameters.Add("@DialogName", SqlDbType.NVarChar, int.MaxValue);
                    command.Parameters.Add("@ControlValue", SqlDbType.NVarChar, int.MaxValue);
                    command.Parameters.Add("@applicationname", SqlDbType.NVarChar, int.MaxValue);
                    command.Parameters.Add("@StepTimeStamp", SqlDbType.NVarChar, int.MaxValue);
                    command.Parameters.Add("@TabID", SqlDbType.NVarChar, int.MaxValue);

                    command.Parameters["@longdate"].Value = epiplexStep.Longdate;
                    command.Parameters["@machinename"].Value = epiplexStep.Machinename;
                    command.Parameters["@username"].Value = epiplexStep.UserName;
                    command.Parameters["@logtype"].Value = epiplexStep.LogType;
                    command.Parameters["@message"].Value = epiplexStep.Message;
                    command.Parameters["@Event"].Value = epiplexStep.Event;
                    command.Parameters["@ControlName"].Value = epiplexStep.ControlName;
                    command.Parameters["@ControlType"].Value = epiplexStep.ControlType;
                    command.Parameters["@DialogName"].Value = epiplexStep.DialogName;
                    command.Parameters["@ControlValue"].Value = epiplexStep.ControlValue;
                    command.Parameters["@applicationname"].Value = epiplexStep.ApplicationName;
                    command.Parameters["@StepTimeStamp"].Value = epiplexStep.StepTimeStamp;
                    command.Parameters["@TabID"].Value = epiplexStep.TabID;

                    result =command.ExecuteNonQuery();
                }
            }

            return result>0;
        }

        public bool InsertUniqueStepLog(UniqueStep uniqueStep)
        {
            string connectionString = _config.GetConnectionString("EpiEventConnectionString");
            if (string.IsNullOrEmpty(connectionString))
            {
                return false;
            }


            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;

                    command.CommandText = @"INSERT INTO [dbo].[UniqueSteps]
                                           ([longdate],[machinename],[username],[logtype],[message],[Event],[ControlName],[ControlType],[DialogName],[ControlValue],[applicationname],[StepTimeStamp],[TabID])
			                                VALUES
                                           (@longdate,@machinename,@username,@logtype,@message,@Event,@ControlName,@ControlType,@DialogName,@ControlValue,@applicationname,@StepTimeStamp,@TabID)";

                    command.Parameters.Add("@longdate", SqlDbType.NVarChar, int.MaxValue);
                    command.Parameters.Add("@machinename", SqlDbType.NVarChar, int.MaxValue);
                    command.Parameters.Add("@username", SqlDbType.NVarChar, int.MaxValue);
                    command.Parameters.Add("@logtype", SqlDbType.NVarChar, int.MaxValue);
                    command.Parameters.Add("@message", SqlDbType.NVarChar, int.MaxValue);
                    command.Parameters.Add("@Event", SqlDbType.NVarChar, int.MaxValue);
                    command.Parameters.Add("@ControlName", SqlDbType.NVarChar, int.MaxValue);
                    command.Parameters.Add("@ControlType", SqlDbType.NVarChar, int.MaxValue);
                    command.Parameters.Add("@DialogName", SqlDbType.NVarChar, int.MaxValue);
                    command.Parameters.Add("@ControlValue", SqlDbType.NVarChar, int.MaxValue);
                    command.Parameters.Add("@applicationname", SqlDbType.NVarChar, int.MaxValue);
                    command.Parameters.Add("@StepTimeStamp", SqlDbType.NVarChar, int.MaxValue);
                    command.Parameters.Add("@TabID", SqlDbType.NVarChar, int.MaxValue);

                    command.Parameters["@longdate"].Value = uniqueStep.Longdate;
                    command.Parameters["@machinename"].Value = uniqueStep.Machinename;
                    command.Parameters["@username"].Value = uniqueStep.UserName;
                    command.Parameters["@logtype"].Value = uniqueStep.LogType;
                    command.Parameters["@message"].Value = uniqueStep.Message;
                    command.Parameters["@Event"].Value = uniqueStep.Event;
                    command.Parameters["@ControlName"].Value = uniqueStep.ControlName;
                    command.Parameters["@ControlType"].Value = uniqueStep.ControlType;
                    command.Parameters["@DialogName"].Value = uniqueStep.DialogName;
                    command.Parameters["@ControlValue"].Value = uniqueStep.ControlValue;
                    command.Parameters["@applicationname"].Value = uniqueStep.ApplicationName;
                    command.Parameters["@StepTimeStamp"].Value = uniqueStep.StepTimeStamp;
                    command.Parameters["@TabID"].Value = uniqueStep.TabID;

                    result = command.ExecuteNonQuery();
                }
            }

            return result > 0;
        }
    }
}
