﻿using System;
using System.Data;
using System.Data.SqlClient;
using GuviCRMSuite.Properties;
using System.Collections.Generic;
using DACLibrary.HelperClass;

namespace GuviCRMSuite.DACLibrary
{
    public class SchedulerDAC
    {
        static SqlConnection connection = null;
        static SqlDataReader dataReader = null;
        static SqlCommand cmd = null;

        public static bool AddNewEvents(SchedulerAddEvent schedulerPropertyObj)
        {
            bool isAdded = false; int affectedRows = 0;
            try
            {
                using (connection = new SqlConnection(GetConnectionString.GetConnectionDetails()))
                {
                    using (cmd = new SqlCommand("AddNewEvent", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@goaltitle", SqlDbType.VarChar).Value = schedulerPropertyObj.GoalTitle;
                        cmd.Parameters.AddWithValue("@goals", SqlDbType.VarChar).Value = schedulerPropertyObj.goals;
                        cmd.Parameters.AddWithValue("@createdby", SqlDbType.VarChar).Value = schedulerPropertyObj.CreatedBy;
                        cmd.Parameters.AddWithValue("@modifiedby", SqlDbType.VarChar).Value = schedulerPropertyObj.ModifiedBy;
                        cmd.Parameters.AddWithValue("@event_id", SqlDbType.VarChar).Value = schedulerPropertyObj.EventID;
                        cmd.Parameters.AddWithValue("@eventstartdttm", SqlDbType.DateTime).Value = schedulerPropertyObj.EventStartDTTM;
                        cmd.Parameters.AddWithValue("@eventenddttm", SqlDbType.DateTime).Value = schedulerPropertyObj.EventEndDTTM;

                        connection.Open();
                        affectedRows = cmd.ExecuteNonQuery();

                        if (affectedRows > 0)
                            isAdded = true;
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            return isAdded;
        }

        public static List<SchedulerCalenderEventData> GetEventDetailsForCalender()
        {
            List<SchedulerCalenderEventData> lstCalenderData = new List<SchedulerCalenderEventData>();
            SchedulerCalenderEventData calenderData = null;
            try
            {
                using (connection = new SqlConnection(GetConnectionString.GetConnectionDetails()))
                {
                    using (cmd = new SqlCommand("select goal_id id, GoalTitle title, EventstartDTTM start, eventenddttm [end] from goal inner join scheduler on goal.goal_id = Scheduler.GoalId where Scheduler.status = 'A' and goal.status = 'A'", connection))
                    {
                        connection.Open();
                        dataReader = cmd.ExecuteReader();
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                calenderData = new SchedulerCalenderEventData();
                                calenderData.Title = dataReader["title"].ToString();
                                calenderData.Start = Convert.ToString(dataReader["start"]);
                                calenderData.End = Convert.ToString(dataReader["end"]);

                                lstCalenderData.Add(calenderData);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            return lstCalenderData;
        }

        public static List<SchedulerCalenderEventData> GetAEventDetailForCalender(string goalId)
        {
            List<SchedulerCalenderEventData> lstCalenderData = new List<SchedulerCalenderEventData>();
            SchedulerCalenderEventData calenderData = null;
            try
            {
                using (connection = new SqlConnection(GetConnectionString.GetConnectionDetails()))
                {
                    using (cmd = new SqlCommand("select goal_id id,GoalTitle title, EventstartDTTM start, eventenddttm [end] from goal inner join scheduler on goal.goal_id = Scheduler.GoalId where Scheduler.sch_id = " + goalId + " and status = 'A' ", connection))
                    {
                        connection.Open();
                        dataReader = cmd.ExecuteReader();
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                calenderData = new SchedulerCalenderEventData();
                                calenderData.Title = dataReader["title"].ToString();
                                calenderData.Start = Convert.ToString(dataReader["start"]);
                                calenderData.End = Convert.ToString(dataReader["end"]);

                                lstCalenderData.Add(calenderData);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            return lstCalenderData;
        }

        public static bool DeleteEvent(string id)
        {
            bool isAdded = false;
            int affectedRows = 0;
            try
            {
                using (connection = new SqlConnection(GetConnectionString.GetConnectionDetails()))
                {
                    using (cmd = new SqlCommand("DeleteEvent", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@goalid", SqlDbType.VarChar).Value = id;
                        connection.Open();

                        affectedRows = cmd.ExecuteNonQuery();

                        if (affectedRows > 0)
                            isAdded = true;
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            return isAdded;
        }

        public static bool UpdateEvent(SchedulerAddEvent schedulerPropertyObj)
        {
            bool isAdded = false; int affectedRows = 0;
            try
            {
                using (connection = new SqlConnection(GetConnectionString.GetConnectionDetails()))
                {
                    using (cmd = new SqlCommand("updateevent", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@goaltitle", SqlDbType.VarChar).Value = schedulerPropertyObj.GoalTitle;
                        cmd.Parameters.AddWithValue("@goals", SqlDbType.VarChar).Value = schedulerPropertyObj.goals;
                        cmd.Parameters.AddWithValue("@createdby", SqlDbType.VarChar).Value = schedulerPropertyObj.CreatedBy;
                        cmd.Parameters.AddWithValue("@modifiedby", SqlDbType.VarChar).Value = schedulerPropertyObj.ModifiedBy;
                        cmd.Parameters.AddWithValue("@eventstartdttm", SqlDbType.DateTime).Value = schedulerPropertyObj.EventStartDTTM;
                        cmd.Parameters.AddWithValue("@eventenddttm", SqlDbType.DateTime).Value = schedulerPropertyObj.EventEndDTTM;
                        cmd.Parameters.AddWithValue("@goalid", SqlDbType.VarChar).Value = schedulerPropertyObj.GoalId;

                        connection.Open();
                        affectedRows = cmd.ExecuteNonQuery();

                        if (affectedRows > 0)
                            isAdded = true;
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            return isAdded;
        }
    }
}
