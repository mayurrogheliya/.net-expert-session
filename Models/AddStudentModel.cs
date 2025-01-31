using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace expertsession.Models
{
    public class AddStudentModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please enter age")]
        public int age {get; set;}

        /*
         this method is use full when you action on database wihtout refresh the page
        this method can not refresh the page.
         */

        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentDatabase;Integrated Security=True;");

        public List<AddStudentModel> getData(string id)
        {
            List<AddStudentModel> lstStu = new List<AddStudentModel>();
            string query = "select * from TestNewStudent";
            if (!string.IsNullOrEmpty(id))
            {
                query = "select *  from TestNewStudent where Id = " + id;
            }
            SqlDataAdapter adt = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows) { 
            lstStu.Add(new AddStudentModel
            {
                Id = Convert.ToInt32(dr["id"].ToString()),
                name = dr["name"].ToString(),
                email = dr["email"].ToString(),
                age = Convert.ToInt32(dr["age"].ToString()),
            });
            }
            return lstStu;
        }

        public bool insert(AddStudentModel student)
        {
            if (student.name != string.Empty && student.email != string.Empty && student.age != int.MinValue) {
                SqlCommand cmd = new SqlCommand("insert into TestNewStudent values(@Name,@Email,@Age)", con);
                cmd.Parameters.AddWithValue("@Name", student.name);
                cmd.Parameters.AddWithValue("@Email", student.email);
                cmd.Parameters.AddWithValue("@Age", student.age);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i >= 1)
                {
                    return true;
                }
            }
            con.Close();
            return false;
        }

        public bool update(AddStudentModel student)
        {
                SqlCommand cmd = new SqlCommand("update TestNewStudent set name=@Name, email=@Email, age=@Age where Id=@id", con);
                cmd.Parameters.AddWithValue("@Name", student.name);
                cmd.Parameters.AddWithValue("@Email", student.email);
                cmd.Parameters.AddWithValue("@Age", student.age);
                cmd.Parameters.AddWithValue("@id", student.Id);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i >= 1)
                {
                    return true;
                }
                con.Close();
            return false;
        }

        public bool delete(AddStudentModel student) { 
            SqlCommand cmd = new SqlCommand("delete TestNewStudent where Id=@id", con);
            cmd.Parameters.AddWithValue("@id", student.Id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1) { 
                return true;
            }
            con.Close();
            return false;
        }
    }
}
