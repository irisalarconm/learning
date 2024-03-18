using System.Data.SqlClient;

namespace CrudWindowsFormsADONET
{
    internal class PeopleDb
    {
        private string connectionString
            = "Data Source=DESKTOP-MUVRQ2S; Initial Catalog=CrudWF;" +
            "user=sa;password=1234";

        public bool OkConnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch
            {
                return false;
            }
            return true;
            
        }

        public List<People> Get()
        {
            List<People> people = new List<People>();

            string query = "Select id,name,age from people";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //enviar el comando
                SqlCommand command = new SqlCommand(query, connection);
 
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader(); //aquí lo ejecuta

      
                    while (reader.Read()) //uno por uno analizando
                    {
                    People oPeople = new People();

                    oPeople.Id = reader.GetInt32(0);
                    oPeople.Name = reader.GetString(1);
                    oPeople.Age = reader.GetInt32(2);

                    people.Add(oPeople);
                    }

                    reader.Close();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay error" + ex.Message);
                }
            }
            return people;
        }

        public People Get(int? Id)
        {

            string query = "Select id,name,age from people where id=@id"; 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader(); //aquí lo ejecuta

                    reader.Read();
                        People oPeople = new People();

                        oPeople.Id = reader.GetInt32(0);
                        oPeople.Name = reader.GetString(1);
                        oPeople.Age = reader.GetInt32(2);

                    reader.Close();

                    connection.Close();

                    return oPeople;
                }
                catch(Exception ex)
                {
                    throw new Exception("Hay error" + ex.Message);
                }
            }



            //return people;
        }

        public void Add(string Name, int Age)
        {
            string query = "INSERT INTO people(name,age) VALUES(@name, @age)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //enviar el comando
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", Name);
                command.Parameters.AddWithValue("@age", Age);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery(); //aquí lo ejecuta
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay error" + ex.Message);
                }
            }
        }


        public void Update(string Name, int Age, int Id)
        {
            string query = "UPDATE people SET name=@name, age=@age where id=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //enviar el comando
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", Name);
                command.Parameters.AddWithValue("@age", Age);
                command.Parameters.AddWithValue("@id", Id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery(); //aquí lo ejecuta
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay error" + ex.Message);
                }
            }
        }
    }
}
