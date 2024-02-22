using CourseApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Data
{
    internal class StudentDao
    {
        public int Insert(Student student)
        {
            using (SqlConnection conntection = new SqlConnection(ConnectionStrings.LOCAL))
            {
                string query = "insert into Students (Fullname,Point,GroupId) values (@fullname,@point,@groupId)";
                conntection.Open();
                using (SqlCommand cmd = new SqlCommand(query, conntection))
                {
                    cmd.Parameters.AddWithValue("@fullname", student.Fullname);
                    cmd.Parameters.AddWithValue("@point", student.Point);
                    cmd.Parameters.AddWithValue("@groupId", student.GroupId);

                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStrings.LOCAL))
            {
                string query = "delete from Students where id=@id";

                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
