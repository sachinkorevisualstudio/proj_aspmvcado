using Microsoft.Extensions.Configuration;
using proj_aspmvcado.Models;
using System.Data.SqlClient;

namespace proj_aspmvcado.Services
{
    public class StudentServices :IStudentService    //Istudentservice added
    {
        public string Constr { get; set; }
        public IConfiguration _configuration;
        public SqlConnection con;
        public StudentServices(IConfiguration configuration)
        {
            _configuration = configuration;
            Constr = _configuration.GetConnectionString("DBconnection");
        }

        public List<Students> GetstudentsRecord()
        {
            List<Students> studentlstx=new List<Students>();
            try
            {
                using (con=new SqlConnection(Constr))
                {
                    con.Open();
                    var cmd=new SqlCommand("sp_getstudrecords",con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //or if it was sql query 
                  //  var cmd = new SqlCommand("select * from tblstudent", con);
                  // cmd.CommandType = System.Data.CommandType.Text;

                    SqlDataReader readerx = cmd.ExecuteReader();
                    while (readerx.Read())
                    {
                        Students std = new Students();
                        std.Id = Convert.ToInt32(readerx["Id"]);
                        std.Name = readerx["Name"].ToString();  
                        studentlstx.Add(std);
                    }



                }
                return studentlstx.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
   public interface IStudentService     //interface
    {
        public List<Students> GetstudentsRecord();//signature
    }
}
