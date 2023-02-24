using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddFormController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AddFormController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("add")]
        public string add(AddForm addForm)
        {
            SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("API").ToString());
            SqlCommand cmd = new SqlCommand("INSERT INTO api_demo(name,email,password) " +
                "VALUES(' " + addForm.name.Trim() + "' , '" + addForm.email.Trim() + "' , '" + addForm.password.Trim() + "') ", conn);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();

            if (i > 0)
            {
                return "Data inserted";
            }

            else
            {
                return "ERROR";
            }
        }
    }
}
