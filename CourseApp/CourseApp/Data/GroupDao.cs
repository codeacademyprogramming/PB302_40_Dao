using CourseApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Data
{
    internal class GroupDao
    {
        public int Insert(Group group)
        {
            var result = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionStrings.LOCAL))
            {
                connection.Open();
                string query = "insert into Groups (No,Limit) values (@no,@limit)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@no", group.No);
                    cmd.Parameters.AddWithValue("@limit", group.Limit);
                    result=cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        public int Update(Group group)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStrings.LOCAL))
            {
                string query = "update Groups set no=@no, limit=@limit where id=@id";

                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", group.Id);
                    cmd.Parameters.AddWithValue("@no", group.No);
                    cmd.Parameters.AddWithValue("@limit", group.Limit);

                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStrings.LOCAL))
            {
                string query = "delete from Groups where id=@id";

                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public Group GetById(int id)
        {
            Group group = null;
            string connectionStr = ConnectionStrings.LOCAL;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "select TOP(1) * from Groups where Id=@id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows) return null;
                    while (reader.Read())
                    {
                        group = new Group();
                        group.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        group.No = reader.GetString(reader.GetOrdinal("No"));
                        group.Limit = reader.GetByte(reader.GetOrdinal("Limit"));
                    }
                }
            }
            return group;
        }
        public List<Group> GetAll()
        {
            List<Group> groups = new List<Group>();
            using (SqlConnection connection = new SqlConnection(ConnectionStrings.LOCAL))
            {
                connection.Open();
                string query = "select Id, No, Limit,(select count(*) from Students where GroupId=Groups.Id) from Groups";
                SqlCommand cmd = new SqlCommand(query, connection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Group grp = new Group
                        {

                            Id = reader.GetInt32(0),
                            No = reader.GetString(1),
                            Limit = reader.GetByte(2),
                            StudentsCount = reader.GetInt32(3)
                        };
                        groups.Add(grp);
                    }
                }
            }
            return groups;
        }
        public bool IsExists(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStrings.LOCAL))
            {
                string query = "select id from Groups where id=@id";
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }
    }
}
