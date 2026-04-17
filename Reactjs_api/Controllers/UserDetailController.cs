using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Reactjs_api.Model;

namespace Reactjs_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserDetailController : ControllerBase
    {
        private readonly IConfiguration _config;

        public UserDetailController(IConfiguration config)
        {
            _config = config;
        }

        // ✅ GET ALL
        [HttpGet]
        public IActionResult GetUsers()
        {
            List<object> users = new List<object>();
            string connStr = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM UserDetail";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new
                    {
                        userId = reader["id"],
                        userName = reader["username"],
                        userEmailId = reader["useremailid"]
                    });
                }
            }

            return Ok(users);
        }

        // ✅ INSERT
        [HttpPost]
        public IActionResult AddUser([FromBody] UserDetail user)
        {
            string connStr = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "INSERT INTO UserDetail (username, useremailid, password) VALUES (@username, @useremailid, @password)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@username", user.UserName);
                cmd.Parameters.AddWithValue("@useremailid", user.UserEmailId);
                cmd.Parameters.AddWithValue("@password", user.Password);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            return Ok("Inserted Successfully");
        }

        // ✅ UPDATE
        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserDetail user)
        {
            string connStr = _config.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "UPDATE UserDetail SET username=@username, useremailid=@useremailid, password=@password WHERE id=@id";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", user.Id);
                cmd.Parameters.AddWithValue("@username", user.UserName);
                cmd.Parameters.AddWithValue("@useremailid", user.UserEmailId);
                cmd.Parameters.AddWithValue("@password", user.Password);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            return Ok("Updated Successfully");
        }
    }
}




   

  
     